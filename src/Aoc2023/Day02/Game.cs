namespace Aoc2023.Day02;

public class Game
{
    public int Number { get; private set; }
    public List<CubeSet> Sets { get; set; } = new();

    private readonly Dictionary<string, int> _maxCubes;
    public Game(string input, Dictionary<string, int> maxCubes)
    {
        _maxCubes = maxCubes;
        string[] gameSplit = input.Split(':', StringSplitOptions.TrimEntries);
        string gameNumber = gameSplit[0].Split(' ', StringSplitOptions.TrimEntries)[1];
        Number = int.Parse(gameNumber);
        string[] cubeSets = gameSplit[1].Split(';', StringSplitOptions.TrimEntries);

        foreach (string cubeSet in cubeSets)
        {
            Sets.Add(new CubeSet(cubeSet));
        }
    }

    public int PossibleCubeCount =>
    
        Sets.Count(x => x.IsPossible(_maxCubes));
   
}