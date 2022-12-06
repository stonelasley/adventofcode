namespace Aoc2021.Tests.Day03;

using Aoc2021.Day03;

public class Day03Test : BaseTest<Day03>
{
    public Day03Test()
    {
        Sut = new Day03();
    }

    public class SolveOne : Day03Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider
                .Setup(x => x.Read())
                .Returns(
                    new[]
                    {
                        "00100",
                        "11110",
                        "10110",
                        "10111",
                        "10101",
                        "01111",
                        "00111",
                        "11100",
                        "10000",
                        "11001",
                        "00010",
                        "01010"
                    }
                );

            var actual = Sut.SolveOne(InputProvider.Object);
            actual.Should().Be("198");
        }
    }

    public class SolveTwo : Day03Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider
               .Setup(x => x.Read())
               .Returns(
                    new[]
                    {
                        "00100",
                        "11110",
                        "10110",
                        "10111",
                        "10101",
                        "01111",
                        "00111",
                        "11100",
                        "10000",
                        "11001",
                        "00010",
                        "01010"
                    }
                );

            var actual = Sut.SolveTwo(InputProvider.Object);
            actual.Should().Be("230");
        }
    }
}
