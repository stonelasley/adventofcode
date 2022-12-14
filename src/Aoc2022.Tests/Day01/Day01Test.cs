namespace Aoc2022.Tests.Day01;

using Aoc2022.Day01;

public class Day01Test : BaseTest<Day01>
{
    public Day01Test()
    {
        Sut = new Day01();
    }

    public class GetCaloriesByElf : Day01Test
    {
        [Fact]
        public void ShouldGroupCalories()
        {
            InputProvider.Setup(x => x.ReadAllText())
                .Returns($"1000{Environment.NewLine}1000{Environment.NewLine}{Environment.NewLine}1000");

            var actual = Sut.GetCaloriesByElf(InputProvider.Object);
            actual.Count().Should().Be(2);
            actual.First().Should().Be(2000);
            actual.Last().Should().Be(1000);
        }
    }

    public class GetMost : Day01Test
    {
        [Fact]
        public void ShouldGetHighest()
        {
            InputProvider.Setup(x => x.ReadAllText())
                .Returns($"1000{Environment.NewLine}1000{Environment.NewLine}{Environment.NewLine}1000");

            var actual = Sut.SolveOne(InputProvider.Object);
            actual.Should().Be("2000");
        }
    }

    public class GetTopThree : Day01Test
    {
        [Fact]
        public void ShouldGetTopThree()
        {
            InputProvider.Setup(x => x.ReadAllText())
                .Returns(
                    $"1000{Environment.NewLine}{Environment.NewLine}2000{Environment.NewLine}{Environment.NewLine}3000{Environment.NewLine}{Environment.NewLine}4000");

            var actual = Sut.SolveTwo(InputProvider.Object);
            actual.Should().Be("9000");
        }
    }
}