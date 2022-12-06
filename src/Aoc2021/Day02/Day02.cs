namespace Aoc2021.Day02;

public class Day02 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        IEnumerable<KeyValuePair<string, int>> lines = inputProvider.Read().Select(line =>
        {
            var pair = line.Split(' ');
            return new KeyValuePair<string, int>(pair[0], Int32.Parse(pair[1]));
        });

        int x = 0;
        int y = 0;

        foreach (var kvp in lines)
        {
            switch (kvp.Key)
            {
                case "up":
                    y -= kvp.Value;
                    break;
                case "down":
                    y += kvp.Value;
                    break;
                default:
                    x += kvp.Value;
                    break;
            }
        }
        return $"{x*y}";
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        IEnumerable<KeyValuePair<string, int>> lines = inputProvider.Read().Select(line =>
        {
            var pair = line.Split(' ');
            return new KeyValuePair<string, int>(pair[0], Int32.Parse(pair[1]));
        });

        int x = 0;
        int y = 0;
        int aim = 0;


        foreach (var kvp in lines)
        {
            switch (kvp.Key)
            {
                case "up":
                    aim -= kvp.Value;
                    break;
                case "down":
                    aim += kvp.Value;
                    break;
                default:
                    x += kvp.Value;
                    y += aim * kvp.Value;
                    break;
            }
        }
        return $"{x*y}";
    }
}
