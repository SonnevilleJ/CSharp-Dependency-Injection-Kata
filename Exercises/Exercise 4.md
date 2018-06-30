# 4. Extract App class to isolate `Main()`
This exercise is not strictly part of dependency injection, but something I recommend regardless. By creating an 'App' class, separate from `Program`, you can isolate your business logic from your IoC/dependency management. This is nothing more than the single responsibility principle applied to dependency injection.

## Tasks (perform the following steps):
* Create an `App` class with a `Run()` method
* Optionally, add `string[] args` as a parameter to `Run()`
* Create an `IApp` interface and add a binding
* Configure `Main()` to get an instance of `IApp` and run it
* Update tests to instantiate/invoke `App` instead of `Program`

## Result (notice the following changes):
* All business logic resides in `App` or its dependency graph - none in `Program`
* `Program.Main()` does nothing more than manage retrieval, execution, and disposal (if necessary) of the `IApp`

## Benefits:
* `App` is decoupled from the `Main()` execution - `App` can even live in a library rather than an EXE. This makes it fully testable, with all dependencies being mockable.
