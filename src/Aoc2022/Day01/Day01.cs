namespace Aoc2022;

public class Day01
{
    private readonly IInputProvider<Day01> _inputProvider;
    private string _input;
    public Day01(IInputProvider<Day01> inputProvider)
    {
        _inputProvider = inputProvider;
    }

    public IEnumerable<int> GetCaloriesByElf()
    {
        _input ??= _inputProvider.ReadAllText();
        return _input.Split("\n\n").Select(x => x.Trim().Split('\n').Select(int.Parse).Sum());
    }

    public int GetMost() => GetCaloriesByElf().Max();
    public int GetTopThree() => GetCaloriesByElf().OrderByDescending(x => x).Take(3).Sum();
    
}