namespace Aoc2023.Tests.Day01;

using Aoc2023.Day01;

public class Day01Test : BaseTest<Day01>
{
    public Day01Test() => Sut = new Day01();

    public class SolveOne : Day01Test
    {

        [Fact]
        public void ShouldSolve()
        {
            InputProvider.Setup(x => x.Read())
                         .Returns(
                              new[]
                              {
                                  "1abc2",
                                  "pqr3stu8vwx",
                                  "a1b2c3d4e5f",
                                  "treb7uchet"
                              }
                          );
            string result = Sut.SolveOne(InputProvider.Object);
            result.Should().Be("142");
        }
    }

    public class SolveTwo : Day01Test
    {

        [Fact]
        public void ShouldSolve()
        {
            InputProvider.Setup(x => x.Read())
                         .Returns(
                              new[]
                              {
                                  "two1nine",
                                  "eightwothree",
                                  "abcone2threexyz",
                                  "xtwone3four",
                                  "4nineeightseven2",
                                  "zoneight234",
                                  "7pqrstsixteen"
                              }
                          );
            string result = Sut.SolveTwo(InputProvider.Object);
            result.Should().Be("281");
        }
    }
} 