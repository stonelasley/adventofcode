namespace Aoc2022.Tests.Day06;

using Aoc2022.Day06;

public class Day06Test : BaseTest<Day06>
{
    public Day06Test()
    {
        Sut = new Day06();
    }

    public class SolveOne : Day06Test
    {
        [Theory]
        [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
        [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
        [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
        [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
        public void ShouldSolve(string input, int expected)
        {
            InputProvider.Setup(x => x.ReadAllText()).Returns(input);

            var actual = Sut.SolveOne(InputProvider.Object);

            actual.Should().Be($"{expected}");
        }
    }

    public class SolveTwo : Day06Test
    {
        [Theory]
        [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
        public void ShouldSolve(string input, int expected)
        {
            InputProvider.Setup(x => x.ReadAllText()).Returns(input);

            var actual = Sut.SolveTwo(InputProvider.Object);

            actual.Should().Be($"{expected}");
        }
    }
}
