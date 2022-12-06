namespace Aoc2021.Tests.Day05;

public class Day05Test : BaseTest<Aoc2021.Day05.Day05>
{
    public Day05Test()
    {
        Sut = new Aoc2021.Day05.Day05();
    }

    public class SolveOne : Day05Test
    {
        [Fact]
        public void ShouldSolve()
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

            string actual = Sut.SolveOne(InputProvider.Object);
            actual.Should().Be("5");
        }
    }

    public class SolveTwo : Day05Test
    {
        // [Fact]
        public void ShouldSolve()
        {
            InputProvider.Setup(x => x.Read()).Returns(new[]
            {
                ""
            });

            string actual = Sut.SolveTwo(InputProvider.Object);
            actual.Should().Be("1");
        }
    }
}