namespace Aoc2022.Day02;

public class Day02 : IDay
{
    public Game GetGame(IInputProvider inputProvider)
    {
        string[] input = inputProvider.Read();
        return new Game(input);
    }

    public int SolveOne(IInputProvider inputProvider) => GetGame(inputProvider).Score;
    public int SolveTwo(IInputProvider inputProvider) => GetGame(inputProvider).ScoreTwo;
}