namespace Aoc2022.Tests.Day05;

public class Day05Test : BaseTest<Aoc2022.Day05.Day05>
{
    public Day05Test()
    {
        Sut = new Aoc2022.Day05.Day05();
    }

    [Fact]
    public void ShouldSolveOne()
    {
        InputProvider.Setup(x => x.Read())
            .Returns(new[]
            {
                "     [D]    ",
                " [N] [C]    ",
                " [Z] [M] [P]",
                "  1   2   3 ",
                "",
                "move 1 from 2 to 1",
                "move 3 from 1 to 3",
                "move 2 from 2 to 1",
                "move 1 from 1 to 2"
            });

        var actual = Sut.SolveOne(InputProvider.Object);
        actual.Should().Be(1);
    }
}