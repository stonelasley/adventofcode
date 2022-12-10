namespace Aoc2022.Day09;

public class Day09 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        List<DirectionInstruction> instructions = GetInstructions(inputProvider);
        List<List<Point>> histories = CoursePlotter.Navigate(2, instructions);
        return $"{histories.Last().Distinct().Count()}";
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        List<DirectionInstruction> instructions = GetInstructions(inputProvider);
        List<List<Point>> histories = CoursePlotter.Navigate(9, instructions);
        return $"{histories.Last().Distinct().Count()}";
    }

    public List<DirectionInstruction> GetInstructions(IInputProvider inputProvider) =>
        inputProvider.Read().Select(x => new DirectionInstruction(x)).ToList();
}

//public record MoveHistoryies(IList<Point> HeadHistory, IList<Point> TailHistory);
