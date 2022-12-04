namespace Aoc2022.Tests.Day04;

using Aoc2022.Day04;

public class ElfTeamTest : BaseTest<ElfTeamTest>
{
    [Theory]
    [InlineData("2-4", "6-8", 2, 4, 6, 8)]
    [InlineData("2-3", "4-5", 2, 3, 4, 5)]
    [InlineData("5-7", "7-9", 5, 7, 7, 9)]
    public void ShouldParseAssignments(string rangeOne, string rangeTwo, int expectedOneStart, int expectedOneEnd,
        int expectedTwoStart, int expectedTwoEnd)
    {
        ElfTeam sut = new(rangeOne, rangeTwo);
        sut.Should().NotBe(null);

        sut.RangeOne.Start.Value.Should().Be(expectedOneStart);
        sut.RangeOne.End.Value.Should().Be(expectedOneEnd);
        sut.RangeTwo.Start.Value.Should().Be(expectedTwoStart);
        sut.RangeTwo.End.Value.Should().Be(expectedTwoEnd);
    }

    [Theory]
    [InlineData("2-5", "3-4", true)]
    [InlineData("2-5", "2-5", true)]
    [InlineData("3-4", "2-5", false)]
    public void ShouldDetermineOneOverlap(string rangeOne, string rangeTwo, bool isOverlap)
    {
        ElfTeam sut = new(rangeOne, rangeTwo);
        sut.OneIsSuper.Should().Be(isOverlap);
    }

    [Theory]
    [InlineData("2-5", "3-4", false)]
    [InlineData("2-5", "2-5", true)]
    [InlineData("3-4", "2-5", true)]
    public void ShouldDetermineTwoOverlap(string rangeOne, string rangeTwo, bool isOverlap)
    {
        ElfTeam sut = new(rangeOne, rangeTwo);
        sut.TwoIsSuper.Should().Be(isOverlap);
    }

    [Theory]
    [InlineData("2-5", "3-4", true)]
    [InlineData("2-5", "2-5", true)]
    [InlineData("3-4", "2-5", true)]
    [InlineData("1-2", "3-5", false)]
    public void ShouldDetermineOverlap(string rangeOne, string rangeTwo, bool fullOverLap)
    {
        ElfTeam sut = new(rangeOne, rangeTwo);
        sut.HasFullOverlap.Should().Be(fullOverLap);
    }

    [Theory]
    [InlineData("5-7", "7-9", new[] {5, 6, 7}, new[] {7, 8, 9})]
    public void ShouldCreateArray(string rangeOne, string rangeTwo, int[] arrOne, int[] arrTwo)
    {
        ElfTeam sut = new(rangeOne, rangeTwo);
        sut.RangeOneArr.Should().Equal(arrOne);
        sut.RangeTwoArr.Should().Equal(arrTwo);
    }

    [Theory]
    [InlineData("5-7", "7-9", new[] {7})]
    [InlineData("2-8", "3-7", new[] {3, 4, 5, 6, 7})]
    [InlineData("6-6", "4-6", new[] {6})]
    [InlineData("2-6", "4-8", new[] {4, 5, 6})]
    [InlineData("6-6", "8-9", new int[] { })]
    public void ShouldDetermineIntersection(string rangeOne, string rangeTwo, int[] overlaps)
    {
        ElfTeam sut = new(rangeOne, rangeTwo);
        sut.InterSection.Should().Equal(overlaps);
    }
}