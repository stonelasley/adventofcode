namespace Aoc2023.Day01;

public class Day01 : IDay
{
    public string SolveOne(IInputProvider inputProvider) =>
        inputProvider.Read()
                     .Select(x =>
                      {
                          string pattern = @"\d";
                          return ParseLine(x, pattern);

                      })
                     .Sum()
                     .ToString();




    public string SolveTwo(IInputProvider inputProvider) =>
        inputProvider.Read()
                     .Select(x =>
                      {
                          string pattern = @"\d|one|two|three|four|five|six|seven|eight|nine";
                          return ParseLine(x, pattern);

                      })
                     .Sum()
                     .ToString();


    int ParseLine(string input, string pattern)
    {
        string first = Regex.Match(input, pattern).Value;
        string last = Regex.Match(input, pattern, RegexOptions.RightToLeft).Value;
        return ParseInt(first) * 10 + ParseInt(last);
    }

    int ParseInt(string input)
    {
        return input switch
        {
            "one" => 1,
            "two" => 2,
            "three" => 3,
            "four" => 4,
            "five" => 5,
            "six" => 6,
            "seven" => 7,
            "eight" => 8,
            "nine" => 9,
            _ => int.Parse(input)
        };
    }

}