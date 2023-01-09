namespace Aoc2022.Tests.Day14;

using Aoc2022.Day14;

public class SandTest
{
    public class Fall
    {
        [Fact]
        public void ShouldFall()
        {
            string[] rows = { "498,4 -> 498,6 -> 496,6", "503,4 -> 502,4 -> 502,9 -> 494,9", };

            Cave cave = Cave.Parse(rows);

            //  "......+...",
            //  "..........",
            //  "..........",
            //  "..........",
            //  "....#...##",
            //  "....#...#.",
            //  "..###...#.",
            //  "........#.",
            //  "........#.",
            //  "#########."

            Sand s = new Sand(new Position(500, 0), cave);
            s.Fall().Should().BeTrue();
            s.Position.Should().Be(new Position(500, 1));
            s.Fall().Should().BeTrue();
            s.Position.Should().Be(new Position(500, 2));
            s.Fall().Should().BeTrue();
            s.Position.Should().Be(new Position(500, 3));
            s.Fall().Should().BeTrue();
            s.Position.Should().Be(new Position(500, 4));
            s.Fall().Should().BeTrue();
            s.Position.Should().Be(new Position(500, 5));
            s.Fall().Should().BeTrue();
            s.Position.Should().Be(new Position(500, 6));
            s.Fall().Should().BeTrue();
            s.Position.Should().Be(new Position(500, 7));
            s.Fall().Should().BeTrue();
            s.Position.Should().Be(new Position(500, 8));
            s.Fall().Should().BeFalse();
            s.Position.Should().Be(new Position(500, 8));

            cave.SettledSand.Add(s.Position);
            
            //0 "......+...",
            //1 "..........",
            //2 "..........",
            //3 "..........",
            //4 "....#...##",
            //5 "....#...#.",
            //6 "..###...#.",
            //7 "........#.",
            //8 "......o.#.",
            //9 "#########."
            
            
            s = new Sand(new Position(500, 7), cave);
            Assert.True(s.Fall());
            Assert.Equal(s.Position,new Position(499, 8));
            Assert.False(s.Fall());
            cave.SettledSand.Add(s.Position);
            
            //0 "......+...",
            //1 "..........",
            //2 "..........",
            //3 "..........",
            //4 "....#...##",
            //5 "....#...#.",
            //6 "..###...#.",
            //7 "........#.",
            //8 ".....oo.#.",
            //9 "#########."
            
            
            s = new Sand(new Position(500, 7), cave);
            Assert.True(s.Fall());
            Assert.Equal(s.Position,new Position(501, 8));
            Assert.False(s.Fall());
            cave.SettledSand.Add(s.Position);
            
            //0 "......+...",
            //1 "..........",
            //2 "..........",
            //3 "..........",
            //4 "....#...##",
            //5 "....#...#.",
            //6 "..###...#.",
            //7 "........#.",
            //8 ".....ooo#.",
            //9 "#########."
            
            
            s = new Sand(new Position(500, 6), cave);
            Assert.True(s.Fall());
            Assert.Equal(s.Position,new Position(500, 7));
            Assert.False(s.Fall());
            cave.SettledSand.Add(s.Position);
        }
    }
}
