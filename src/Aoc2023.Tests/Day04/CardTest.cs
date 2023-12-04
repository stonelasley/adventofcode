namespace Aoc2023.Tests.Day04;

using System.Collections;
using Aoc2023.Day04;

public class CardTest : Day04Test
{

    [Theory]
    [InlineData("Card   1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", "Card 1", 5, 8, 8)]
    [InlineData("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", "Card 3", 5, 8, 2)]
    [InlineData("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", "Card 5", 5, 8, 0)]
    public void ShouldInitialize(string input, string expectedName, int expectedWinners, int expectedActual,
                                 int expectedPoints)
    {
        Card result = new(input);
        result.Name.Should().Be(expectedName);
        result.WinningPool.Length.Should().Be(expectedWinners);
        result.Actual.Length.Should().Be(expectedActual);
        result.Points.Should().Be(expectedPoints);
    }

    public class CardDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new()
        {
            new object[]
            {
                new
                {
                    Expected = 0,
                    Lines = new []
                    {
                        "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
                        "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
                        "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
                        "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
                        "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
                        "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
                    }
                },
            }
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [Theory]
    [ClassData(typeof(CardDataGenerator))]
    public void ShouldInitializeWithWinningCards(dynamic input)
    {

        List<Card> cardStack = ((IEnumerable<string>)input.Lines).Select(inputLine => new Card(inputLine, input.Lines)).ToList();
        cardStack[0].Copies.Length.Should().Be(4);
        cardStack[0].Copies.Where(x => x.Name == "Card 3").Count().Should().Be(1);
        cardStack[0].Copies.Where(x => x.Name == "Card 4").Count().Should().Be(1);
        cardStack[0].Copies.Where(x => x.Name == "Card 2").First().Copies.Count().Should().Be(2);
        cardStack[1].Copies.Length.Should().Be(2);
        cardStack[1].Copies.Where(x => x.Name == "Card 4").Count().Should().Be(1);
        cardStack[5].Copies.Length.Should().Be(0);
        cardStack.Sum(x => x.Count).Should().Be(30);
    }
}