namespace Aoc2022.Tests.Day02;

using Aoc2022.Day02;

public class Day02Test
{
    protected Mock<IInputProvider<Day02>> InputProvider = new();
    protected Day02 Sut;

    public Day02Test()
    {
        Sut = new Day02(InputProvider.Object);
    }

    public class GetGame: Day02Test
    {
        [Fact]
        public void ShouldParseRounds()
        {
            InputProvider.Setup(x => x.Read(null)).Returns(new []
            {
                "A Y",
                "B X",
                "C Z",
            });
            
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
        string[] roundInput = new [] {"A Y", "B X", "C Z"};
        var actual = new RpsGame(roundInput);
        actual.Score.Should().Be(15);
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
