namespace Aoc2022.Tests.Day13;

using Aoc2022.Day13;

public class Day13Test : BaseTest<Day13>
{
    public Day13Test()
    {
        Sut = new Day13();
    }

    public class SolveOne : Day13Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider
                .Setup(x => x.Read())
                .Returns(
                    new[]
                    {
                        "[1,1,3,1,1]",
                        "[1,1,5,1,1]",
                        "",
                        "[[1],[2,3,4]]",
                        "[[1],4]",
                        "",
                        "[9]",
                        "[[8,7,6]]",
                        "",
                        "[[4,4],4,4]",
                        "[[4,4],4,4,4]",
                        "",
                        "[7,7,7,7]",
                        "[7,7,7]",
                        "",
                        "[]",
                        "[3]",
                        "",
                        "[[[]]]",
                        "[[]]",
                        "",
                        "[1,[2,[3,[4,[5,6,7]]]],8,9]",
                        "[1,[2,[3,[4,[5,6,0]]]],8,9]"
                    }
                );
            var actual = Sut.SolveOne(InputProvider.Object);
            actual.Should().Be("13");
        }
    }
}