namespace Aoc2022.Tests.Day10;

using Aoc2022.Day10;

public class CathodRayTests : Day10Test
{
    [Theory]
    [InlineData(1, 5, 5, 2, 5)]
    [InlineData(59, 40, 5, 60, 340)]
    public void ShouldIncrementCycle(
        int cycleCount,
        int power,
        int sum,
        int expectedCycleCount,
        int expectedPower
    )
    {
        CathodRayTube.Tick(ref cycleCount, ref power, sum);
        cycleCount.Should().Be(expectedCycleCount);
        power.Should().Be(expectedPower);
    }

    [Theory]
    [InlineData(1, 1, true)]
    [InlineData(5, 1, false)]
    public void PixelInFrameTest(int cycleCount, int spriteCol, bool expected)
    {
        var actual = CathodRayTube.PixelInFrame(cycleCount, spriteCol);
        actual.Should().Be(expected);

    }
    
    [Theory]
    [InlineData(1, 0, 2, 0)]
    [InlineData(39, 0, 0, 1)]
    public void ShouldIncrementAndChangeRows(
        int cycleCount,
        int currentRow,
        int expectedCycleCount,
        int expectedRow
    )
    {
        CathodRayTube.ScreenTick(ref cycleCount, ref currentRow);
        cycleCount.Should().Be(expectedCycleCount);
        currentRow.Should().Be(expectedRow);
    }
}