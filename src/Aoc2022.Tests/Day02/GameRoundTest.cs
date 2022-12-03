using Aoc2022.Day02;

namespace Aoc2022.Tests.Day02;

using Aoc2022.Day02;

public class GameRoundTest
{
    [Theory]
    [InlineData('A', 'Y', true)]
    [InlineData('B', 'X', false)]
    [InlineData('C', 'Z', false)]
    public void ShouldCompareShapes(char theirAlias, char myAlias, bool expected)
    {
        GameRound actual = new (myAlias, theirAlias);

        actual.Won.Should().Be(expected);
    }

    [Theory]
    [InlineData('A', 'X', true)]
    [InlineData('B', 'Y', true)]
    [InlineData('C', 'Z', true)]
    [InlineData('B', 'Z', false)]
    [InlineData('A', 'Z', false)]
    public void ShoulDetermineDraw(char theirAlias, char myAlias, bool expected)
    {
        GameRound actual = new (myAlias, theirAlias);

        actual.Draw.Should().Be(expected);
    }

    [Theory]
    [InlineData('A', 'Y', 8)]
    [InlineData('B', 'X', 1)]
    [InlineData('C', 'Z', 6)]
    public void ShouldCalculateScore(char theirAlias, char myAlias, int expectedScore)
    {
        GameRound actual = new (myAlias, theirAlias);

        actual.Score.Should().Be(expectedScore);
    }
}