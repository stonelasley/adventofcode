namespace Aoc2023.Day06;

public class Day06 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        string[] input = inputProvider.Read();
        
        int[] times = ParseIntegers(input[0]);
        int[] distances = ParseIntegers(input[^1]);

        Race[] races = new Race[times.Length];
        for (int i = 0; i < times.Length; i++)
        {
            races[i] = new Race(times[i], distances[i]);
        }

        long totalWins = 1;

        foreach (Race r in races)
        {
            totalWins *= r.Wins;
        }

        return totalWins.ToString();
    }

    
    public string SolveTwo(IInputProvider inputProvider)
    {
        string[] input = inputProvider.Read();
        
        long time = ParseInteger(input[0]);
        long distance = ParseInteger(input[^1]);
        
        Race race = new (time, distance);
        
        return race.Wins.ToString();
        
    }
    
    static long ParseInteger(string line)
    {
        string afterColon = line.Split(':', 2, StringSplitOptions.TrimEntries)[1].Replace(" ", string.Empty);
        
        return long.Parse(afterColon);
    }
    static int[] ParseIntegers(string line)
    {
        string afterColon = line.Split(':', 2)[1];
        
        return afterColon
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
}
public class Race
{
        public long Wins { get; }
        public Race(Int64 time, Int64 distance)
        {
            for (int i = 0; i <= time; i++)
            {
                if (i * (time - i) > distance)
                {
                    Wins++;
                } 
            }
            
        } 
}
