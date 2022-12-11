namespace Aoc2022.Day10;

public class Day10 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        return $"{CathodRayTube.Execute(inputProvider.Read())}";
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        return "";
    }
}

public static class CathodRayTube
{
    public static int Execute(string[] inputs)
    {
        int sum = 1;
        int cycleCount = 0;
        int power = 0;
        foreach (string line in inputs)
        {
            Tick(ref cycleCount, ref power, sum);
            if (line.StartsWith("noop"))
            {
                continue;
            }
            Tick(ref cycleCount, ref power, sum);
            sum += int.Parse(line[4..]);
        }
        return power;
    }

    public static void Tick(ref int cycleCount, ref int power, int sum)
    {
        cycleCount++;
        if ((cycleCount - 20) % 40 == 0)
        {
            power += cycleCount * sum;
        }
    }
}
