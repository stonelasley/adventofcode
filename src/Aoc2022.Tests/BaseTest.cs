namespace Aoc2022.Tests;

public abstract class BaseTest<T> where T : class
{
    protected Mock<IInputProvider> InputProvider = new();
    protected T Sut = null!;
}