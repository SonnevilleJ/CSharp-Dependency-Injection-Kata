# 1. Refactor `Generator` class to inject dependency
In this first exercise, we will refactor the [`Generator`](../DependencyInjectionKata/Generator.cs) class to have the `Random` dependency injected. As an external dependency (originating outside our project) it's a good practice to also wrap the `Random` class in an interface to allow us to mock out the dependency, but this is not strictly necessary to achieve dependency injection.

## Tasks (perform the following steps):
* Refactor the `Random` variable to a constructor-injected field.
* Wrap an external dependency to decouple it from the project
    * Create an `IRandom` interface for the `Random.Next()` method.
    * Create the `RandomWrapper` class - an implementation of `IRandom` which delegates to the real `Random` class.

## Result (notice the following changes):
1. The `Random` dependency is injected into the `Generator` class, allowing it to be mocked/tested.
1. A new class is introduced to wrap an external dependency - the `RandomWrapper` class.
1. The `Generator` class now depends on `IRandom` rather than `Random` or `RandomWrapper`.
1. The `IRandom` dependency is now instantiated within the [`Program`](../DependencyInjectionKata/Program.cs) class where the `Generator` class is instantiated.

## Benefits:
* A single dependency in a single class is now injected. This same concept should be applied to all other classes in the application. This allows for dependency injection further up the dependency tree.
* Types are losely coupled when each type has a single responsibility.
* Test code can mock the `IRandom` interface while production code can use the `RandomWrapper` class. This allows the `Generator` class to be more meaningfully tested. The external dependency of the `Random.Next()` method is now irrelevant when testing the `Generator` class.
