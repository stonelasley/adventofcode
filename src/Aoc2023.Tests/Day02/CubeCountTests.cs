namespace Aoc2023.Tests.Day02;

using Aoc2023.Day02;

public class CubeCountTests
{
    [Theory]
    [InlineData("3 blue", "blue", 3)]
    [InlineData("13 green", "green", 13)]
    public void ShouldParse(string input, string expectedColor, int expectedCount)
    {
        var actual = new CubeCount(input);

        actual.Color.Should().Be(expectedColor);
        actual.Count.Should().Be(expectedCount);
    }
}