namespace Aoc2022.Day02;

public class Day02 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        return GetGame(inputProvider).Score.ToString();
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        return GetGame(inputProvider).ScoreTwo.ToString();
    }

    public Game GetGame(IInputProvider inputProvider)
    {
        var input = inputProvider.Read();
        return new Game(input);
    }
}
