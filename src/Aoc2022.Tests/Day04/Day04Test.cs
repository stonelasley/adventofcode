namespace Aoc2022.Tests.Day04;

using Aoc2022.Day04;

public class Day04Test : BaseTest<Day04>
{
    public Day04Test()
    {
        Sut = new Day04();
    }

    public class SolveOne : Day04Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider.Setup(x => x.Read()).Returns(new[]
            {
                "2-4,6-8",
                "2-3,4-5",
                "5-7,7-9",
                "2-8,3-7",
                "6-6,4-6",
                "2-6,4-8"
            });
            string actual = Sut.SolveOne(InputProvider.Object);
            actual.Should().Be("2");
        }
    }

    public class SolveTwo : Day04Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider.Setup(x => x.Read()).Returns(new[]
            {
                "5-7,7-9",
                "2-8,3-7",
                "6-6,4-6",
                "2-6,4-8"
            });
            string actual = Sut.SolveTwo(InputProvider.Object);
            actual.Should().Be("4");
        }
    }

    public class GetElfTeams : Day04Test
    {
        [Fact]
        public void ShouldParseInput()
        {
            InputProvider.Setup(x => x.Read()).Returns(new[]
            {
                "2-4,6-8",
                "2-3,4-5",
                "5-7,7-9"
            });
            List<ElfTeam> actual = Sut.GetElfTeams(InputProvider.Object);
            actual.Count.Should().Be(3);
        }
    }
}