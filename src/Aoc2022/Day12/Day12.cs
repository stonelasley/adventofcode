namespace Aoc2022.Day12;

public class Day12 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        Solver solver = new (inputProvider.Read(), 'S', 'E');
        Explorer explorer = new (solver.Grid, solver.Start);
        while (explorer.IsExploring())
        {
            Coordinate currentLoc = explorer.Explore();
            if (currentLoc == solver.End)
            {
                return $"{explorer.DistanceTo(currentLoc)}";
            }
        }
        return "";
    }
    
    public string SolveTwo(IInputProvider inputProvider)
    {
        List<int> distances = new();
        Solver solver = new (inputProvider.Read(), 'S', 'E');
        foreach (var start in solver.Starts)
        {
            Explorer explorer = new (solver.Grid, start);
            while (explorer.IsExploring())
            {
                Coordinate currentLoc = explorer.Explore();
                if (currentLoc == solver.End)
                {
                    distances.Add(explorer.DistanceTo(currentLoc));
                }
            }
        }
        return $"{distances.Min()}";
    }
}

public class Solver
{
    public List<Coordinate> Starts { get; } = new();
    public Coordinate Start { get; }
    public Coordinate End { get; }
    public Grid Grid { get; }

    public Solver(string[] rows, char startChar, char endChar)
    {
        int[,] heights = new int[rows.Length, rows[0].Length];
        for (int r = 0; r < rows.Length; r++)
        {
            for (int c = 0; c < rows[0].Length; c++)
            {
                char ch = rows[r][c];
                if (ch == startChar)
                {
                    Start = new Coordinate(r, c);
                }
                if (ch == endChar)
                {
                    End = new Coordinate(r, c);
                }
                if (ch == 'a')
                {
                    Starts.Add(new Coordinate(r, c));
                }

                heights[r, c] = CharHeight(ch);
            }
        }

        Grid = new(heights);
    }

    private static int CharHeight(char c)
    {
        return c switch
        {
            'E' => 'z' - 'a',
            'S' => '0',
            _ => c - 'a'
        };
    }
}
