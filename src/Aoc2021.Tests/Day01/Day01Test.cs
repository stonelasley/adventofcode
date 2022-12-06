namespace Aoc2021.Tests.Day01;

using Aoc2021.Day01;

public class Day01Test : BaseTest<Day01>
{
    public Day01Test()
    {
        Sut = new Day01();
    }

    public class SolveOne : Day01Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider
                .Setup(x => x.Read())
                .Returns(
                    new[] { "199", "200", "208", "210", "200", "207", "240", "269", "260", "263" }
                );

            var actual = Sut.SolveOne(InputProvider.Object);
            actual.Should().Be("7");
        }
    }

    public class SolveTwo : Day01Test
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
            actual.Should().Be("5");
        }
    }
}
