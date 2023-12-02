namespace Aoc2023.Tests.Day02;

using Aoc2023.Day02;

public class Day02Test : BaseTest<Day02>
{
    public Day02Test() => Sut = new Day02();

    public class SolveOne : Day02Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider
                .Setup(x => x.Read())
                .Returns(
                    new[]
                    {
                        "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
                        "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
                        "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
                        "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
                        "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
                    }
                );
            string result = Sut.SolveOne(InputProvider.Object);
            result.Should().Be("8");
        }
    }

    public class SolveTwo : Day02Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider.Setup(x => x.Read()).Returns(new[] { "", "", "", "" });
            string result = Sut.SolveOne(InputProvider.Object);
            result.Should().Be("");
        }
    }
}