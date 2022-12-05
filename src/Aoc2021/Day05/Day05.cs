namespace Aoc2021.Day05;

public class Day05 : IDay
{
    public int SolveOne(IInputProvider inputProvider)
    {
        Map map = new(inputProvider);
        var count = 0;
        for (int i = 0; i < map.Dimension; i++)
        {
            count += map.Plot.GetRow(i).Where(x => x > 1).Count();
        }

        return count;
    }

    public int SolveTwo(IInputProvider inputProvider)
    {
        return -1;
    }
}