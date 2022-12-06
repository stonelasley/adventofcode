namespace Aoc2021.Day05;

public class Day05 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        Map map = new(inputProvider);
        var count = 0;
        for (var i = 0; i < map.Dimension; i++)
            count += map.Plot.GetRow(i).Where(x => x > 1).Count();

        return count.ToString();
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        return "";
    }
}
