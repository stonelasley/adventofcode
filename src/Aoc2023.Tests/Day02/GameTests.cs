namespace Aoc2023.Tests.Day02;

using Aoc2023.Day02;

public class GameTests
{
    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 1)]
    [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red ", 4)]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 5)]
    public void ShouldParseGameNumber(string input, int expectedGame)
    {
        var actual = new Game(input, new Dictionary<string, int>());
        actual.Number.Should().Be(expectedGame);
    }

    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 3)]
    [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red ", 3)]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 2)]
    public void ShouldParseCubeSet(string input, int expectedCubeSets)
    {
        var actual = new Game(input, new Dictionary<string, int>());
        actual.Sets.Count.Should().Be(expectedCubeSets);
    }

    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 1, 1, 1, 0)]
    [InlineData(
        "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red ",
        99,
        99,
        99,
        3
    )]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 99, 99, 0, 0)]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 99, 99, 99, 2)]
    public void ShouldAssessCubeFeasibility(
        string input,
        int maxRed,
        int maxGreen,
        int maxBlue,
        int expectedPossibleCount
    )
    {
        Dictionary<string, int> maxCubes = new Dictionary<string, int>()
        {
            { "red", maxRed },
            { "green", maxGreen },
            { "blue", maxBlue }
        };

        Game game = new Game(input, maxCubes);
        var actualPossible = game.PossibleCubeCount;
        actualPossible.Should().Be(expectedPossibleCount);
    }
}