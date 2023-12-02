namespace Aoc2022.Tests.Day05;

using Aoc2022.Day05;

public class TransferInstructionTest
{
    [Theory]
    [InlineData("move 1 from 2 to 1", 1, 2, 1)]
    [InlineData("move 3 from 1 to 3", 3, 1, 3)]
    [InlineData("move 2 from 2 to 1", 2, 2, 1)]
    [InlineData("move 1 from 1 to 2", 1, 1, 2)]
    public void ShouldParseInstruction(string input, int crate, int start, int destination)
    {
        TransferInstruction sut = new(input);
        sut.CrateNumber.Should().Be(crate);
        sut.StartPosition.Should().Be(start);
        sut.Destination.Should().Be(destination);
    }
}