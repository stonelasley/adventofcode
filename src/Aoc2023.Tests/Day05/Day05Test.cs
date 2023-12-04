namespace Aoc2023.Tests.Day05;

using Aoc2023.Day05;

public class Day05Test : BaseTest<Day05>
{
    public Day05Test() => Sut = new Day05();

    public class SolveOne : Day05Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider.Setup(x => x.Read()).Returns(new[] { "", "", });
            string result = Sut.SolveOne(InputProvider.Object);
            result.Should().Be("unsolved");
        }
    }

    public class SolveTwo : Day05Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider.Setup(x => x.Read()).Returns(new[] { "", "", });
            string result = Sut.SolveTwo(InputProvider.Object);
            result.Should().Be("unsolved");
        }
    }
}