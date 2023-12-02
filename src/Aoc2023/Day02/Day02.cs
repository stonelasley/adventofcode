namespace Aoc2023.Day02;

public class Day02 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        Dictionary<string, int> maxCubes = new Dictionary<string, int>()
        {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 }
        };
        var games = inputProvider.Read().Select(x => new Game(x, maxCubes)).ToList();
        var possibleGames = games.Where(x => x.PossibleCubeCount > 0);
        return $"{possibleGames.Sum(x => x.Number)}";
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        var input = inputProvider.Read();
        return "UnSolved";
    }
}