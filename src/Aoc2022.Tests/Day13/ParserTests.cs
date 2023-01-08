namespace Aoc2022.Tests.Day13;

using Aoc2022.Day13;

public class ParserTests
{
    public class ParseNum
    {
        [Fact]
        public void ShuouldParseNumber()
        {
            Queue<char> data = "689,85]".ToCharQueue();
            int result = Parser.ParseNum(data);
            Assert.Equal(689, result);
            Assert.Equal(",85]", string.Join("", data));

            data = "85]".ToCharQueue();
            result = Parser.ParseNum(data);
            Assert.Equal(85, result);
            Assert.Equal("]", string.Join("", data));
        }
    }

    public class ParseList
    {
        [Fact]
        public void TestParseEmptyList()
        {
            Queue<char> input = "[]".ToCharQueue();
            List<object> expected = new();
            
            List<object> actual = Parser.ParseList(input);
            actual.Should().Equal(expected);
        }

        [Fact]
        public void TestParseSingleList()
        {
            Queue<char> input = "[1]".ToCharQueue();
            List<object> expected = new() { 1 };
            
            List<object> actual = Parser.ParseList(input);
            actual.Should().Equal(expected);
        }

        [Fact]
        public void ShouldParseUniformList()
        {
            Queue<char> input = "[1,71,98,547,2]".ToCharQueue();
            List<object> expected = new() { 1, 71, 98, 547, 2 };
            
            List<object> actual = Parser.ParseList(input);
            
            actual.Should().Equal(expected);
        }

        [Fact]
        public void ShouldParseMixedList()
        {
            Queue<char> input = "[1, [71, 98],547 ,[2, 3]]".ToCharQueue(
                StringSplitOptions.RemoveEmptyEntries
            );
            List<object> expected =
                new()
                {
                    1,
                    new List<object>() { 71, 98 },
                    547,
                    new List<object>() { 2, 3 }
                };
            
            List<object> actual = Parser.ParseList(input);
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldParseNestedList()
        {
            Queue<char> input = "[[1, [2, [3]]]]".ToCharQueue(StringSplitOptions.RemoveEmptyEntries);
            List<object> expected =
                new()
                {
                    new List<object>()
                    {
                        1,
                        new List<object>()
                        {
                            2,
                            new List<object>() { 3 }
                        },
                    }
                };
            
            List<object> actual = Parser.ParseList(input);
            
            Assert.Equal(expected, actual);
        }
    }
}
