namespace Aoc2022.Tests.Day09;

using Aoc2022.Day09;

public class Day09Test : BaseTest<Day09>
{
    public Day09Test()
    {
        Sut = new Day09();
    }

    public class ShouldSolveOne : Day09Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider
                .Setup(x => x.Read())
                .Returns(new[] { "R 4", "U 4", "L 3", "D 1", "R 4", "D 1", "L 5", "R 2" });

            string actual = Sut.SolveOne(InputProvider.Object);
            actual.Should().Be("13");
        }
    }

    public class ShouldSolveTwo : Day09Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider
                .Setup(x => x.Read())
                .Returns(new[] { "R 4", "U 4", "L 3", "D 1", "R 4", "D 1", "L 5", "R 2" });
            
            string actual = Sut.SolveTwo(InputProvider.Object);
            actual.Should().Be("1");
        }

        [Fact]
        public void ShouldSolveLarger()
        {
            InputProvider
                .Setup(x => x.Read())
                .Returns(new[] { "R 5", "U 8", "L 8", "D 3", "R 17", "D 10", "L 25", "U 20 " });
            
            InputProvider
                .Setup(x => x.ReadAllText())
                .Returns($"R 5{Environment.NewLine}U 8{Environment.NewLine}L 8{Environment.NewLine}D 3{Environment.NewLine}R 17{Environment.NewLine}D 10{Environment.NewLine}L 25{Environment.NewLine}U 20 ");

            string actual = Sut.SolveTwo(InputProvider.Object);
            actual.Should().Be("36");
        }
    }
}