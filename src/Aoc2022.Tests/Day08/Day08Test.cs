namespace Aoc2022.Tests.Day08;

using Aoc2022.Day08;

public class Day08Test : BaseTest<Day08>
{
    public Day08Test()
    {
        Sut = new Day08();
    }

    [Fact]
    public void ShouldSolve()
    {
        InputProvider
            .Setup(x => x.Read())
            .Returns(new[] { "30373", "25512", "65332", "33549", "35390" });

        var actual = Sut.SolveOne(InputProvider.Object);
        actual.Should().Be("21");
    }

    //[Fact]
    public void ShouldSolveTwo()
    {
        InputProvider
            .Setup(x => x.Read())
            .Returns(new[] { "30373", "25512", "65332", "33549", "35390" });

        var actual = Sut.SolveTwo(InputProvider.Object);
        actual.Should().Be("-1");
    }
}

public class TreePatchCounterTest : BaseTest<TreePatchCounter>
{
    public TreePatchCounterTest()
    {
        Sut = new TreePatchCounter();
    }

    [Fact]
    public void ShouldCountPerimiter()
    {
        List<List<int>> input =
            new()
            {
                new() { 3, 0, 3, 7, 3 },
                new() { 2, 5, 5, 1, 2 },
                new() { 6, 5, 3, 3, 2 },
                new() { 3, 3, 5, 4, 9 },
                new() { 3, 5, 3, 9, 0 }
            };

        var actual = Sut.CountPerimiter(input);
        actual.Should().Be(16);
    }

    [Theory]
    [InlineData(1, 1, true)]
    [InlineData(1, 2, false)]
    [InlineData(2, 2, false)]
    [InlineData(3, 2, false)]
    [InlineData(3, 3, false)]
    public void ShouldDetermineVisibilityFromLeft(int x, int y, bool expectedVisibility)
    {
        List<List<int>> input =
            new()
            {
                new() { 3, 0, 3, 7, 3 },
                new() { 2, 5, 5, 1, 2 },
                new() { 6, 5, 3, 3, 2 },
                new() { 3, 3, 5, 4, 9 },
                new() { 3, 5, 3, 9, 0 }
            };

        var height = input.ElementAt(y).ElementAt(x);
        var actual = Sut.VisibleFromLeft(input, height, x, y);
        actual.Should().Be(expectedVisibility);
    }

    [Theory]
    [InlineData(3, 3, false)] // 4
    [InlineData(2, 2, false)] // 3
    [InlineData(2, 1, true)] // 5
    [InlineData(0, 2, true)] // 6
    public void ShouldDetermineVisibilityFromRight(int x, int y, bool expectedVisibility)
    {
        List<List<int>> input =
            new()
            {
                new() { 3, 0, 3, 7, 3 },
                new() { 2, 5, 5, 1, 2 },
                new() { 6, 5, 3, 3, 2 },
                new() { 3, 3, 5, 4, 9 },
                new() { 3, 5, 3, 9, 0 }
            };

        var height = input.ElementAt(y).ElementAt(x);
        var actual = Sut.VisibleFromRight(input, height, x, y);
        actual.Should().Be(expectedVisibility);
    }

    [Theory]
    [InlineData(1, 1, true)] // 5
    [InlineData(2, 1, true)] // 5
    [InlineData(3, 1, false)] // 1
    [InlineData(3, 3, false)] // 4
    [InlineData(3, 2, false)] // 5
    [InlineData(4, 3, true)] // 9
    public void ShouldDetermineVisibilityFromTop(int x, int y, bool expectedVisibility)
    {
        List<List<int>> input =
            new()
            {
                new() { 3, 0, 3, 7, 3 },
                new() { 2, 5, 5, 1, 2 },
                new() { 6, 5, 3, 3, 2 },
                new() { 3, 3, 5, 4, 9 },
                new() { 3, 5, 3, 9, 0 }
            };

        var height = input.ElementAt(y).ElementAt(x);
        var actual = Sut.VisibleFromTop(input, height, x, y);
        actual.Should().Be(expectedVisibility);
    }

    [Theory]
    [InlineData(2, 3, true)] // 5
    [InlineData(0, 2, true)] // 6
    [InlineData(1, 3, false)] // 3
    [InlineData(4, 3, true)] // 9
    public void ShouldDetermineVisibilityFromBottom(int x, int y, bool expectedVisibility)
    {
        List<List<int>> input =
            new()
            {
                new() { 3, 0, 3, 7, 3 },
                new() { 2, 5, 5, 1, 2 },
                new() { 6, 5, 3, 3, 2 },
                new() { 3, 3, 5, 4, 9 },
                new() { 3, 5, 3, 9, 0 }
            };

        var height = input.ElementAt(y).ElementAt(x);
        var actual = Sut.VisibleFromBottom(input, height, x, y);
        actual.Should().Be(expectedVisibility);
    }
}
