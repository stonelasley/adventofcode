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
        var actual = new Game(input);
        actual.Number.Should().Be(expectedGame);
    }

    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 3)]
    [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red ", 3)]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 2)]
    public void ShouldParseCubeSet(string input, int expectedCubeSets)
    {
        var actual = new Game(input);
        actual.Sets.Count.Should().Be(expectedCubeSets);
    }

    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 1, 1, 1, false)]
    [InlineData(
        "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red ",
        99,
        99,
        99,
        true
    )]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 99, 99, 0, false)]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 99, 99, 99, true)]
    public void ShouldAssessGameFeasibility(
        string input,
        int maxRed,
        int maxGreen,
        int maxBlue,
        bool isPossible 
    )
    {
        Dictionary<string, int> maxCubes = new()
        {
            { "red", maxRed },
            { "green", maxGreen },
            { "blue", maxBlue }
        };

        Game game = new Game(input, maxCubes);
        game.IsPossible.Should().Be(isPossible);
    }
    
    [Theory]
    [InlineData("Game 1: 1 blue, 1 red; 1 red, 1 green, 1 blue; 1 green", 1, 1, 1)]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 4, 2, 6)]
    [InlineData("Game 1: 3 blue; 6 blue; 2 blue", 0, 0, 6)]
    public void ShouldFindMaxInSet(string input, int maxRed, int maxGreen, int maxBlue)
    {
        var actual = new Game(input);
        actual.FindMax("red").Should().Be(maxRed);
        actual.FindMax("green").Should().Be(maxGreen);
        actual.FindMax("blue").Should().Be(maxBlue);
    }
}