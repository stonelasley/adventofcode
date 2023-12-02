namespace Aoc2022.Tests.Day12;

using Aoc2022.Day12;

public class ExplorerTest
{

    [Fact]
    public void ShouldInitialize()
    {
        
        int[,] elevations =
        {
            { 2, 1, 2, 4 },
            { 3, 0, 3, 5 },
            { 9, 2, 3, 4 }
        };
            
        int[,] distances =
        {
            { -1, -1, -1, -1 },
            { -1, 0, -1, -1 },
            { -1, -1, -1, -1 }
        };

        Grid terrain = new(elevations);
        Coordinate start = new(1, 1);
        Explorer explorer = new(terrain, start);
        Assert.Equal(distances, explorer.Distances);
        explorer.ExplorationQueue.Should().Contain(start);
        explorer.IsExploring().Should().BeTrue();
    }

    [Fact]
    public void ShouldExplore()
    {
        
        int[,] elevations =
        {
            { 2, 1, 2, 4 },
            { 3, 0, 3, 5 },
            { 9, 2, 3, 4 }
        };
        Grid terrain = new(elevations);
        Coordinate start = new(1, 1);
        Explorer explorer = new(terrain, start);
        explorer.ExplorationQueue.Should().Contain(start);
        explorer.ExplorationQueue.Count.Should().Be(1);
        explorer.IsExploring().Should().BeTrue();
        
        int[,] distances =
        {
            { -1, 1, -1, -1 },
            { -1, 0, -1, -1 },
            { -1, -1, -1, -1 }
        };

        Coordinate result = explorer.Explore();
        Coordinate expected = start;
        Assert.Equal(expected, result);
        Assert.Equal(distances, explorer.Distances);
        explorer.ExplorationQueue.Should().Contain(new Coordinate(0, 1));
        explorer.ExplorationQueue.Count.Should().Be(1);
        explorer.IsExploring().Should().BeTrue();
            
        distances = new [,]
        {
            { 2, 1, 2, -1 },
            { -1, 0, -1, -1 },
            { -1, -1, -1, -1 }
        };
            
        result = explorer.Explore();
        expected = new (0, 1);
        Assert.Equal(expected, result);
        Assert.Equal(distances, explorer.Distances);
        explorer.ExplorationQueue.Should().Contain(new Coordinate(0, 2));
        explorer.ExplorationQueue.Should().Contain(new Coordinate(0, 0));
        explorer.ExplorationQueue.Count.Should().Be(2);
        explorer.IsExploring().Should().BeTrue();
            
        distances = new [,]
        {
            { 2, 1, 2, -1 },
            { -1, 0, 3, -1 },
            { -1, -1, -1, -1 }
        };
            
        result = explorer.Explore();
        expected = new (0, 2);
        Assert.Equal(expected, result);
        Assert.Equal(distances, explorer.Distances);
        explorer.ExplorationQueue.Should().Contain(new Coordinate(0, 0));
        explorer.ExplorationQueue.Should().Contain(new Coordinate(1, 2));
        explorer.ExplorationQueue.Count.Should().Be(2);
        explorer.IsExploring().Should().BeTrue();
            
        distances = new [,]
        {
            { 2, 1, 2, -1 },
            { 3, 0, 3, -1 },
            { -1, -1, -1, -1 }
        };
            
        result = explorer.Explore();
        expected = new (0, 0);
        Assert.Equal(expected, result);
        Assert.Equal(distances, explorer.Distances);
        explorer.ExplorationQueue.Should().Contain(new Coordinate(1, 2));
        explorer.ExplorationQueue.Should().Contain(new Coordinate(1, 0));
        explorer.ExplorationQueue.Count.Should().Be(2);
        explorer.IsExploring().Should().BeTrue();
            
        distances = new [,]
        {
            {  2,  1,  2, -1 },
            {  3,  0,  3, -1 },
            { -1, -1,  4, -1 }
        };
            
        result = explorer.Explore();
        expected = new (1, 2);
        Assert.Equal(expected, result);
        Assert.Equal(distances, explorer.Distances);
        explorer.ExplorationQueue.Should().Contain(new Coordinate(1, 0));
        explorer.ExplorationQueue.Should().Contain(new Coordinate(2, 2));
        explorer.ExplorationQueue.Count.Should().Be(2);
        explorer.IsExploring().Should().BeTrue();
            
        distances = new [,]
        {
            {  2,  1,  2, -1 },
            {  3,  0,  3, -1 },
            { -1, -1,  4, -1 }
        };
            
        result = explorer.Explore();
        expected = new (1, 0);
        Assert.Equal(expected, result);
        Assert.Equal(distances, explorer.Distances);
        explorer.ExplorationQueue.Should().Contain(new Coordinate(2, 2));
        explorer.ExplorationQueue.Count.Should().Be(1);
        explorer.IsExploring().Should().BeTrue();
        distances = new [,]
        {
            {  2,  1,  2, -1 },
            {  3,  0,  3, -1 },
            { -1,  5,  4,  5 }
        };
            
        result = explorer.Explore();
        expected = new (2, 2);
        Assert.Equal(expected, result);
        Assert.Equal(distances, explorer.Distances);
        explorer.ExplorationQueue.Should().Contain(new Coordinate(2, 3));
        explorer.ExplorationQueue.Should().Contain(new Coordinate(2, 1));
        explorer.ExplorationQueue.Count.Should().Be(2);
        explorer.IsExploring().Should().BeTrue();
    }
    
}