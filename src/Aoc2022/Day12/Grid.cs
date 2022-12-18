namespace Aoc2022.Day12;

public record Grid(int[,] Heights)
{
    public int Rows => Heights.GetLength(0);
    public int Cols => Heights.GetLength(1);

    public List<Coordinate> GetAdjascent(Coordinate pos)
    {
        List<Coordinate> adjascent = new();
        foreach (var coord in pos.Adjascents())
        {
            if (IsAccessible(pos, coord))
            {
                adjascent.Add(coord);
            }
        }
        return adjascent;
    }

    public bool Contains(Coordinate pos) =>
        pos.Row >= 0 && pos.Col >= 0 && pos.Row < Rows && pos.Col < Cols;

    public bool IsAccessible(Coordinate from, Coordinate to)
    {
        if (!Contains(from) || !Contains(to))
        {
            return false;
        }

        int toHeight = Heights[to.Row, to.Col];
        int fromHeight = Heights[from.Row, from.Col];
        return toHeight <= fromHeight + 1;
    }
}