# Dependency Injection Kata

A small code kata to practice dependency injection in C# using Ninject.

## Goals
1. Implement an IoC container using Ninject
1. Inject all dependencies throughout the application
1. Improve testability throughout the application

## Exercises
In this kata, you will perform several refactorings to achieve the goals stated above. I will guide you through the following steps:
1. [Refactor `Generator` class to inject dependency](Exercises/Exercise%201.md) - [Changeset](https://github.com/SonnevilleJ/CSharp-Dependency-Injection-Kata/commit/54c623c6c9f1238ddc51002c5e8e89e850ac27eb)
1. [Configure a Ninject kernel with appropriate bindings](Exercises/Exercise%202.md) - [Changeset](https://github.com/SonnevilleJ/CSharp-Dependency-Injection-Kata/commit/bd0b690277c35d866f8eb516797caabc3fcbca87)
1. [Move bindings into a Ninject Module](Exercises/Exercise%203.md) - [Changeset](https://github.com/SonnevilleJ/CSharp-Dependency-Injection-Kata/commit/4bdbde454dc3402262fc5dc8a10c4c46500b62d8)
1. [Extract App from `Program`](Exercises/Exercise%204.md) - [Changeset](https://github.com/SonnevilleJ/CSharp-Dependency-Injection-Kata/commit/0a77566e02d331402721c57e449054541489b98b)
1. [Refactor tests to mock injected dependencies](Exercises/Exercise%205.md) - [Changeset](https://github.com/SonnevilleJ/CSharp-Dependency-Injection-Kata/commit/8963c75e9b5e5f670311f84d6ade39147c4a08c3)
1. [Test drive the addition of a dependency binding](Exercises/Exercise%206.md) - [Changeset](https://github.com/SonnevilleJ/CSharp-Dependency-Injection-Kata/commit/e2e46d88862f2d900779b0898481eaae764184b3)

Steps 4 and later are not required for dependency injection, but are merely benefits of it. Step 4 allows all dependencies (including the Ninject kernel bindings) to be tested. Without this step, integration tests remain quite possible, although mocking dependencies is nearly impossible when calling `Main()` from a test.

## Additional Considerations
Once you've completed all exercises, I'll leave you to ponder a few other considerations:
* For new applications, when is the right time to introduce dependency injection? What about an IoC container?
* How should bindings be organized within a large application?
* How do you balance application config with bindings? Do you read config values before processing bindings, or should your types read config values themselves?
* Should libraries contain bindings for their types, or should bindings live in an executable?
* Should the full dependency graph be constructed immediately at runtime, or should some dependencies be constructed on demand when the user enters a certain section of the application?
    * How might such lazy instantiation be implemented?
    * What are the consequences of each option?
* When should tests use the production kernel, a test-only kernel, or no kernel? Under what circumstances, if any, should you (re)bind dependencies to mocks?
