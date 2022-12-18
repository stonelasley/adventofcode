namespace Aoc2022.Tests.Day12;

using Aoc2022.Day12;

public class CoordinateTest
{
    [Fact]
    public void ShouldFindNeighbors()
    {
        Coordinate sut = new Coordinate(0, 0);

        List<Coordinate> actual = sut.Adjascents();

        actual.Should().HaveCount(4);
        actual.ElementAt(0).Row.Should().Be(-1);
        actual.ElementAt(0).Col.Should().Be(0);

        actual.ElementAt(1).Row.Should().Be(0);
        actual.ElementAt(1).Col.Should().Be(1);

        actual.ElementAt(2).Row.Should().Be(1);
        actual.ElementAt(2).Col.Should().Be(0);

        actual.ElementAt(3).Row.Should().Be(0);
        actual.ElementAt(3).Col.Should().Be(-1);

        sut = new Coordinate(3, 2);

        actual = sut.Adjascents();

        actual.Count.Should().Be(4);
        actual.ElementAt(0).Row.Should().Be(2);
        actual.ElementAt(0).Col.Should().Be(2);

        actual.ElementAt(1).Row.Should().Be(3);
        actual.ElementAt(1).Col.Should().Be(3);

        actual.ElementAt(2).Row.Should().Be(4);
        actual.ElementAt(2).Col.Should().Be(2);

        actual.ElementAt(3).Row.Should().Be(3);
        actual.ElementAt(3).Col.Should().Be(1);
    }
}