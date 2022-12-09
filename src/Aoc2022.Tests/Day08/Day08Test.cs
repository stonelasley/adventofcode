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

    [Fact]
    public void ShouldSolveTwo()
    {
        InputProvider
            .Setup(x => x.Read())
            .Returns(new[] { "30373", "25512", "65332", "33549", "35390" });

        var actual = Sut.SolveTwo(InputProvider.Object);
        actual.Should().Be("8");
    }
}

public class TreePatchCounterTest
{
    List<List<int>> Input =
        new()
        {
            new() { 3, 0, 3, 7, 3 },
            new() { 2, 5, 5, 1, 2 },
            new() { 6, 5, 3, 3, 2 },
            new() { 3, 3, 5, 4, 9 },
            new() { 3, 5, 3, 9, 0 }
        };

    [Fact]
    public void ShouldCountPerimiter()
    {
        var actual = TreeCounter.CountPerimiter(Input);
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
        var height = Input.ElementAt(y).ElementAt(x);
        var actual = TreeCounter.IsVisibleFromLeft(Input, height, x, y);
        actual.Should().Be(expectedVisibility);
    }

    [Theory]
    [InlineData(3, 3, false)] // 4
    [InlineData(2, 2, false)] // 3
    [InlineData(2, 1, true)] // 5
    [InlineData(0, 2, true)] // 6
    public void ShouldDetermineVisibilityFromRight(int x, int y, bool expectedVisibility)
    {
        var height = Input.ElementAt(y).ElementAt(x);
        var actual = TreeCounter.IsVisibleFromRight(Input, height, x, y);
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
        var height = Input.ElementAt(y).ElementAt(x);
        var actual = TreeCounter.IsVisibleFromTop(Input, height, x, y);
        actual.Should().Be(expectedVisibility);
    }

    [Theory]
    [InlineData(2, 3, true)] // 5
    [InlineData(0, 2, true)] // 6
    [InlineData(1, 3, false)] // 3
    [InlineData(4, 3, true)] // 9
    public void ShouldDetermineVisibilityFromBottom(int x, int y, bool expectedVisibility)
    {
        var height = Input.ElementAt(y).ElementAt(x);
        var actual = TreeCounter.IsVisibleFromBottom(Input, height, x, y);
        actual.Should().Be(expectedVisibility);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(3, 4, 3)]
    [InlineData(2, 2, 1)]
    [InlineData(3, 3, 1)]
    public void ShouldDetermineScenicScoreFromLeft(int x, int y, int score)
    {
        var height = Input.ElementAt(y).ElementAt(x);
        var actual = TreeCounter.LeftScore(Input, height, x, y);
        actual.Should().Be(score);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(1, 2, 3)]
    [InlineData(2, 2, 1)]
    [InlineData(3, 3, 1)]
    [InlineData(3, 0, 1)]
    [InlineData(3, 4, 1)]
    public void ShouldDetermineScenicScoreFromRight(int x, int y, int score)
    {
        var height = Input.ElementAt(y).ElementAt(x);
        var actual = TreeCounter.ScoreRight(Input, height, x, y);
        actual.Should().Be(score);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(3, 4, 4)]
    [InlineData(0, 2, 2)]
    [InlineData(1, 2, 1)]
    public void ShouldDetermineScenicScoreFromTop(int x, int y, int score)
    {
        var height = Input.ElementAt(y).ElementAt(x);
        var actual = TreeCounter.TopScore(Input, height, x, y);
        actual.Should().Be(score);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(3, 3, 1)]
    [InlineData(0, 2, 2)]
    [InlineData(3, 0, 4)]
    public void ShouldDetermineScenicScoreFromBottom(int x, int y, int score)
    {
        var height = Input.ElementAt(y).ElementAt(x);
        var actual = TreeCounter.ScoreBottom(Input, height, x, y);
        actual.Should().Be(score);
    }
}
