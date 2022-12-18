namespace Aoc2022.Tests.Day12;

using Aoc2022.Day12;

public class Day12Test : BaseTest<Day12>
{
    public Day12Test()
    {
        Sut = new Day12();
    }

    public class SolveOne : Day12Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider
                .Setup(x => x.Read())
                .Returns(new[] { "Sabqponm", "abcryxxl", "accszExk", "acctuvwj", "abdefghi" });

            string actual = Sut.SolveOne(InputProvider.Object);
            actual.Should().Be("31");
        }
    }

    public class SolveTwo : Day12Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider
                .Setup(x => x.Read())
                .Returns(new[] { "Sabqponm", "abcryxxl", "accszExk", "acctuvwj", "abdefghi" });

            string actual = Sut.SolveTwo(InputProvider.Object);
            actual.Should().Be("29");
        }
    }
}
