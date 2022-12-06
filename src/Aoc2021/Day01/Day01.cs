namespace Aoc2021.Day01;

public class Day01 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        var previous = int.MaxValue;
        var total = 0;
        foreach (var line in inputProvider.Read())
        {
            var current = int.Parse(line);
            if (current > previous)
                total += 1;

            previous = current;
        }

        return total.ToString();
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        var lines = inputProvider.Read().Select(int.Parse).ToArray();

        var previous = int.MaxValue;
        var total = 0;
        var iMax = lines.Count() - 3;

        for (var i = 0; i <= iMax; i++)
        {
            var currentWindow = lines[i] + lines[i + 1] + lines[i + 2];
            if (currentWindow > previous)
                total += 1;

            previous = currentWindow;
        }

        return total.ToString();
    }
}
