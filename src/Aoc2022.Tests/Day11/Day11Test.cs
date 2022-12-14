namespace Aoc2022.Tests.Day11;

using Aoc2022.Day11;
using Day10;

public class Day11Test : BaseTest<Day11>
{
    public Day11Test()
    {
        Sut = new Day11();
    }

    public class SolveOne : Day11Test
    {
        [Fact]
        public void ShouldSolve()
        {
            #region input
            InputProvider
                .Setup(x => x.Read())
                .Returns(
                    new[]
                    {
                        "Monkey 0:",
                        "Starting items: 79, 98",
                        "Operation: new = old * 19",
                        "Test: divisible by 23",
                        "If true: throw to monkey 2",
                        "If false: throw to monkey 3",
                        "",
                        "Monkey 1:",
                        "Starting items: 54, 65, 75, 74",
                        "Operation: new = old + 6",
                        "Test: divisible by 19",
                        "If true: throw to monkey 2",
                        "If false: throw to monkey 0",
                        "",
                        "Monkey 2:",
                        "Starting items: 79, 60, 97",
                        "Operation: new = old * old",
                        "Test: divisible by 13",
                        "If true: throw to monkey 1",
                        "If false: throw to monkey 3",
                        "",
                        "Monkey 3:",
                        "Starting items: 74",
                        "Operation: new = old + 3",
                        "Test: divisible by 17",
                        "If true: throw to monkey 0",
                        "If false: throw to monkey 1"
                    }
                );
            #endregion
            var actual = Sut.SolveOne(InputProvider.Object);
            actual.Should().Be("10605");
        }
    }
}

public class MonkeyTest : Day10Test
{
    [Fact]
    public void ShouldParse()
    {
        InputProvider
            .Setup(x => x.Read())
            .Returns(
                new[]
                {
                    "Monkey 0:",
                    "  Starting items: 71, 86",
                    "  Operation: new = old * 13",
                    "  Test: divisible by 19",
                    "    If true: throw to monkey 6",
                    "    If false: throw to monkey 7"
                }
            );

        var actual = new Monkey(InputProvider.Object.Read());
        actual.Number.Should().Be(0);
        actual.Items.Should().Contain(71);
        actual.Items.Should().Contain(86);
        actual.Test(19).Should().BeTrue();
        actual.TrueMonkey.Should().Be(6);
        actual.FalseMonkey.Should().Be(7);
        actual.Operation(1).Should().Be(13);
    }

    [Theory]
    [InlineData("  Operation: new = old * old", 1)]
    [InlineData("  Operation: new = old * 13", 13)]
    public void ShouldParseOperation(string operation, int expected)
    {
        InputProvider
            .Setup(x => x.Read())
            .Returns(
                new[]
                {
                    "Monkey 0:",
                    "  Starting items: 71, 86",
                    $" {operation}",
                    "  Test: divisible by 19",
                    "    If true: throw to monkey 6",
                    "    If false: throw to monkey 7"
                }
            );

        var actual = new Monkey(InputProvider.Object.Read());
        actual.Operation(1).Should().Be(expected);
    }
}
