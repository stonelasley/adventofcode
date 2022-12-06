using Aoc2022.Day05;

namespace Aoc2022.Tests.Day05;

public class CrateLineTest
{
    [Theory]
    [InlineData("    [D]    ", 'D', 1)]
    [InlineData("[N] [C]    ", 'N', 0)]
    [InlineData("[Z] [M] [P]", 'P', 2)]
    [InlineData("[Z] [M] [P]", 'Z', 0)]
    [InlineData("[Z] [M] [P]", 'M', 1)]
    [InlineData("            [X]", 'X', 3)]
    public void ShouldParseCrate(string input, char crate, int index)
    {
        CrateLocationLine sut = new(input);
        sut.CrateLocations.First(x => x.Crate == crate).StackNumber.Should().Be(index);
    }
}