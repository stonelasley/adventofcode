namespace Aoc2022.Day01;

public class Day01 : IDay
{
    public IEnumerable<int> GetCaloriesByElf(IInputProvider inputProvider)
    {
        var input = inputProvider.ReadAllText();
        return input.Split($"{Environment.NewLine}{Environment.NewLine}")
                    .Select(x => 
                        x.Trim()
                        .Split(Environment.NewLine)
                        .Select(int.Parse)
                        .Sum());
    }

    public string SolveOne(IInputProvider inputProvider) => GetCaloriesByElf(inputProvider).Max().ToString();
    public string SolveTwo(IInputProvider inputProvider) => GetCaloriesByElf(inputProvider).OrderByDescending(x => x).Take(3).Sum().ToString();
    
}