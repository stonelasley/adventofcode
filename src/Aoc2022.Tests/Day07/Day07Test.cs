namespace Aoc2022.Tests.Day07;

using Aoc2022.Day07;

public class Day07Test : BaseTest<Day07>
{
    public Day07Test()
    {
        Sut = new Day07();
    }

    [Fact]
    public void ShouldSolve()
    {
        InputProvider
            .Setup(x => x.Read())
            .Returns(
                new[]
                {
                    "$ cd /",
                    "$ ls",
                    "dir a",
                    "14848514 b.txt",
                    "8504156 c.dat",
                    "dir d",
                    "$ cd a",
                    "$ ls",
                    "dir e",
                    "29116 f",
                    "2557 g",
                    "62596 h.lst",
                    "$ cd e",
                    "$ ls",
                    "584 i",
                    "$ cd ..",
                    "$ cd ..",
                    "$ cd d",
                    "$ ls",
                    "4060174 j",
                    "8033020 d.log",
                    "5626152 d.ext",
                    "7214296 k    "
                }
            );

        var actual = Sut.SolveOne(InputProvider.Object);
        actual.Should().Be("95437");
    }

    [Fact]
    public void ShouldSolveTwo()
    {
        InputProvider
            .Setup(x => x.Read())
            .Returns(
                new[]
                {
                    "$ cd /",
                    "$ ls",
                    "dir a",
                    "14848514 b.txt",
                    "8504156 c.dat",
                    "dir d",
                    "$ cd a",
                    "$ ls",
                    "dir e",
                    "29116 f",
                    "2557 g",
                    "62596 h.lst",
                    "$ cd e",
                    "$ ls",
                    "584 i",
                    "$ cd ..",
                    "$ cd ..",
                    "$ cd d",
                    "$ ls",
                    "4060174 j",
                    "8033020 d.log",
                    "5626152 d.ext",
                    "7214296 k    "
                }
            );

        var actual = Sut.SolveTwo(InputProvider.Object);
        actual.Should().Be("24933642");
    }
}
