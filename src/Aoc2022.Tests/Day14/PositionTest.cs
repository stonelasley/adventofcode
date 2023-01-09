namespace Aoc2022.Tests.Day14;

using Aoc2022.Day14;

public class PositionTest
{
    public class Parse
    {
        [Theory]
        [InlineData("1,2", 1, 2)]
        [InlineData("0,0", 0, 0)]
        [InlineData("490,63", 490, 63)]
        public void ShouldParse(string input, int expectedX, int expectedY)
        {
            Position actual = Position.Parse(input);

            actual.Should().Be(new Position(expectedX, expectedY));
        }
    }

    public class Down
    {
        [Theory]
        [InlineData("1,2", 1, 3)]
        [InlineData("0,0", 0, 1)]
        [InlineData("490,63", 490, 64)]
        public void ShouldReturnPosition(string input, int expectedX, int expectedY)
        {
            Position position = Position.Parse(input);
            Position actual = position.Down;

            actual.Should().Be(new Position(expectedX, expectedY));
        }
    }

    public class DownLeft
    {
        [Theory]
        [InlineData("1,2", 0, 3)]
        [InlineData("0,0", -1, 1)]
        [InlineData("490,63", 489, 64)]
        public void ShouldReturnPosition(string input, int expectedX, int expectedY)
        {
            Position position = Position.Parse(input);
            Position? actual = position.DownLeft;
            actual.Should().Be(new Position(expectedX, expectedY));
        }
    }

    public class DownRight
    {
        [Theory]
        [InlineData("1,2", 2, 3)]
        [InlineData("0,0", 1, 1)]
        [InlineData("490,63", 491, 64)]
        public void ShouldReturnPosition(string input, int expectedX, int expectedY)
        {
            Position position = Position.Parse(input);
            Position actual = position.DownRight;
            actual.Should().Be(new Position(expectedX, expectedY));
        }
    }

    public class BuildSegment
    {
        [Theory]
        [InlineData("498,6 -> 498,4", 3, "498,5")]
        [InlineData("498,6 -> 496,6", 3, "497,6")]
        public void ShouldParseString( string input, int expectedSegments, string contains)
        {
            var segments = Position.BuildSegment(input);
            segments.Should().HaveCount(expectedSegments);
            segments.Should().Contain(Position.Parse(contains));
        }

        [Theory]
        [InlineData("498,6", "498,4", "498,5")]
        [InlineData("498,6", "496,6", "497,6")]
        public void ShouldPopulate(string start, string end, string contains)
        {
            Position p0 = Position.Parse(start);
            Position p1 = Position.Parse(contains);
            Position p2 = Position.Parse(end);

            var actual = Position.BuildSegment(p0, p2);

            actual.Should().Contain(p1);
        }
    }
}