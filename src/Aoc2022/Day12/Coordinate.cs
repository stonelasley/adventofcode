namespace Aoc2022.Day12;

public record Coordinate(int Row, int Col)
{
    public Coordinate Up => new(Row - 1, Col);
    public Coordinate Down => new(Row + 1, Col);
    public Coordinate Right => new(Row, Col + 1);
    public Coordinate Left => new(Row, Col - 1);

    public List<Coordinate> Adjascents()
    {
        return new List<Coordinate>() { Up, Right, Down, Left };
    }
}