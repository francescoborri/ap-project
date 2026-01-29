# Relevant prompts

This document collects the most relevant prompts used to gather information about F# units of measure from different AI tools; the complete chats are available at the links provided in the AI output validation document.

## Introductory part

- (ChatGPT) I am a Master’s student in Computer Science, attending an Advanced Programming course. As part of my final exam, I must write a technical report on F# Units of Measure, with a particular focus on their implementation in the language and on the soundness guarantees provided by the extended type system. From now on, please consider also the official information about the course (the PDF file I attached to this prompt), so that you can understand the programming aspects stressed during the classes and tweak your answers; also do not stop at presenting the main concepts touching them superficially, but instead you must provide structured and detailed answers. For now, to get started, just give me a brief description of the F# units of measure, and tell me where this feature should be placed among the various high-level parts of which a programming language is constituted.

## Overview of F# units of measure

- (ChatGPT) Is it possible to raise a unit to a fractional power? (for example m^(1/2))
- (ChatGPT) Is there a way to cast a unit-annotated numeric value to another numeric types preserving the type-annotation?
- (ChatGPT) Is it possible to write type-generic and unit-generic functions?
- (ChatGPT) Other than functions, is there something which can be made unit-polymorphic?

## Type-theoretic part

- (ChatGPT) Let's move towards the type-theoretic foundations behind this extension: can you explain me how this system can be formalized into the type-theoretic framework, and how this can help implement type-checking and type-inference algorithms.
- (ChatGPT) How can this be extended to support units of measure? I want you to provide an overview of what has to be done in order to have measure type-checking and type-inference, both syntactically and at the level of type-system.
- (NotebookLM) Sto scrivendo un report sulla funzionalità delle unità di misura implementata in F#, e vorrei discutere brevemente le fondazioni di teoria dei tipi su cui si basa, discusse nella fonte allegata. Puoi darmi una breve panoramica sull'integrazione delle unità di misura nel type-system? Sono interessato a capire come la sintassi viene estesa, come le regole di inferenza vengono estese, capire la teoria equazionale dietro le unità di misura e infine come la type-inference in stile Hindley-Milner deve essere modificata per supportare le unità di misura.
- (NotebookLM) E' possibile estendere l'algoritmo di unificazione equazionale permettendo soluzioni razionali al posto di soluzioni intere?

## Implementation part

- (GitHub Copilot) How does type-checking and type-inference (and unification) work for units of measure?
- (GitHub Copilot) When are unit of measure erased by the compiler? Can you locate and explain pieces of relevant code involving this aspect?
