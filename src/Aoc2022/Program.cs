using Aoc2022;


for (int i = 1; i <= 3; i++)
{
    string dayName = $"Day{i.ToString("00")}";
    
    IDay day = (IDay)Activator.CreateInstance(null, $"Aoc2022.{dayName}.{dayName}").Unwrap();
    Console.WriteLine($"~~~~~~~~ Solving Day {i.ToString("00")} ~~~~~~~~~~~");
    Console.WriteLine($"Part One: {day.SolveOne(new InputReader(dayName))}");
    Console.WriteLine($"Part Two: {day.SolveTwo(new InputReader(dayName))}");
}