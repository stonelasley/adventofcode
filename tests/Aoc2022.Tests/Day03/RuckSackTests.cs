namespace Aoc2022.Tests.Day03;

using Aoc2022.Day03;

public class RuckSackTests
{
    [Theory]
    [InlineData("abcd", "ab", "cd")]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", "vJrwpWtwJgWr", "hcsFMMfFFhFp")]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "jqHRNqRjqzjGDLGL", "rsFMfFZSrLrFZsSL")]
    [InlineData("PmmdzqPrVvPwwTWBwg", "PmmdzqPrV", "vPwwTWBwg")]
    public void ShouldSplitContents(string input, string left, string right)
    {
        RuckSack sack = new(input);
        sack.Left.Should().Be(left);
        sack.Right.Should().Be(right);
    }

    [Theory]
    [InlineData("abad", 'a')]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", 'p')]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 'L')]
    [InlineData("PmmdzqPrVvPwwTWBwg", 'P')]
    public void ShouldGetCommon(string input, char common)
    {
        RuckSack sack = new(input);
        sack.CommonItem.Should().Be(common);
    }

    [Theory]
    [InlineData("abad", 1)]
    [InlineData("zbxz", 26)]
    [InlineData("AbAd", 27)]
    [InlineData("ZbXZ", 52)]
    public void ShouldPrioritizeCommon(string input, int priority)
    {
        RuckSack sack = new(input);
        sack.Priority.Should().Be(priority);
    }
}