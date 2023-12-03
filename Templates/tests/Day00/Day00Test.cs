namespace Aoc2023.Tests.Day00;

using Aoc2023.Day00;

public class Day00Test : BaseTest<Day00>
{
    public Day00Test() => Sut = new Day00();

    public class SolveOne : Day00Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider.Setup(x => x.Read()).Returns(new[] { "", "", });
            string result = Sut.SolveOne(InputProvider.Object);
            result.Should().Be("");
        }
    }

    public class SolveTwo : Day00Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider.Setup(x => x.Read()).Returns(new[] { "", "", });
            string result = Sut.SolveTwo(InputProvider.Object);
            result.Should().Be("");
        }
    }
}
