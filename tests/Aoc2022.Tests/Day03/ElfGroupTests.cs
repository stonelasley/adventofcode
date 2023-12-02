namespace Aoc2022.Tests.Day03;

using Aoc2022.Day03;

public class ElfGroupTests
{
    [Fact]
    public void ShouldFindBadge()
    {
        var sut = new ElfGroup(new List<RuckSack>
        {
            new("vJrwpWtwJgWrhcsFMMfFFhFp"),
            new("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL"),
            new("PmmdzqPrVvPwwTWBwg")
        });

        var actual = sut.BadgeTotal;
        actual.Should().Be(18);
    }
}