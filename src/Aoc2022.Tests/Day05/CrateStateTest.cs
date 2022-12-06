using Aoc2022.Day05;

namespace Aoc2022.Tests.Day05;

public class CrateStateTest
{
    [Theory]
    [InlineData("1   2   3 ", 3)]
    [InlineData("1   2   3   4   5   6   7   8   9", 9)]
    public void ShouldInstantiate(string input, int expected)
    {
        CrateState sut = new(input);
        sut.Stacks.Count().Should().Be(expected);
    }

    [Fact]
    public void ShouldIntializeState()
    {
        List<CrateLocationLine> crateLocations = new()
        {
            new CrateLocationLine("    [D]    "),
            new CrateLocationLine("[N] [C]    "),
            new CrateLocationLine("[Z] [M] [P]")
        };

        CrateState sut = new("1  2  3");
        sut.Initialize(crateLocations);
        sut.Stacks[0].Count.Should().Be(2);
        sut.Stacks[0].Peek().Should().Be('N');
        sut.Stacks[1].Count.Should().Be(3);
        sut.Stacks[1].Peek().Should().Be('D');
        sut.Stacks[2].Count.Should().Be(1);
        sut.Stacks[2].Peek().Should().Be('P');
    }

    [Fact]
    public void ShouldProcessTransfer()
    {
        List<CrateLocationLine> initialState = new()
        {
            new CrateLocationLine("    [D]    "),
            new CrateLocationLine("[N] [C]    "),
            new CrateLocationLine("[Z] [M] [P]")
        };

        CrateState sut = new("1  2  3");
        sut.Initialize(initialState);
        sut.ProcessTransfer(new TransferInstruction("move 1 from 2 to 1"));
        sut.ProcessTransfer(new TransferInstruction("move 3 from 1 to 3"));

        sut.Stacks[0].Count.Should().Be(0);
        //sut.Stacks[0].Peek().Should().Be('D');
        sut.Stacks[1].Count.Should().Be(2);
        sut.Stacks[1].Peek().Should().Be('C');
        sut.Stacks[2].Count.Should().Be(4);
        sut.Stacks[2].Peek().Should().Be('Z');
    }
}