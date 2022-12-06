namespace Aoc2022.Day01;

public class Day01 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        return GetCaloriesByElf(inputProvider).Max().ToString();
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        return GetCaloriesByElf(inputProvider).OrderByDescending(x => x).Take(3).Sum().ToString();
    }

    public IEnumerable<int> GetCaloriesByElf(IInputProvider inputProvider)
    {
        var input = inputProvider.ReadAllText();
        return input
            .Split(
                $"{Environment.NewLine}{Environment.NewLine}",
                StringSplitOptions.RemoveEmptyEntries
            )
            .Select(x => x.Split(Environment.NewLine).Select(int.Parse).Sum());
    }
}
