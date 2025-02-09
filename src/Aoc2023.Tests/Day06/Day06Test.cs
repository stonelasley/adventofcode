namespace Aoc2023.Tests.Day06;

using Aoc2023.Day06;

public class Day06Test : BaseTest<Day06>
{
    public Day06Test() => Sut = new Day06();

    public class SolveOne : Day06Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider
                .Setup(x => x.Read())
                .Returns([
                    "Time:      7  15   30",
                    "Distance:  9  40  200"
                ]);
            string result = Sut.SolveOne(InputProvider.Object);
            result.Should().Be("288");
        }
    }

    public class SolveTwo : Day06Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider
                .Setup(x => x.Read())
                .Returns([
                    "Time:      7  15   30",
                    "Distance:  9  40  200"
                ]);
            string result = Sut.SolveTwo(InputProvider.Object);
            result.Should().Be("71503");
        }
    }
}