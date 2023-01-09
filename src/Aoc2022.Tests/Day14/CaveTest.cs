namespace Aoc2022.Tests.Day14;

using Aoc2022.Day14;

public class CaveTest
{
    public class Parse
    {
        [Fact]
        public void ShouldParse()
        {
            string[] rows =
            {
                "498,4 -> 498,6 -> 496,6",
                "503,4 -> 502,4 -> 502,9 -> 494,9",
            };

            Cave cave = Cave.Parse(rows);
            string actual = cave.PrintWindow(new Position(494, 0), new Position(503, 9));

            string[] expected =
            {
                "......+...",
                "..........",
                "..........",
                "..........",
                "....#...##",
                "....#...#.",
                "..###...#.",
                "........#.",
                "........#.",
                "#########."
            };

            Assert.Equal(string.Join('\n', expected), actual);
        }
    }

    public class PrintWindow
    {
        [Fact]
        public void ShouldPrintInitialState()
        {
            string[] rows =
            {
                "......+...",
                "..........",
                "..........",
                "..........",
                "....#...##",
                "....#...#.",
                "..###...#.",
                "........#.",
                "........#.",
                "#########."
            };

            HashSet<Position> rocks = new();
            rocks.UnionWith(Position.BuildSegment("498,4 -> 498,6"));
            rocks.UnionWith(Position.BuildSegment("498,6 -> 496,6"));
            rocks.UnionWith(Position.BuildSegment("503,4 -> 502,4"));
            rocks.UnionWith(Position.BuildSegment("502,4 -> 502,9"));
            rocks.UnionWith(Position.BuildSegment("502,9 -> 494,9"));
            Cave cave = new(rocks, 9);

            var actual = cave.PrintWindow(new Position(494, 0), new Position(503, 9));
            var expected = string.Join("\n", rows);
            Assert.Equal(expected, actual);

            rows = new[]
            {
                "......+...",
                "..........",
                "..........",
                "..........",
                "....#...##",
                "....#...#.",
                "..###...#.",
                "........#.",
                "......o.#.",
                "#########."
            };

            cave.SettledSand.Add(new Position(500, 8));
            actual = cave.PrintWindow(new Position(494, 0), new Position(503, 9));
            expected = string.Join("\n", rows);
            Assert.Equal(expected, actual);

            rows = new[]
            {
                "......+...",
                "..........",
                "..........",
                "..........",
                "....#...##",
                "....#...#.",
                "..###...#.",
                "........#.",
                ".....oo.#.",
                "#########."
            };

            cave.SettledSand.Add(new Position(499, 8));
            actual = cave.PrintWindow(new Position(494, 0), new Position(503, 9));
            expected = string.Join("\n", rows);
            Assert.Equal(expected, actual);
        }
    }
}