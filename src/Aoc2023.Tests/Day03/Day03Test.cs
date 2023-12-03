namespace Aoc2023.Tests.Day03;

using System.Collections;
using Aoc2023.Day03;

public class Day03Test : BaseTest<Day03>
{
    public Day03Test() => Sut = new Day03();

    public class SolveOne : Day03Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider
                .Setup(x => x.Read())
                .Returns(
                    new[]
                    {
                        "467..114..",
                        "...*......",
                        "..35..633.",
                        "......#...",
                        "617*......",
                        ".....+.58.",
                        "..592.....",
                        "......755.",
                        "...$.*....",
                        ".664.598.."
                    }
                );
            string result = Sut.SolveOne(InputProvider.Object);
            result.Should().Be("4361");
        }
    }

    public class SolveTwo : Day03Test
    {
        [Fact]
        public void ShouldSolve()
        {
            InputProvider.Setup(x => x.Read()).Returns(new[]
            {
                
                        "467..114..",
                        "...*......",
                        "..35..633.",
                        "......#...",
                        "617*......",
                        ".....+.58.",
                        "..592.....",
                        "......755.",
                        "...$.*....",
                        ".664.598.."
                
            });
            string result = Sut.SolveTwo(InputProvider.Object);
            result.Should().Be("467835");
        }
    }

    public class ParseLine : Day03Test
    {
        [Theory]
        [InlineData("..........", 10, -1, "")]
        [InlineData("...*......", 10, 3, "*" )]
        [InlineData("467*......", 8, 0, "467")]
        [InlineData("467*......", 8, 1, "*")]
        [InlineData("*467......", 8, 0, "*")]
        [InlineData("*467......", 8, 1, "467")]
        [InlineData("467*617...", 6, 0, "467")]
        [InlineData("467*617...", 6, 1, "*")]
        [InlineData("467*617...", 6, 2, "617")]
        [InlineData("1.1.1.1.1.", 10, 4, "1")]
        [InlineData("467..114..", 6, 3, "114")]
        public void ShouldParseLine(string inputLine, int expectedLength, int checkIndex, string expectedVal)
        {
            var result = Sut.ParseLine(0, inputLine);
            result.Count.Should().Be(expectedLength);
            if (checkIndex >= 0)
            {
                result[checkIndex].Value.Should().Be(expectedVal);
            }
        }
    }

    public class TestDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                new
                {
                    Expected = 617,
                    TargetLine = 0,
                    Lines = new[] { "617*......" }
                }
            },
            new object[]
            {
                new
                {
                    Expected = 617,
                    TargetLine = 0,
                    Lines = new[] { "...*617..." }
                }
            },
          new object[]
          {
              new
              {
                  Expected = 0,
                  TargetLine = 0,
                  Lines = new[] { "617......." }
              },
          },
          new object[]
          {
              new
              {
                  Expected = 617,
                  TargetLine = 1,
                  Lines = new[]
                  {
                      "*.........",
                      "617......."
                  }
              },
          },
          new object[]
          {
              new
              {
                  Expected = 617,
                  TargetLine = 1,
                  Lines = new[]
                  {
                      "...*......",
                      "617......."
                  }
              },
          },
          new object[]
          {
              new
              {
                  Expected = 617,
                  TargetLine = 0,
                  Lines = new[]
                  {
                      "617.......",
                      "*........."
                  }
              },
          },
          new object[]
          {
              new
              {
                  Expected = 617,
                  TargetLine = 0,
                  Lines = new[]
                  {
                      "617.......",
                      "...*......"
                  }
              },
          },
          new object[]
          {
              new
              {
                  Expected = 0,
                  TargetLine = 0,
                  Lines = new[]
                  {
                      "617.......",
                      "..........",
                      "*........."
                  }
              },
          },
          new object[]
          {
              new
              {
                  Expected = 0,
                  TargetLine = 0,
                  Lines = new[]
                  {
                      "617.......",
                      "....*.....",
                  }
              },
          },
          new object[]
          {
              new
              {
                  Expected = 0,
                  TargetLine = 0,
                  Lines = new[]
                  {
                      ".*........",
                      "...617...."
                  }
              },
          }
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ParsePartNumbers : Day03Test
    {
        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void ShouldExtractNumbers(dynamic input)
        {
            List<SchematicNumber> testData = new();
            for (int i = 0; i < input.Lines.Length; i++)
            {
                testData.AddRange(Sut.ParseLine(i, input.Lines[i]));
            }
            int result = Sut.ParsePartNumbers(input.TargetLine, testData);
            result.Should().Be(input.Expected);
        }
    }
}

public class SchematicNumberTest : Day03Test
{
    [Theory]
    [InlineData(0, "467", 0, 0, 2, false, false, true)]
    [InlineData(1, "*", 3, 3, 3, false, true, false)]
    [InlineData(1, "%", 3, 3, 3, false, true, false)]
    [InlineData(1, "#", 3, 3, 3, false, true, false)]
    [InlineData(1, "_", 3, 3, 3, true, false, false)]
    [InlineData(1, "", 3, 3, 3, true, false, false)]
    [InlineData(9, "655", 7, 7, 9, false, false, true)]
    public void ShouldInitialize(
        int lineNumber,
        string inputValue,
        int inputIndex,
        int expectedStartIndex,
        int expectedEndIndex,
        bool expectedIsEmpty,
        bool expectedIsSymbol,
        bool expectedIsNumber
    )
    {
        var actual = new SchematicNumber(lineNumber, inputValue, inputIndex);
        actual.LineNumber.Should().Be(lineNumber);
        actual.Value.Should().Be(inputValue);
        actual.Index.Should().Be(expectedStartIndex);
        actual.IsEmpty.Should().Be(expectedIsEmpty);
        actual.EndIndex.Should().Be(expectedEndIndex);
        actual.IsSymbol.Should().Be(expectedIsSymbol);
        actual.IsNumber.Should().Be(expectedIsNumber);
    }
}
