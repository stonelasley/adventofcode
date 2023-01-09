namespace Aoc2022.Day14;

public record Position(int X, int Y)
{
    public Position Down => new Position(X, Y + 1);
    public Position DownLeft => new Position(X - 1, Y + 1);
    public Position DownRight => new Position(X + 1, Y + 1);

    public static Position Parse(string input)
    {
        int[] parts = input.Split(',', StringSplitOptions.TrimEntries).Select(int.Parse).ToArray();
        return new Position(parts[0], parts[1]);
    }

    public static HashSet<Position> BuildSegment(string input)
    {
        var ends = input
            .Split(" -> ", StringSplitOptions.TrimEntries)
            .Select(Parse)
            .ToList()
            .ToHashSet();
        
        return BuildSegment(ends.First(), ends.Last());
    }

    public static HashSet<Position> BuildSegment(Position start, Position end)
    {
        HashSet<Position> segments = new() { start };
        while (start != end)
        {
            int xDiff = Math.Sign(end.X - start.X);
            int yDiff = Math.Sign(end.Y - start.Y);
            start = new Position(start.X + xDiff, start.Y + yDiff);
            segments.Add(start);
        }
        return segments;
    }
}