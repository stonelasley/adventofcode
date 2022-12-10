namespace Aoc2022.Tests.Day09;

using Aoc2022.Day09;

public class DirectionTest : Day09Test
{
    [Theory]
    [InlineData("R 4", Direction.Right, Plane.X, 4)]
    [InlineData("L 12", Direction.Left, Plane.X, -12)]
    [InlineData("D 2", Direction.Down, Plane.Y, -2)]
    [InlineData("U 2", Direction.Up, Plane.Y, 2)]
    public void ShouldTranslateDirection(
        string input,
        Direction expectedDirection,
        Plane expectedPlane,
        int expectedDistance
    )
    {
        var actual = new DirectionInstruction(input);
        actual.Direction.Should().Be(expectedDirection);
        actual.Distance.Should().Be(expectedDistance);
        actual.Plane.Should().Be(expectedPlane);
    }
}