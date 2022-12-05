using Aoc2021.Day05;

namespace Aoc2021.Tests.Day05;

public class MapTest : BaseTest<Map>
{
    [Theory]
    [InlineData("5,5 -> 5,2", 5)]
    public void ShouldInstantiatePlot(string inputLine, int dims)
    {
        InputProvider
            .Setup(x => x.Read())
            .Returns(new[] {inputLine});

        var actual = new Map(InputProvider.Object);

        for (var i = 0; i < dims; i++)
        for (var j = 0; j < dims; j++)
            actual.Plot[i, j].Should().Be(0);
    }

    [Fact]
    public void ShouldPlotLine()
    {
        InputProvider
            .Setup(x => x.Read())
            .Returns(new[] {"2,2 -> 0,2 "});

        Map actual = new(InputProvider.Object);
        actual.Plot[0, 0].Should().Be(0);
        actual.Plot[0, 1].Should().Be(0);
        actual.Plot[2, 1].Should().Be(0);
        actual.Plot[1, 1].Should().Be(0);
        actual.Plot[2, 2].Should().Be(1);
        actual.Plot[1, 2].Should().Be(1);
        actual.Plot[0, 2].Should().Be(1);
    }

    [Fact]
    public void ShouldPlotLines()
    {
        InputProvider
            .Setup(x => x.Read())
            .Returns(
                new[]
                {
                    "0,9 -> 5,9",
                    "8,0 -> 0,8",
                    "9,4 -> 3,4",
                    "2,2 -> 2,1",
                    "7,0 -> 7,4",
                    "6,4 -> 2,0",
                    "0,9 -> 2,9",
                    "3,4 -> 1,4",
                    "0,0 -> 8,8",
                    "5,5 -> 8,2"
                }
            );

        Map actual = new(InputProvider.Object);
        actual.Plot[0, 0].Should().Be(0);
        actual.Plot[0, 1].Should().Be(0);
        actual.Plot[0, 9].Should().Be(2);
        actual.Plot[1, 9].Should().Be(2);
        actual.Plot[2, 9].Should().Be(2);
        actual.Plot[3, 9].Should().Be(1);
        actual.Plot[2, 1].Should().Be(1);
        actual.Plot[4, 9].Should().Be(1);
        actual.Plot[3, 9].Should().Be(1);
        actual.Plot[7, 4].Should().Be(2);
    }
}