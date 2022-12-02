namespace Aoc2022.Day01;

public class Day01
{
    private readonly IInputProvider<Day01> _inputProvider;
    public Day01(IInputProvider<Day01> inputProvider)
    {
        _inputProvider = inputProvider;
    }

    public List<int> GetCaloriesByElf()
    {
        List<int> calsByElf = new ();
        List<string> inputs = _inputProvider.Read().ToList();

        var calories = 0;

        for (int i = 0; i < inputs.Count; i++)
        {
            var calInput = inputs[i];
            if (string.IsNullOrEmpty(calInput))
            {
                calsByElf.Add(calories);
                calories = 0;
                continue;
            }
            calories += Int32.Parse(calInput);
            if (i == inputs.Count - 1)
            {
                calsByElf.Add(calories);
            }
        }
        return calsByElf;

    }

    public int GetMost() => GetCaloriesByElf().Max();
    public int GetTopThree() => GetCaloriesByElf().OrderByDescending(x => x).Take(3).Sum();
    
}