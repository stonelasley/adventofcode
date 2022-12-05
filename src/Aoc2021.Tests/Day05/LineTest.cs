using System.Drawing;
using Aoc2021.Day05;

namespace Aoc2021.Tests.Day05;

public class LineTest : BaseTest<Line>
{
    [Theory]
    [InlineData("5,5 -> 8,2")]
    public void ShouldInstantiatePoints(string inputLine)
    {
        Line actual = new(inputLine);
        actual.Start.X.Should().Be(5);
        actual.Start.Y.Should().Be(5);
        actual.End.X.Should().Be(8);
        actual.End.Y.Should().Be(2);
    }


    [Theory]
    [InlineData("5,5 -> 8,2", 8, 5)]
    [InlineData("0,1 -> 1,0", 1, 1)]
    public void ShouldGetMaxX(string inputLine, int maxX, int maxY)
    {
        Line actual = new(inputLine);
        actual.MaxX.Should().Be(maxX);
        actual.MaxY.Should().Be(maxY);
    }

    [Theory]
    [InlineData("0,9 -> 5,9", true)]
    [InlineData("7,0 -> 7,4", false)]
    public void ShouldGetHorizontal(string inputLine, bool expected)
    {
        Line actual = new(inputLine);
        actual.IsHorizontal.Should().Be(expected);
    }

    [Theory]
    [InlineData("0,9 -> 5,9", false)]
    [InlineData("7,0 -> 7,4", true)]
    public void ShouldDetermineVertical(string inputLine, bool expected)
    {
        Line actual = new(inputLine);
        actual.IsVertical.Should().Be(expected);
    }

    [Theory]
    [InlineData("8,0 -> 0,8", true)]
    [InlineData("6,4 -> 2,0", true)]
    public void ShouldDetermineDiagonal(string inputLine, bool expected)
    {
        Line actual = new(inputLine);
        actual.IsDiagonal.Should().Be(expected);
    }

    public class IsPointOnLine : LineTest
    {
        [Theory]
        [InlineData("5,5 -> 8,2", 5, 5, true)]
        [InlineData("5,5 -> 8,2", 8, 2, true)]
        [InlineData("0,9 -> 9,9", 8, 9, true)]
        [InlineData("5,5 -> 8,2", 0, 0, false)]
        public void ShouldCalculatePointOnLine(string inputLine, int pointX, int pointY, bool isOnLine)
        {
            Point p = new(pointX, pointY);

            Line actual = new(inputLine);

            actual.IsPointOnLine(p).Should().Be(isOnLine);
        }
    }
}