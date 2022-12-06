namespace Aoc2022.Tests.Day02;

using Aoc2022.Day02;

public class GameOutcomeTest
{
    [Theory]
    [InlineData('X', RpsOutcome.Lose)]
    [InlineData('Y', RpsOutcome.Draw)]
    [InlineData('Z', RpsOutcome.Win)]
    public void ShouldParseOutcome(char alias, RpsOutcome outcome)
    {
        GameThrowOutcome actual = new(alias);
        actual.Outcome.Should().Be(outcome);
    }
}