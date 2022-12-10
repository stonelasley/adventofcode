namespace Aoc.Core.Tests;

using System.Diagnostics.CodeAnalysis;
using Moq;

[ExcludeFromCodeCoverage]
public abstract class BaseTest<T> where T : class
{
    protected Mock<IInputProvider> InputProvider = new();
    protected T Sut = null!;
}
