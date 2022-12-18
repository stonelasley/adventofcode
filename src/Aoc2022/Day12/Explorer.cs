namespace Aoc2022.Day12;

public class Explorer
{
    public Grid Map { get; }
    public Coordinate Start { get; }

    public Queue<Coordinate> ExplorationQueue { get; private set; }

    public int[,] Distances;

    public Explorer(Grid terrain, Coordinate start)
    {
        Map = terrain;
        Start = start;
        Distances = new int[Map.Rows, Map.Cols];

        for (int r = 0; r < Map.Rows; r++)
        {
            for (int c = 0; c < Map.Cols; c++)
            {
                Distances[r, c] = -1;
            }
        }

        Distances[Start.Row, Start.Col] = 0;
        ExplorationQueue = new();
        ExplorationQueue.Enqueue(Start);
    }

    public int DistanceTo(Coordinate pos)
    {
        return Distances[pos.Row, pos.Col];
    }

    public bool IsExploring() => ExplorationQueue.Any();

    public Coordinate Explore()
    {
        if (ExplorationQueue.Count == 0)
        {
            throw new Exception("Nothing left to explore");
        }

        Coordinate exploring = ExplorationQueue.Dequeue();
        foreach (var neighbor in Map.GetAdjascent(exploring))
        {
            if (Distances[neighbor.Row, neighbor.Col] == -1)
            {
                Distances[neighbor.Row, neighbor.Col] = Distances[exploring.Row, exploring.Col] + 1;
                ExplorationQueue.Enqueue(neighbor);
            }
        }
        return exploring;
    }
}
