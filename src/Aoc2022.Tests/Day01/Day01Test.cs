namespace Aoc2022.Tests;

using Day01;

public class Day01Test : BaseTest<Day01>
{
    public Day01Test()
    {
        Sut = new Day01(InputProvider.Object);
    }

    public class GetCaloriesByElf : Day01Test
    {

        [Fact]
        public void ShouldGroupCalories()
        {
            InputProvider.Setup(x => x.ReadAllText()).Returns("1000\n1000\n\n1000");

            var actual = Sut.GetCaloriesByElf();
            actual.Count().Should().Be(2);
            actual.First().Should().Be(2000);
            actual.Last().Should().Be(1000);

        }
        
        
    }
    
    public class GetMost : Day01Test
    {

        [Fact]
        public void ShouldGetHighest()
        {
            
            InputProvider.Setup(x => x.ReadAllText()).Returns("1000\n1000\n\n1000");

            var actual = Sut.GetMost();
            actual.Should().Be(2000);

        }
        
        
    }
    
    public class GetTopThree: Day01Test
    {

        [Fact]
        public void ShouldGetTopThree()
        {
            InputProvider.Setup(x => x.ReadAllText()).Returns("1000\n\n2000\n\n3000\n\n4000");

            var actual = Sut.GetTopThree();
            actual.Should().Be(9000);

        }
        
        
    }
}