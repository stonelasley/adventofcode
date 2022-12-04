namespace Aoc2022.Tests.Day02;

using Aoc2022.Day02;

public class Day02Test : BaseTest<Day02>
{
    public Day02Test()
    {
        Sut = new Day02();
    }

    public class GetGame : Day02Test
    {
        [Fact]
        public void ShouldParseRounds()
        {
            InputProvider.Setup(x => x.Read()).Returns(new[] { "A Y", "B X", "C Z", });

            Game actual = Sut.GetGame(InputProvider.Object);

            actual.Rounds.Count.Should().Be(3);
        }
    }
}