namespace Aoc2022.Tests;

using Day04;

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
            InputProvider.Setup(x => x.Read()).Returns(new []
            {
                "2-4,6-8",
                "2-3,4-5",
                "5-7,7-9",
                "2-8,3-7",
                "6-6,4-6",
                "2-6,4-8"
            });
            int actual = Sut.SolveOne(InputProvider.Object);
            actual.Should().Be(2);

        }
    }

    public class SolveTwo : Day04Test
    {
        
        [Fact]
        public void ShouldDo()
        {
            var actual = Sut.SolveOne(InputProvider.Object);
            actual.Should().NotBe(null);
        }
    }
    
    public class GetElfTeams: Day04Test
    {
        [Fact]
        public void ShouldParseInput()
        {
            InputProvider.Setup(x => x.Read()).Returns(new []
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

public class ElfTeamTest : BaseTest<ElfTeamTest>
{
    
        [Theory]
        [InlineData("2-4", "6-8", 2, 4, 6, 8)]
        [InlineData("2-3", "4-5", 2, 3, 4, 5)]
        [InlineData("5-7", "7-9", 5, 7, 7, 9)]
        public void ShouldParseAssignments(string rangeOne, string rangeTwo, int expectedOneStart, int expectedOneEnd, int expectedTwoStart, int expectedTwoEnd)
        {
            ElfTeam sut = new (rangeOne, rangeTwo);
            sut.Should().NotBe(null);

            sut.RangeOne.Start.Value.Should().Be(expectedOneStart);
            sut.RangeOne.End.Value.Should().Be(expectedOneEnd);
            sut.RangeTwo.Start.Value.Should().Be(expectedTwoStart);
            sut.RangeTwo.End.Value.Should().Be(expectedTwoEnd);
        }
        
        [Theory]
        [InlineData("2-5", "3-4", true)]
        [InlineData("2-5", "2-5", true)]
        [InlineData("3-4", "2-5", false)]
        public void ShouldDetermineOneOverlap(string rangeOne, string rangeTwo, bool isOverlap)
        {
            ElfTeam sut = new (rangeOne, rangeTwo);
            sut.OneIsSuper.Should().Be(isOverlap);
        }
        
        [Theory]
        [InlineData("2-5", "3-4", false)]
        [InlineData("2-5", "2-5", true)]
        [InlineData("3-4", "2-5", true)]
        public void ShouldDetermineTwoOverlap(string rangeOne, string rangeTwo, bool isOverlap)
        {
            ElfTeam sut = new (rangeOne, rangeTwo);
            sut.TwoIsSuper.Should().Be(isOverlap);
        }
        
        [Theory]
        [InlineData("2-5", "3-4", true)]
        [InlineData("2-5", "2-5", true)]
        [InlineData("3-4", "2-5", true)]
        [InlineData("1-2", "3-5", false)]
        public void ShouldDetermineOverlap(string rangeOne, string rangeTwo, bool fullOverLap)
        {
            ElfTeam sut = new (rangeOne, rangeTwo);
            sut.HasFullOverlap.Should().Be(fullOverLap);
        }
}
