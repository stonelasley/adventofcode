namespace Aoc2023.Tests.Day02;

using Aoc2023.Day02;

public class CubeSetTests
{
    [Theory]
    [InlineData("2 green", 1)]
    [InlineData("3 blue, 4 red", 2)]
    [InlineData("1 red, 2 green, 6 blue", 3)]
    public void ShouldParseGameNumber(string input, int expectedCubeCounts)
    {
        var actual = new CubeSet(input);
        actual.CubeCounts.Count.Should().Be(expectedCubeCounts);
    }

    [Theory]
    [InlineData("2 green", 0, 3, 0, true)]
    [InlineData("2 green", 0, 1, 0, false)]
    [InlineData("3 blue, 4 red", 5, 0, 2, false)]
    [InlineData("3 blue, 4 red", 4, 0, 3, true)]
    public void ShouldAssessMaximum(
        string input,
        int maxRed,
        int maxGreen,
        int maxBlue,
        bool possible
    )
    {
        Dictionary<string, int> max = new Dictionary<string, int>()
        {
            { "red", maxRed },
            { "green", maxGreen },
            { "blue", maxBlue }
        };
        var cubeSet = new CubeSet(input, max);
        cubeSet.Possible.Should().Be(possible);
    }
}