# 5. Refactor tests to mock injected dependencies
One of the primary benefits of dependency injection is to ensure types are loosely coupled. This exercise will show you how to mock dependencies now that dependencies are injected into their consumers.

## Tasks (perform the following steps):
* Mock the `IRandom` interface to test `Generator` in isolation.
* Extract an `IGenerator` interface soas to mock the `Generator` class in `App`.
* Extract a new dependency - `Console` as a `TextWriter` and test the interaction between `App` and `Console`

## Result (notice the following changes):
* Because dependencies are injected, tests can utilize production dependencies or mocks.
* We added a new dependency to `App` - a `TextWriter` - without adding corresponding bindings for `TextWriter`. All tests pass, but `Main()` fails to execute! In the next exercise, we will test drive a fix for this missing Ninject binding.

## Benefits:
* Each class can now be independently tested, now that all dependencies are injected rather than constructed by each consumer.
