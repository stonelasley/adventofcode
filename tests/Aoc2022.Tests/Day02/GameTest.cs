namespace Aoc2022.Tests.Day02;

using Aoc2022.Day02;

public class GameTest
{
    [Fact]
    public void ShouldCalculateScore()
    {
        string[] roundInput = {"A Y", "B X", "C Z"};
        Game actual = new(roundInput);
        actual.Score.Should().Be(15);
    }

    [Fact]
    public void ShouldCalculateAlternateScore()
    {
        string[] roundInput = {"A Y", "B X", "C Z"};
        Game actual = new(roundInput);
        actual.ScoreTwo.Should().Be(12);
    }
}