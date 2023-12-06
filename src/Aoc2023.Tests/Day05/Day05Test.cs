namespace Aoc2023.Tests.Day05;

using Aoc2023.Day05;

public class Day05Test : BaseTest<Day05>
{
    public Day05Test() => Sut = new Day05();

    public class SolveOne : Day05Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider.Setup(x => x.Read()).Returns(new[]
            {
                "seeds: 79 14 55 13",
                "",
                "seed-to-soil map:",
                "50 98 2",
                "52 50 48",
                "",
                "soil-to-fertilizer map:",
                "0 15 37",
                "37 52 2",
                "39 0 15",
                "",
                "fertilizer-to-water map:",
                "49 53 8",
                "0 11 42",
                "42 0 7",
                "57 7 4",
                "",
                "water-to-light map:",
                "88 18 7",
                "18 25 70",
                "",
                "light-to-temperature map:",
                "45 77 23",
                "81 45 19",
                "68 64 13",
                "",
                "temperature-to-humidity map:",
                "0 69 1",
                "1 0 69",
                "",
                "humidity-to-location map:",
                "60 56 37",
                "56 93 4"
            });
            string result = Sut.SolveOne(InputProvider.Object);
            result.Should().Be("35");
        }
    }

    public class SolveTwo : Day05Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider.Setup(x => x.Read()).Returns(new[] { "", "", });
            string result = Sut.SolveTwo(InputProvider.Object);
            result.Should().Be("unsolved");
        }
    }
}

public class MapperTest
{

    [Fact]
    public void ShouldInitialize()
    {
        string[] input =
        {
            "seed-to-soil map:",
            "50 98 2",
            "52 50 48 "
        };

        Mapper actual = new(input);
        actual.Name.Should().Be("seed-to-soil map:");


    }

    [Theory]
    [InlineData(79, 81)]
    [InlineData(14, 14)]
    [InlineData(55, 57)]
    [InlineData(13, 13)]
    public void ShouldMap(int seed, int expectedSoil)
    {
        string[] input =
        {
            "seed-to-soil map:",
            "50 98 2",
            "52 50 48 "
        };

        Mapper m = new(input);
        m.Map(seed).Should().Be(expectedSoil);


    }

}

public class MapSpecTest
{

    [Theory]
    [InlineData("50 98 2", 50)]
    [InlineData("52 50 48 ", 52)]
    public void ShouldInitialize(string input, int expectedDestination)
    {
        MapSpec actual = new(input);
        actual.DestinationStart.Should().Be(expectedDestination);


    }

}