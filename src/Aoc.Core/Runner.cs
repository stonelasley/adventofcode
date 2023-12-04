namespace Aoc.Core;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

[ExcludeFromCodeCoverage]
public static class Runner
{
    public static void Run(Assembly assembly, int upToDay = 25)
    {
        for (var i = 1; i <= 25; i++)
        {
            var dayName = $"Day{i.ToString("00")}";
            Console.WriteLine($"~~~~~~~~ Solving Day {i.ToString("00")} ~~~~~~~~~~~");
            IDay? day = null;
            try
            {
                day = (IDay?)
                    Activator
                       .CreateInstance(
                            assembly.GetName().Name!,
                            $"{assembly.GetName().Name}.{dayName}.{dayName}"
                        )
                      ?.Unwrap();
            }
            catch (Exception)
            {
                Console.WriteLine($"Can't find class {dayName}");
                Console.WriteLine("Part One: Unsolved");
                Console.WriteLine("Part Two: Unsolved");
                continue;
            }
            Stopwatch sw = Stopwatch.StartNew();
            string partOneResult = day!.SolveOne(new InputReader(dayName));
            sw.Stop();
            Console.WriteLine($"Part One: {partOneResult} duration: {sw.Elapsed}");
            sw = Stopwatch.StartNew();
            string partTwoResult = day!.SolveTwo(new InputReader(dayName));
            sw.Stop();
            Console.WriteLine($"Part Two: {partTwoResult} duration: {sw.Elapsed}");
        }
    }
}