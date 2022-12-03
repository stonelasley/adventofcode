namespace Aoc2022.Tests.Day02;

using Aoc2022.Day02;

public class GameThrowTest
{
    [Theory]
    [InlineData('A', 1, RpsShape.Rock)]
    [InlineData('B', 2, RpsShape.Paper)]
    [InlineData('C', 3, RpsShape.Scissors)]
    [InlineData('X', 1, RpsShape.Rock)]
    [InlineData('Y', 2, RpsShape.Paper)]
    [InlineData('Z', 3, RpsShape.Scissors)]
    public void ShouldInstantiate(char alias, int score, RpsShape shape)
    {
        GameThrow actual = new (alias);
        actual.Score.Should().Be(score);
        actual.Shape.Should().Be(shape);
    }

    [Theory]
    [InlineData('A', 'Y', RpsShape.Rock)]
    [InlineData('B', 'X', RpsShape.Rock)]
    [InlineData('C', 'Z', RpsShape.Rock)]
    public void ShouldProvideShapeBasedOnDesiredOutcome(
        char shapeAlias,
        char outcomeAlias,
        RpsShape shape
    )
    {
        GameThrow rpsThrow = new (shapeAlias);
        GameThrowOutcome outcome = new (outcomeAlias);
        RpsShape actual = rpsThrow.CounterShapeByOutcome(outcome.Outcome);

        actual.Should().Be(shape);
    }
}