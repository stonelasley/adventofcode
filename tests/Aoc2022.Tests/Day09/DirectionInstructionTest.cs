namespace Aoc2022.Tests.Day09;

using Aoc2022.Day09;

public class DirectionInstructionTest : Day09Test
{
    [Theory]
    [InlineData("R 4", Direction.Right, 4)]
    [InlineData("U 4", Direction.Up, 4)]
    [InlineData("L 3", Direction.Left, 3)]
    [InlineData("D 1", Direction.Down, 1)]
    public void ShouldParse(string input, Direction expectedDirection, int expectedDistance)
    {
        var actual = new DirectionInstruction(input);
        actual.Direction.Should().Be(expectedDirection);
        actual.Distance.Should().Be(expectedDistance);
    }
}