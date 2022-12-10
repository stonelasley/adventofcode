namespace Aoc2022.Tests.Day09;

using Aoc2022.Day09;

public class CoursePlotterTest : Day09Test
{
    [Fact]
    public void ShouldTrackLocations()
    {
        InputProvider
            .Setup(x => x.Read())
            .Returns(new[] { "R 4", "U 4", "L 3", "D 1", "R 4", "D 1", "L 5", "R 2" });
        List<DirectionInstruction> instructions = Sut.GetInstructions(InputProvider.Object);

        List<List<Point>> actual = CoursePlotter.Navigate(2, instructions);
        actual.ElementAt(0).Should().Contain(new Point(0, 0));
        actual.ElementAt(0).Should().Contain(new Point(4, 0));
        actual.ElementAt(0).Should().Contain(new Point(4, 4));
        actual.ElementAt(0).Should().Contain(new Point(1, 4));
        actual.ElementAt(0).Should().Contain(new Point(1, 3));
        actual.ElementAt(0).Should().Contain(new Point(5, 3));
        actual.ElementAt(0).Should().Contain(new Point(5, 2));
        actual.ElementAt(0).Should().Contain(new Point(0, 2));
        actual.ElementAt(0).Should().Contain(new Point(2, 2));
    }

    [Fact]
    public void ShouldTrackIntermediateLocations()
    {
        InputProvider
            .Setup(x => x.Read())
            .Returns(new[] { "R 4", "U 4", "L 3", "D 1", "R 4", "D 1", "L 5", "R 2" });
        List<DirectionInstruction> instructions = Sut.GetInstructions(InputProvider.Object);

        List<List<Point>> actual = CoursePlotter.Navigate(2, instructions);
        actual.ElementAt(0).Should().Contain(new Point(0, 0)); //  explicit
        actual.ElementAt(0).Should().Contain(new Point(1, 0));
        actual.ElementAt(0).Should().Contain(new Point(2, 0));
        actual.ElementAt(0).Should().Contain(new Point(3, 0));
        actual.ElementAt(0).Should().Contain(new Point(4, 0)); //  explicit
        actual.ElementAt(0).Should().Contain(new Point(4, 1));
        actual.ElementAt(0).Should().Contain(new Point(4, 2));
        actual.ElementAt(0).Should().Contain(new Point(4, 3));
        actual.ElementAt(0).Should().Contain(new Point(4, 4)); //  explicit
        actual.ElementAt(0).Should().Contain(new Point(3, 4));
        actual.ElementAt(0).Should().Contain(new Point(2, 4));
        actual.ElementAt(0).Should().Contain(new Point(1, 4)); //  explicit
        actual.ElementAt(0).Should().Contain(new Point(1, 3)); //  explicit
        actual.ElementAt(0).Should().Contain(new Point(2, 3));
        actual.ElementAt(0).Should().Contain(new Point(3, 3));
        actual.ElementAt(0).Should().Contain(new Point(4, 3));
        actual.ElementAt(0).Should().Contain(new Point(5, 3)); //  explicit
        actual.ElementAt(0).Should().Contain(new Point(5, 2)); //  explicit
        actual.ElementAt(0).Should().Contain(new Point(4, 2));
        actual.ElementAt(0).Should().Contain(new Point(3, 2));
        actual.ElementAt(0).Should().Contain(new Point(2, 2));
        actual.ElementAt(0).Should().Contain(new Point(1, 2));
        actual.ElementAt(0).Should().Contain(new Point(0, 2)); //  explicit
        actual.ElementAt(0).Should().Contain(new Point(1, 2));
        actual.ElementAt(0).Should().Contain(new Point(2, 2)); //  explicit
    }

    [Theory]
    [InlineData("R 4", 3, 0, 0)]
    [InlineData("R 4", 9, 0, 0)]
    [InlineData("R 8", 1, 8, 0)]
    [InlineData("R 8", 2, 7, 0)]
    [InlineData("R 10", 9, 1, 0)]
    [InlineData("U 10", 9, 0, 1)]
    public void ShouldCascadeThroughChain(string input, int itemNumber, int x, int y)
    {
        List<DirectionInstruction> instructions = new() { new(input) };

        List<List<Point>> actual = CoursePlotter.Navigate(9, instructions);
        actual.ElementAt(itemNumber - 1).Should().Contain(new Point(x, y));
    }
}
