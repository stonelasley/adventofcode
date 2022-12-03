namespace Aoc2022.Tests;

public abstract class BaseTest<T> where T : class
{
    protected Mock<IInputProvider<T>> InputProvider = new();
    protected T Sut;
}