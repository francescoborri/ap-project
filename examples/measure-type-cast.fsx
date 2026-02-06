[<Measure>] type m
[<Measure>] type s

// This files contains some examples of type casts involving units of measure,
// inspecting the behavior of the compiler in their presence, including some
// incorrect usages that break soundness and require programmer caution.

// Incorrect, the measure of FloatWithMeasure is not constrained to be equal to 'u
// and this can be exploited to break soundness
// Inferred type: int<'u> -> float<'v> 
let badIntToFloat (x: int<'u>) = x |> float |> LanguagePrimitives.FloatWithMeasure

// Correct, the measure of FloatWithMeasure is constrained to be equal to 'u
// Inferred type: int<'u> -> float<'u>
let intToFloat (x: int<'u>) = x |> float |> LanguagePrimitives.FloatWithMeasure<'u>

// The compiler incorrectly accepts this code, which break soundness
let a: float<s> = badIntToFloat 5<m> 

// The compiler correctly rejects this code
// let b: float<s> = intToFloat 5<m>
