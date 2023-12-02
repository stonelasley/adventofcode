namespace Aoc2023.Day02;

public class Game
{
    public int Number { get; private set; }
    public List<CubeSet> Sets { get; set; } = new();

    public Game(string input, Dictionary<string, int>? maxCubes = null)
    {
        string[] gameSplit = input.Split(':', StringSplitOptions.TrimEntries);
        string gameNumber = gameSplit[0].Split(' ', StringSplitOptions.TrimEntries)[1];
        Number = int.Parse(gameNumber);
        string[] cubeSets = gameSplit[1].Split(';', StringSplitOptions.TrimEntries);

        foreach (string cubeSet in cubeSets)
        {
            Sets.Add(new CubeSet(cubeSet, maxCubes));
        }
    }

    public bool IsPossible => Sets.All(x => x.Possible);
    public int FindMax(string color)
    {
        List<CubeCount> cubeCounts = Sets.SelectMany(x => x.CubeCounts.Where(x => x.Color == color)).ToList();
        
        if(!cubeCounts.Any()) return 0;
        
        return cubeCounts.Max(x => x.Count);
    } 

}