namespace Aoc2022.Tests.Day10;

using Aoc2022.Day10;

public class Day10Test : BaseTest<Day10>
{
    public Day10Test()
    {
        Sut = new Day10();
    }

    public class SolveOne : Day10Test
    {
        [Fact]
        public void ShouldSolveOneShort()
        {
            InputProvider.Setup(x => x.Read()).Returns(new[] { "noop", "addx 3", "addx -5" });
            var actual = Sut.SolveOne(InputProvider.Object);
            actual.Should().Be("0");
        }

        [Fact]
        public void ShouldSolveOne()
        {
            #region Input
            InputProvider
                .Setup(x => x.Read())
                .Returns(
                    new[]
                    {
                        "addx 15",
                        "addx -11",
                        "addx 6",
                        "addx -3",
                        "addx 5",
                        "addx -1",
                        "addx -8",
                        "addx 13",
                        "addx 4",
                        "noop",
                        "addx -1",
                        "addx 5",
                        "addx -1",
                        "addx 5",
                        "addx -1",
                        "addx 5",
                        "addx -1",
                        "addx 5",
                        "addx -1",
                        "addx -35",
                        "addx 1",
                        "addx 24",
                        "addx -19",
                        "addx 1",
                        "addx 16",
                        "addx -11",
                        "noop",
                        "noop",
                        "addx 21",
                        "addx -15",
                        "noop",
                        "noop",
                        "addx -3",
                        "addx 9",
                        "addx 1",
                        "addx -3",
                        "addx 8",
                        "addx 1",
                        "addx 5",
                        "noop",
                        "noop",
                        "noop",
                        "noop",
                        "noop",
                        "addx -36",
                        "noop",
                        "addx 1",
                        "addx 7",
                        "noop",
                        "noop",
                        "noop",
                        "addx 2",
                        "addx 6",
                        "noop",
                        "noop",
                        "noop",
                        "noop",
                        "noop",
                        "addx 1",
                        "noop",
                        "noop",
                        "addx 7",
                        "addx 1",
                        "noop",
                        "addx -13",
                        "addx 13",
                        "addx 7",
                        "noop",
                        "addx 1",
                        "addx -33",
                        "noop",
                        "noop",
                        "noop",
                        "addx 2",
                        "noop",
                        "noop",
                        "noop",
                        "addx 8",
                        "noop",
                        "addx -1",
                        "addx 2",
                        "addx 1",
                        "noop",
                        "addx 17",
                        "addx -9",
                        "addx 1",
                        "addx 1",
                        "addx -3",
                        "addx 11",
                        "noop",
                        "noop",
                        "addx 1",
                        "noop",
                        "addx 1",
                        "noop",
                        "noop",
                        "addx -13",
                        "addx -19",
                        "addx 1",
                        "addx 3",
                        "addx 26",
                        "addx -30",
                        "addx 12",
                        "addx -1",
                        "addx 3",
                        "addx 1",
                        "noop",
                        "noop",
                        "noop",
                        "addx -9",
                        "addx 18",
                        "addx 1",
                        "addx 2",
                        "noop",
                        "noop",
                        "addx 9",
                        "noop",
                        "noop",
                        "noop",
                        "addx -1",
                        "addx 2",
                        "addx -37",
                        "addx 1",
                        "addx 3",
                        "noop",
                        "addx 15",
                        "addx -21",
                        "addx 22",
                        "addx -6",
                        "addx 1",
                        "noop",
                        "addx 2",
                        "addx 1",
                        "noop",
                        "addx -10",
                        "noop",
                        "noop",
                        "addx 20",
                        "addx 1",
                        "addx 2",
                        "addx 2",
                        "addx -6",
                        "addx -11",
                        "noop",
                        "noop",
                        "noop"
                    }
                );
            #endregion
            var actual = Sut.SolveOne(InputProvider.Object);
            actual.Should().Be("13140");
        }
    }

    public class SolveTwo : Day10Test
    {
        //[Fact]
        public void ShouldSolveTwo()
        {
            InputProvider.Setup(x => x.Read()).Returns(new[] { "" });

            var actual = Sut.SolveTwo(InputProvider.Object);
            actual.Should().Be("9000");
        }
    }
}

public class CathodRayTests : Day10Test
{
    [Theory]
    [InlineData(1, 5, 5, 2, 5)]
    [InlineData(59, 40, 5, 60, 340)]
    public void ShouldIncrementCycle(
        int cycleCount,
        int power,
        int sum,
        int expectedCycleCount,
        int expectedPower
    )
    {
        CathodRayTube.Tick(ref cycleCount, ref power, sum);
        cycleCount.Should().Be(expectedCycleCount);
        power.Should().Be(expectedPower);
    }
}
