namespace Aoc2023.Day02;

public class Day02 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        Dictionary<string, int> maxCubes = new ()
        {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 }
        };
        return inputProvider.Read()
                            .Select(x => new Game(x, maxCubes))
                            .Where(x => x.IsPossible)
                            .Sum(x => x.Number)
                            .ToString();
    }

    public string SolveTwo(IInputProvider inputProvider) =>
        inputProvider.Read()
                     .Select(x => new Game(x))
                     .Select(g =>
                                  g.FindMax("red")
                                  * g.FindMax("green") * g.FindMax("blue"))
                     .Sum()
                     .ToString();


}