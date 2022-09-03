# LearningUnitTesting

Solution developed to learn about diverse features from frameworks and libraries  for Unit Tests in .NET.<br/>

## Systems Under Test

The system designed is a fake IAM *(Identity and Access Manager)* with only a few hardcoded features.<br/>
It has basically two main classes: `AccessManager` and `IdentityProvider`, and they're models and fake user repository.<br/>
There is also a `GuidGenerator` used to try different setup/teardown (via constructor and dispose method) and contexts of [xUnit](https://xunit.net/).

## Projects

### LearningXUnitTests

As exposed in the [xUnit](https://xunit.net/) official page:

> xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the [.NET Foundation](https://www.dotnetfoundation.org/), and operates under their [code of conduct](https://www.dotnetfoundation.org/code-of-conduct). It is licensed under [Apache 2](https://opensource.org/licenses/Apache-2.0) (an OSI approved license).

This project is aimed to learn the basis of [xUnit](https://xunit.net/). Contains:


- [`UserTests`](./LearningXUnitTests/UserTests.cs) contains tests using:
    - `FactAttribute`
    - `TheoryAttribute` + `InlineDataAttribute`
    - `TheoryAttribute` + `MemberDataAttribute`
    - `TheoryAttribute` + `ClassDataAttribute`
    - Different `Assert` methods.
- [`XUnitContextsTests`](./LearningXUnitTests/XUnitContextsTests.cs) contains tests using:
    - Setup via constructor and teardown via `IDisposable.Dispose()`
    - Class context via `IClassFixture`
    - Collection context via `ICollectionFixture` 

### LearningMoqTests

Test doubles are simulated objects that replace the productions implementations. This allows isolating units of work to test them without dependencies. For more details about Test Doubles and different types of them, [read this article from Martin Fowler's blog](https://martinfowler.com/bliki/TestDouble.html), and [this one for a deeper understanding](https://martinfowler.com/articles/mocksArentStubs.html) (also by Martin Fowler).

[Moq](https://github.com/moq/moq) is one of the most used mocking frameworks. This project is aimed to learn how to implement test doubles with [Moq](https://github.com/moq/moq).

- [`AccessManagerTests`](./LearningMoqTests/AccessManagerTests.cs) contains tests using:
    - Injection of a mocked `IUsersRepository` with `Mock<IUsersRepository>`
    - Basic `Setup` + `Returns` on stubs
- [`IdentityProviderTests`](./LearningMoqTests/IdentityProviderTests.cs) contains tests using:
    - Injection of multiple mocks/stubs
    - Basic `Setup` + `Returns` on stubs
    - `Setup` using `Moq.It` for generic arguments
    - Special case for the `null` value return on a stub
    - Invocation verify with `Verify` method + `Times` struct

