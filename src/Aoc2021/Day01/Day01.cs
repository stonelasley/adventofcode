namespace Aoc2021.Day01;

public class Day01 : IDay
{
    public int SolveOne(IInputProvider inputProvider)
    {
        int previous = int.MaxValue;
        int total = 0;
        foreach (var line in inputProvider.Read())
        {
            int current = int.Parse(line);
            if (current > previous)
            {
                total += 1;
            }

            previous = current;
        }

        return total;
    }

    public int SolveTwo(IInputProvider inputProvider)
    {
        int[] lines = inputProvider.Read().Select(int.Parse).ToArray();

        int previous = int.MaxValue;
        int total = 0;
        var iMax = lines.Count() - 3;

        for (int i = 0; i <= iMax; i++) {
    
            int currentWindow = lines[i] + lines[i+1] + lines[i+2];
            if (currentWindow > previous)
            {
                total += 1;
            }

            previous = currentWindow;
        }
        return total;
    }
}
