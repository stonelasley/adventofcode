namespace Aoc2023.Tests.Day03;

using Aoc2023.Day03;

public class SchematicItemTest : Day03Test
{
    [Theory]
    [InlineData(0, "467", 0, 0, 2, false, false, true, false, 467)]
    [InlineData(1, "*", 3, 3, 3, false, true, false, true, null)]
    [InlineData(1, "%", 3, 3, 3, false, true, false, false, null)]
    [InlineData(1, "#", 3, 3, 3, false, true, false, false, null)]
    [InlineData(1, "_", 3, 3, 3, true, false, false, false, null)]
    [InlineData(1, "", 3, 3, 3, true, false, false, false, null)]
    [InlineData(9, "655", 7, 7, 9, false, false, true, false, 655)]
    public void ShouldInitialize(
        int lineNumber,
        string inputValue,
        int inputIndex,
        int expectedStartIndex,
        int expectedEndIndex,
        bool expectedIsEmpty,
        bool expectedIsSymbol,
        bool expectedIsNumber,
        bool expectedIsStar,
        int? expectedNumberValue
    )
    {
        var actual = new SchematicItem(lineNumber, inputValue, inputIndex);
        actual.LineNumber.Should().Be(lineNumber);
        actual.Value.Should().Be(inputValue);
        actual.Index.Should().Be(expectedStartIndex);
        actual.IsEmpty.Should().Be(expectedIsEmpty);
        actual.EndIndex.Should().Be(expectedEndIndex);
        actual.IsSymbol.Should().Be(expectedIsSymbol);
        actual.IsNumber.Should().Be(expectedIsNumber);
        actual.IsStar.Should().Be(expectedIsStar);
        actual.NumberValue.Should().Be(expectedNumberValue);
    }
}
