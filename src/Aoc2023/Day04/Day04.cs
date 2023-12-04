namespace Aoc2023.Day04;

public class Day04 : IDay
{
    public string SolveOne(IInputProvider inputProvider) =>
        inputProvider.Read()
                     .Select(line => new Card(line))
                     .Sum(x => x.Points)
                     .ToString();

    public string SolveTwo(IInputProvider inputProvider)
    {
        string[] input = inputProvider.Read();
        return input.Select(line => new Card(line, input)).Sum(x => x.Count).ToString();
    }
}