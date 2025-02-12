namespace Aoc2023.Tests.Day07;

using Aoc2023.Day07;

public class Day07Test : BaseTest<Day07>
{
    public Day07Test() => Sut = new Day07();

    public class SolveOne : Day07Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider
                .Setup(x => x.Read())
                .Returns([
                    "32T3K 765",
                    "T55J5 684",
                    "KK677 28",
                    "KTJJT 220",
                    "QQQJA 483"
                ]);
            string result = Sut.SolveOne(InputProvider.Object);
            result.Should().Be("6440");
        }
    }

    public class SolveTwo : Day07Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider
                .Setup(x => x.Read())
                .Returns([
                    "32T3K 765",
                    "T55J5 684",
                    "KK677 28",
                    "KTJJT 220",
                    "QQQJA 483"
                ]);
            string result = Sut.SolveTwo(InputProvider.Object);
            result.Should().Be("UnSolved");
        }
    }

    public class HandTest : Day07Test
    {
        [Theory]
        [InlineData("32T3K 765", 765)]
        [InlineData("AAAAA 123", 123)]
        public void ShouldParseInput(string input, int expectedBid)
        {
            Hand hand = new(input);
            hand.Bid.Should().Be(expectedBid);
            hand.Cards.Count.Should().Be(5);
        }
        [Theory]
        [InlineData("3245K 0", 0, 13)]
        [InlineData("AAAAA 0", 6, 14)]
        [InlineData("2AAAA 0", 5, 14)]
        [InlineData("A2222 0", 5, 2)]
        [InlineData("23AAA 0", 3, 14)]
        [InlineData("KA333 0", 3, 3)]
        [InlineData("234AA 0", 1, 14)]
        [InlineData("AK44T 0", 1, 4)]
        [InlineData("222AA 0", 4, 2)]
        [InlineData("22AAA 0", 4, 14)]
        [InlineData("223AA 0", 2, 14)]
        public void ShouldCategorizeHandType(string input, int expectedHandType, int expectedScore)
        {
            HandResult expectedResult = new((HandType)expectedHandType, expectedScore);
            Hand hand = new(input);
            hand.Result.Should().BeEquivalentTo(expectedResult);
        }
    }

    public class CardTest : Day07Test
    {

        [Theory]
        [InlineData('2', 2)]
        [InlineData('3', 3)]
        [InlineData('4', 4)]
        [InlineData('5', 5)]
        [InlineData('6', 6)]
        [InlineData('7', 7)]
        [InlineData('8', 8)]
        [InlineData('9', 9)]
        [InlineData('T', 10)]
        [InlineData('J', 11)]
        [InlineData('Q', 12)]
        [InlineData('K', 13)]
        [InlineData('A', 14)]
        public void ShouldParseInput(char input, int expected)
        {
            Card card = new (input);
            card.Score.Should().Be(expected);
        }
    }
}