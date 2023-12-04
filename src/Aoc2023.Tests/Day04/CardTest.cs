namespace Aoc2023.Tests.Day04;

using Aoc2023.Day04;

public class CardTest : Day04Test
{

    [Theory]
    [InlineData("Card   1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 8)]
    [InlineData("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", 2)]
    [InlineData("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", 0)]
    public void ShouldInitialize(string input, int expectedPoints)
    {
        Card result = new(input);
        result.Points.Should().Be(expectedPoints);
    }
}