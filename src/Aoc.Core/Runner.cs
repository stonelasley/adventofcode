using System.Reflection;

namespace Aoc.Core;

public static class Runner
{
    public static void Run(Assembly assembly, int upToDay = 25)
    {
        for (int i = 1; i <= 25; i++)
        {
            string dayName = $"Day{i.ToString("00")}";
            Console.WriteLine($"~~~~~~~~ Solving Day {i.ToString("00")} ~~~~~~~~~~~");
            IDay? day = null;
            try
            {
                day = (IDay?) Activator.CreateInstance(assembly.GetName().Name!, $"{assembly.GetName().Name}.{dayName}.{dayName}")
                    ?.Unwrap();
            }
            catch (Exception)
            {
                Console.WriteLine($"Can't find class {dayName}");
                Console.WriteLine($"Part One: Unsolved");
                Console.WriteLine($"Part Two: Unsolved");
                continue;
            }

            Console.WriteLine($"Part One: {day!.SolveOne(new InputReader(dayName))}");
            Console.WriteLine($"Part Two: {day!.SolveTwo(new InputReader(dayName))}");
        }
    }
}