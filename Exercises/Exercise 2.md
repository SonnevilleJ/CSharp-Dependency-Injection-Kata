# 2. Configure Ninject kernel with appropriate bindings
In this exercise, we will create an Inversion of Control (IoC) container and refactor our [`Main` method](../DependencyInjectionKata/Program.cs) to use the IoC container. The library we will use is called [Ninject](http://www.ninject.org/) - a popular library for managing dependency injection within .NET projects.

## Tasks (perform the following steps):
* Add Ninject as a NuGet dependency
* Create a kernel with bindings for all dependencies we want to inject
* Configure the `Main` method to use the Ninject kernel

## Result (notice the following changes):
* Dependencies are no longer instantiated directly - no more `new` keyword.
* Bindings are only required when requesting abstract types or interfaces. Calling `Kernel.Get<T>()` for a concrete type `T` requires no additional bindings beyond those required for dependencies of T.

## Benefits:
* Once all bindings are in place, the entire application can run with as little as a single call to `.Get<T>()`.
* Bindings can be configured to produce types as singletons, potentially reducing memory consumption.
