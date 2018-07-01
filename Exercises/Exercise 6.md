# 6. Test drive the addition of a dependency binding
In this final exercise, you will test drive the addition of a dependency binding. Such tests are often useful to ensure all necessary bindings are included before deploying to a live environment.

## Tasks (perform the following steps):
* Write a test which gets an `IApp` from the kernel (to ensure it is bound correctly)
* Write a test which rebinds `IApp` and calls `Main()` (to ensure `Main()` behaves correctly)

## Result (notice the following changes):
* Because `Program` cannot have its dependencies injected, the kernel must be exposed in order to rebind `IApp`
* The test which retrieves `IApp` from the kernel should fail if any bindings in the dependency graph are missing. In this exercise, bindings for `IGenerator` and `TextWriter` were missing.

## Benefits:
* By wrapping external dependencies, injecting rather than instantiating dependencies, and testing dependency bindings, it's possible to fully test all interactions between classes in an application.
