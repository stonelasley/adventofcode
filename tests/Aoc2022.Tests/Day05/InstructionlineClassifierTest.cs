namespace Aoc2022.Tests.Day05;

using Aoc2022.Day05;

public class InstructionLineClassifierTest
{
    [Theory]
    [InlineData("1   2   3 ", InputType.StackCount)]
    [InlineData(" 1   2   3   4   5   6   7   8   9", InputType.StackCount)]
    [InlineData("move 1 from 2 to 1", InputType.TransferInstruction)]
    [InlineData("move 3 from 1 to 3", InputType.TransferInstruction)]
    [InlineData("[N] [C]    ", InputType.CrateStackIndex)]
    [InlineData("[Z] [M] [P]", InputType.CrateStackIndex)]
    [InlineData("          ", InputType.Unknown)]
    public void ShouldClassify(string input, InputType expected)
    {
        InstructionLineClassifier.Classify(input).Should().Be(expected);
    }
}