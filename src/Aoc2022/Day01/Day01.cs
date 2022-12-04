namespace Aoc2022.Day01;

public class Day01 : IDay
{
    public IEnumerable<int> GetCaloriesByElf(IInputProvider inputProvider)
    {
        var input = inputProvider.ReadAllText();
        return input.Split("\n\n").Select(x => x.Trim().Split('\n').Select(int.Parse).Sum());
    }

    public int SolveOne(IInputProvider inputProvider) => GetCaloriesByElf(inputProvider).Max();
    public int SolveTwo(IInputProvider inputProvider) => GetCaloriesByElf(inputProvider).OrderByDescending(x => x).Take(3).Sum();
    
}