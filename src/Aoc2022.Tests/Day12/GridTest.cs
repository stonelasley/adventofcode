namespace Aoc2022.Tests.Day12;

using Aoc2022.Day12;

public class GridTest
{
    public class GetAdjascent: GridTest
    {
        [Fact]
        public void ShouldFind()
        {
            int[,] elevations =
            {
                { 0, 1, 0 },
                { 0, 0, 1 },
                { 0, 0, 0 },
            };

            Grid grid = new(elevations);
            Coordinate coord = new(1, 1);
            List<Coordinate> actual = grid.GetAdjascent(coord);
            List<Coordinate> expected =
                new() { coord.Up, coord.Right, coord.Down, coord.Left };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldFindNeighborsNoDirs()
        {
            int[,] elevations =
            {
                { 0, 2, 0 },
                { 2, 0, 2 },
                { 0, 2, 0 },
            };

            Grid map = new(elevations);
            Coordinate center = new(1, 1);
            List<Coordinate> actual = map.GetAdjascent(center);
            actual.Should().BeEmpty();
        }

        [Fact]
        public void ShouldRespectElevation()
        {
            int[,] elevations =
            {
                { 0, 9, 0 },
                { 3, 1, 2 },
                { 0, 0, 0 },
            };

            Grid map = new(elevations);
            Coordinate center = new(1, 1);
            List<Coordinate> actual = map.GetAdjascent(center);
            List<Coordinate> expected = new() { center.Right, center.Down };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldFindForCorners()
        {
            int[,] elevations =
            {
                { 0, 0, 0 },
                { 0, 0, 0 },
                { 0, 0, 0 },
            };

            Grid map = new(elevations);
            Coordinate pos = new(0, 0);
            List<Coordinate> actual = map.GetAdjascent(pos);
            List<Coordinate> expected = new() { pos.Right, pos.Down };
            Assert.Equal(expected, actual);

            pos = new(0, 2);
            actual = map.GetAdjascent(pos);
            expected = new() { pos.Down, pos.Left };
            Assert.Equal(expected, actual);

            pos = new(2, 0);
            actual = map.GetAdjascent(pos);
            expected = new() { pos.Up, pos.Right };
            Assert.Equal(expected, actual);

            pos = new(2, 2);
            actual = map.GetAdjascent(pos);
            expected = new() { pos.Up, pos.Left };
            Assert.Equal(expected, actual);

            pos = new(1, 1);
            actual = map.GetAdjascent(pos);
            expected = new() { pos.Up, pos.Right, pos.Down, pos.Left };
            Assert.Equal(expected, actual);
        }
    }
}