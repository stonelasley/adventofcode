namespace Aoc2022.Day02;

public class Day02 : IDay
{
    public Game GetGame(IInputProvider inputProvider)
    {
        string[] input = inputProvider.Read();
        return new Game(input);
    }

    public string SolveOne(IInputProvider inputProvider) => GetGame(inputProvider).Score.ToString();
    public string SolveTwo(IInputProvider inputProvider) => GetGame(inputProvider).ScoreTwo.ToString();
}