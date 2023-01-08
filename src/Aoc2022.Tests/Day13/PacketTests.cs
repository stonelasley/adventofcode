namespace Aoc2022.Tests.Day13;

using Aoc2022.Day13;

public class PacketTests
{
    public class ListToString
    {

        [Theory]
        [InlineData("[]", new object[] {})]
        [InlineData("[1]", new object[] {1})]
        [InlineData("[1, 2, 3, 4]", new object[] {1, 2, 3, 4 })]
        public void ShouldParse(string expected, object[] input)
        {
            Assert.Equal(expected, Packets.ListToString(input.ToList()));
        }
        
        [Fact]
        public void ShouldParseMixed()
        {
            List<object> input =
                new()
                {
                    1,
                    new List<object>() { 2, 3, 4 },
                    5,
                    new List<object>() { 6, 7 },
                };
            Assert.Equal("[1, [2, 3, 4], 5, [6, 7]]", Packets.ListToString(input));
        }
    }

    public class CompareElements
    {
        [Theory]
        [InlineData(100, 100, 0)]
        [InlineData(50, 75, -1)]
        [InlineData(360, -50, 1)]
        public void ShouldCompare(int left, int right, int expected)
        {
            Packets.CompareElements(left, right).Should().Be(expected);
        }

        [Theory]
        [InlineData("[1,1,3,1,1]", "[1,1,5,1,1]", -1)]
        [InlineData("[[1],[2,3,4]]", "[[1],4]", -1)]
        [InlineData("[9]", "[[8,7,6]]", 1)]
        [InlineData("[7,7,7,7]", "[7,7,7]", 1)]
        [InlineData("[]", "[3]", -1)]
        [InlineData("[[[]]]", "[[]]", 1)]
        [InlineData("[1,[2,[3,[4,[5,6,7]]]],8,9]", "[1,[2,[3,[4,[5,6,0]]]],8,9]]", 1)]
        public void ShouldCompareList(string left, string right, int expected)
        {
            var leftList = Parser.ParseList(left.ToCharQueue());
            var rightList = Parser.ParseList(right.ToCharQueue());
            Packets.CompareLists(leftList, rightList).Should().Be(expected);
        }
    }

    public class CompareString
    {
        
        [Theory]
        [InlineData("[1,1,3,1,1]", "[1,1,5,1,1]", -1)]
        [InlineData("[[1],[2,3,4]]", "[[1],4]", -1)]
        [InlineData("[9]", "[[8,7,6]]", 1)]
        [InlineData("[7,7,7,7]", "[7,7,7]", 1)]
        [InlineData("[]", "[3]", -1)]
        [InlineData("[[[]]]", "[[]]", 1)]
        [InlineData("[1,[2,[3,[4,[5,6,7]]]],8,9]", "[1,[2,[3,[4,[5,6,0]]]],8,9]]", 1)]
        public void ShouldCompareStrings(string left, string right, int expected)
        {
            Packets.CompareStrings(left, right).Should().Be(expected);
        }
    }
}
