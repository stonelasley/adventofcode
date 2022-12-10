namespace Aoc2022.Day09;

public class Day09 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        List<DirectionInstruction> instructions = GetInstructions(inputProvider);
        MoveHistoryies histories = CoursePlotter.Navigate(instructions);
        return $"{histories.TailHistory.Distinct().Count()}";
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        return "";
    }

    public List<DirectionInstruction> GetInstructions(IInputProvider inputProvider) =>
        inputProvider.Read().Select(x => new DirectionInstruction(x)).ToList();
}

public record MoveHistoryies(IList<Point> HeadHistory, IList<Point> TailHistory);
