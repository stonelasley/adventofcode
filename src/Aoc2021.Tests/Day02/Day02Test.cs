namespace Aoc2021.Tests.Day02;

using Aoc2021.Day02;

public class Day02Test : BaseTest<Day02>
{
    public Day02Test()
    {
        Sut = new Day02();
    }

    public class SolveOne : Day02Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider
                .Setup(x => x.Read())
                .Returns(
                    new[]
                    {
                        "forward 5",
                        "down 5",
                        "forward 8",
                        "up 3",
                        "down 8",
                        "forward 2"
                    }
                );

            var actual = Sut.SolveOne(InputProvider.Object);
            actual.Should().Be(150);
        }
    }

    public class SolveTwo : Day02Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider.Setup(x => x.Read()).Returns(new []
            {
                "199",
                "200",
                "208",
                "210",
                "200",
                "207",
                "240",
                "269",
                "260",
                "263"
            });

            var actual = Sut.SolveTwo(InputProvider.Object);
            actual.Should().Be(5);
        }
    }
}
