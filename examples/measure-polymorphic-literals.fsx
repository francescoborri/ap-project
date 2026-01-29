[<Measure>] type m
[<Measure>] type s

// This files contains some examples of measure-polymorphic literals and inspect
// the behavior of the compiler in their presence, including some incorrect
// usages that break soundness and require programmer caution.

// Since 0.0<_> is measure-polymorphic, also the function is measure-polymorphic
// Inferred type: float<'u> -> float<'u>
let plusZero x = x + 0.0<_>

// Since 1.0<_> is not measure-polymorphic and is statically resolved to float<1>,
// the function is less-general than expected, forcing the generic measure 'u to be 1
// (in fact, this code also cause the compiler to emit a warning about the less-general type)
// Inferred type: float<1> -> float<1>
let badPlusOne x = x + 1.0<_>

// By exploiting inline, 1.0<_> becomes measure-polymorphic because it can
// be statically resolved at each call site, making the function measure-polymorphic
// Inferred type: float<^u> -> float<^u>
let inline plusOne x = x + 1.0<_>

// Since 2.0<_> is not measure-polymorphic, but the multiplication operator
// has not the same type restriction as addition, the function is measure-polymorphic,
// because the measure of 2.0<_> has type float<1> and the result is of type
// float<'u * 1> which is equivalent to float<'u>
// Inferred type: float<'u> -> float<'u>
let double x = x * 2.0<_>

// Since 2.0<_> is not measure-polymorphic, but inline allows its measure to be
// statically resolved at each call site, the type of the result can be coerced
// to be of any measure, breaking soundness
// Inferred type: float<^u> -> float<^v>
let inline badDouble x = x * 2.0<_>

// Same reasoning of the function plusZero
// Inferred type: list<float<'u>> -> float<'u>
let rec sum xs =
    match xs with
    | [] -> 0.0<_>
    | a :: xs' -> a + sum xs'

// Same reasoning of the function badPlusOne
// Inferred type: list<float<1>> -> float<1>
let rec badSumPlusOne xs =
    match xs with
    | [] -> 1.0<_>
    | a :: xs' -> a + sum xs'

// Same reasoning of the function plusOne
// Inferred type: list<float<^u>> -> float<^u>
let rec inline sumPlusOne xs =
    match xs with
    | [] -> 1.0<_>
    | a :: xs' -> a + sum xs'