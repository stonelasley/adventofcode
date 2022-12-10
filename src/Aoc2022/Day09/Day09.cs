namespace Aoc2022.Day09;

public class Day09 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        List<DirectionInstruction> instructions = BuildInstructions(inputProvider);
        HashSet<Point> history = CoursePlotter.Navigate(2, instructions);
        return $"{history.Count()}";
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        List<DirectionInstruction> instructions = BuildInstructions(inputProvider);
        HashSet<Point> history = CoursePlotter.Navigate(10, instructions);
        return $"{history.Count()}";
    }

    private static List<DirectionInstruction> BuildInstructions(IInputProvider inputProvider) =>
        inputProvider
           .Read()
           .Select(input => new DirectionInstruction(input))
           .ToList();
}