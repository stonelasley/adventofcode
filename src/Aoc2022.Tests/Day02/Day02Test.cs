namespace Aoc2022.Tests;

using Aoc2022;

public class Day02Test : BaseTest<Day02>
{
    public Day02Test()
    {
        Sut = new Day02(InputProvider.Object);
    }

    public class GetGame : Day02Test
    {
        [Fact]
        public void ShouldParseRounds()
        {
            InputProvider.Setup(x => x.Read(null)).Returns(new[] { "A Y", "B X", "C Z", });

            RpsGame actual = Sut.GetGame();

            actual.Rounds.Count.Should().Be(3);
        }
    }
}

public class RpsGameTest
{
    [Fact]
    public void ShouldCalculateScore()
    {
        string[] roundInput = new[] { "A Y", "B X", "C Z" };
        var actual = new RpsGame(roundInput);
        actual.Score.Should().Be(15);
    }
    
    [Fact]
    public void ShouldCalculateAlternateScore()
    {
        string[] roundInput = new[] { "A Y", "B X", "C Z" };
        var actual = new RpsGame(roundInput);
        actual.Score2.Should().Be(12);
    }
}

public class RpsRoundTest
{
    [Theory]
    [InlineData('A', 'Y', true)]
    [InlineData('B', 'X', false)]
    [InlineData('C', 'Z', false)]
    public void ShouldCompareShapes(char theirAlias, char myAlias, bool expected)
    {
        var actual = new RpsRound(myAlias, theirAlias);

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
        var actual = new RpsRound(myAlias, theirAlias);

        actual.Draw.Should().Be(expected);
    }

    [Theory]
    [InlineData('A', 'Y', 8)]
    [InlineData('B', 'X', 1)]
    [InlineData('C', 'Z', 6)]
    public void ShouldCalculateScore(char theirAlias, char myAlias, int expectedScore)
    {
        var actual = new RpsRound(myAlias, theirAlias);

        actual.Score.Should().Be(expectedScore);
    }
}

public class RpsOutcomeTest
{
    [Theory]
    [InlineData('X', RpsOutcome.Lose)]
    [InlineData('Y', RpsOutcome.Draw)]
    [InlineData('Z', RpsOutcome.Win)]
    public void ShouldParseOutcome(char alias, RpsOutcome outcome)
    {
        var actual = new ThrowOutcome(alias);
        actual.Outcome.Should().Be(outcome);
    }
}

public class RpsThrowTest
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
        var actual = new RpsThrow(alias);
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
        var rpsThrow = new RpsThrow(shapeAlias);
        var outcome = new ThrowOutcome(outcomeAlias);
        var actual = rpsThrow.CounterShapeByOutcome(outcome.Outcome);

        actual.Should().Be(shape);
    }
}