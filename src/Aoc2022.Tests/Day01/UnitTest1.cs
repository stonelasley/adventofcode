namespace Aoc2022.Tests.Day01;

using System.Linq;
using Aoc2022.Day01;

public class Day01Test
{
    protected Mock<IInputProvider<Day01>> InputProvider = new();
    protected Day01 Sut;

    public Day01Test()
    {
        Sut = new Day01(InputProvider.Object);
    }

    public class GetCaloriesByElf : Day01Test
    {

        [Fact]
        public void ShouldGroupCalories()
        {
            InputProvider.Setup(x => x.Read(null)).Returns(new []
            {
                "1000",
                "1000",
                "",
                "1000",
            });

            var actual = Sut.GetCaloriesByElf();
            actual.Count.Should().Be(2);
            actual.First().Should().Be(2000);
            actual.Last().Should().Be(1000);

        }
        
        
    }
    
    public class GetMost : Day01Test
    {

        [Fact]
        public void ShouldGetHighest()
        {
            InputProvider.Setup(x => x.Read(null)).Returns(new []
            {
                "1000",
                "1000",
                "",
                "1000",
            });

            var actual = Sut.GetMost();
            actual.Should().Be(2000);

        }
        
        
    }
    
    
    public class GetTopThree: Day01Test
    {

        [Fact]
        public void ShouldGetTopThree()
        {
            InputProvider.Setup(x => x.Read(null)).Returns(new []
            {
                "1000",
                "",
                "2000",
                "",
                "3000",
                "",
                "4000",
            });

            var actual = Sut.GetTopThree();
            actual.Should().Be(9000);

        }
        
        
    }
}