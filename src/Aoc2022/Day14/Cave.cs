namespace Aoc2022.Day14;

public record Cave(HashSet<Position> Rocks, int BottomY)
{
    public static readonly Position Origin = new(500, 0);
    public HashSet<Position> SettledSand { get; } = new();
    
    public bool PositionIsOpen(Position p) => !SettledSand.Contains(p) && !Rocks.Contains(p);

    public bool DropSand()
    {
        Sand s = new (Origin, this);
        while (s.Fall())
        {
            if (IsFinished(s.Position))
            {
                return false;
            }
        }

        SettledSand.Add(s.Position);
        return true;
    }
    
    public bool IsFinished(Position p) => p.Y >= BottomY;

    public static Cave Parse(string[] input)
    {
        HashSet<Position> occupied = new();
        int bottomY = 0;
        foreach (var row in input)
        {
            string[] positions = row.Split("->", StringSplitOptions.TrimEntries);
            for (int i = 0; i < positions.Length - 1; i++)
            {
                Position start = Position.Parse(positions[i]);
                Position end = Position.Parse(positions[i + 1]);
                bottomY = Math.Max(bottomY, start.Y);
                bottomY = Math.Max(bottomY, end.Y);
                HashSet<Position> segment = Position.BuildSegment(start, end);
                occupied.UnionWith(segment);
            }
        }
        return new Cave(occupied, bottomY);
    }

    public string PrintWindow(Position topLeft, Position bottomRight)
    {
        StringBuilder cave = new();
        for (int y = topLeft.Y; y <= bottomRight.Y; y++)
        {
            for (int x = topLeft.X; x <= bottomRight.X; x++)
            {
                Position p = new(x, y);
                cave.Append(PositionToSymbo(p));
            }

            cave.Append("\n");
        }

        return cave.ToString().Trim();
    }

    private char PositionToSymbo(Position p)
    {
        if (SettledSand.Contains(p))
        {
            return 'o';
        }

        if (Rocks.Contains(p))
        {
            return '#';
        }

        if (p == Origin)
        {
            return '+';
        }
        return '.';
    }
}