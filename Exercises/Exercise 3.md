# 3. Move bindings into a Ninject Module 
This exercise is a small step from the last, but it is often necessary for larger applications with many internal dependencies. Bindings can be organized into [Ninject Modules](https://github.com/ninject/Ninject/wiki/Modules-and-the-Kernel), allowing you to improve the structure and readability of your application.

## Tasks (perform the following steps):
1. Create a new class which inherits from `NinjectModule`
1. Pass an instance of the module to the StandardKernel

## Result (notice the following changes):
* Bindings are no longer cluttering `Main()`.

## Benefits:
* Better code organization
* Allows you to isolate groups of dependencies with their associated bindings
