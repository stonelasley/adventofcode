namespace Aoc2022.Tests.Day14;

using Aoc2022.Day14;

public class Day14Test : BaseTest<Day14>
{
    public Day14Test()
    {
        Sut = new Day14();
    }

    public class SolveOne : Day14Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider.Setup(x => x.Read()).Returns(new[]
            {
                "498,4 -> 498,6 -> 496,6",
                "503,4 -> 502,4 -> 502,9 -> 494,9",
            });

            var actual = Sut.SolveOne(InputProvider.Object);
            actual.Should().Be("24");
        }
    }

    //public class SolveTwo: Day14Test
    //{
    //    [Fact]
    //    public void ShouldSolve()
    //    {
    //        InputProvider.Setup(x => x.Read())
    //            .Returns(new [] {""});

    //        var actual = Sut.SolveTwo(InputProvider.Object);
    //        actual.Should().Be("");
    //    }
    //}
}