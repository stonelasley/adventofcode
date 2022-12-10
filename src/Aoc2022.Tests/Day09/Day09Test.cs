namespace Aoc2022.Tests.Day09;

using Aoc2022.Day09;

public class Day09Test : BaseTest<Day09>
{
    public Day09Test()
    {
        Sut = new Day09();
    }

    public class ShouldSolveOne : Day09Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider
                .Setup(x => x.Read())
                .Returns(new[] { "R 4", "U 4", "L 3", "D 1", "R 4", "D 1", "L 5", "R 2" });

            var actual = Sut.SolveOne(InputProvider.Object);
            actual.Should().Be("13");
        }
    }

    public class ShouldSolveTwo : Day09Test
    {
        //[Fact]
        public void ShouldSolve()
        {
            InputProvider.Setup(x => x.Read()).Returns(new[] { "" });

            var actual = Sut.SolveTwo(InputProvider.Object);
            actual.Should().Be("9000");
        }
    }
}

public class CoursePlotterTest : Day09Test
{
    [Fact]
    public void ShouldTrackLocations()
    {
            InputProvider
                .Setup(x => x.Read())
                .Returns(new[] { "R 4", "U 4", "L 3", "D 1", "R 4", "D 1", "L 5", "R 2" });
            List<DirectionInstruction> instructions =  Sut.GetInstructions(InputProvider.Object);

            MoveHistoryies actual = CoursePlotter.Navigate(instructions);
            actual.HeadHistory.Should().Contain(new Point(0, 0));
            actual.HeadHistory.Should().Contain(new Point(4, 0));
            actual.HeadHistory.Should().Contain(new Point(4, 4));
            actual.HeadHistory.Should().Contain(new Point(1, 4));
            actual.HeadHistory.Should().Contain(new Point(1, 3));
            actual.HeadHistory.Should().Contain(new Point(5, 3));
            actual.HeadHistory.Should().Contain(new Point(5, 2));
            actual.HeadHistory.Should().Contain(new Point(0, 2));
            actual.HeadHistory.Should().Contain(new Point(2, 2));
    }
    
    [Fact]
    public void ShouldTrackIntermediateLocations()
    {
            InputProvider
                .Setup(x => x.Read())
                .Returns(new[] { "R 4", "U 4", "L 3", "D 1", "R 4", "D 1", "L 5", "R 2" });
            List<DirectionInstruction> instructions =  Sut.GetInstructions(InputProvider.Object);

            MoveHistoryies actual = CoursePlotter.Navigate(instructions);
            actual.HeadHistory.Should().Contain(new Point(0, 0)); //  explicit
            actual.HeadHistory.Should().Contain(new Point(1, 0));
            actual.HeadHistory.Should().Contain(new Point(2, 0));
            actual.HeadHistory.Should().Contain(new Point(3, 0));
            actual.HeadHistory.Should().Contain(new Point(4, 0)); //  explicit
            actual.HeadHistory.Should().Contain(new Point(4, 1));
            actual.HeadHistory.Should().Contain(new Point(4, 2));
            actual.HeadHistory.Should().Contain(new Point(4, 3));
            actual.HeadHistory.Should().Contain(new Point(4, 4)); //  explicit
            actual.HeadHistory.Should().Contain(new Point(3, 4)); 
            actual.HeadHistory.Should().Contain(new Point(2, 4)); 
            actual.HeadHistory.Should().Contain(new Point(1, 4)); //  explicit
            actual.HeadHistory.Should().Contain(new Point(1, 3)); //  explicit
            actual.HeadHistory.Should().Contain(new Point(2, 3)); 
            actual.HeadHistory.Should().Contain(new Point(3, 3)); 
            actual.HeadHistory.Should().Contain(new Point(4, 3));
            actual.HeadHistory.Should().Contain(new Point(5, 3)); //  explicit
            actual.HeadHistory.Should().Contain(new Point(5, 2)); //  explicit
            actual.HeadHistory.Should().Contain(new Point(4, 2));
            actual.HeadHistory.Should().Contain(new Point(3, 2));
            actual.HeadHistory.Should().Contain(new Point(2, 2));
            actual.HeadHistory.Should().Contain(new Point(1, 2));
            actual.HeadHistory.Should().Contain(new Point(0, 2)); //  explicit
            actual.HeadHistory.Should().Contain(new Point(1, 2));
            actual.HeadHistory.Should().Contain(new Point(2, 2)); //  explicit
    }
   
}