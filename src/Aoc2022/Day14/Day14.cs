namespace Aoc2022.Day14;

public class Day14 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        Cave cave = Cave.Parse(inputProvider.Read());
        do { }
        while (cave.DropSand());

        return cave.SettledSand.Count.ToString();
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        return "";
    }
}