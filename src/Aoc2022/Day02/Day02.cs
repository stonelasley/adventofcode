namespace Aoc2022.Day02;

public class Day02
{
    private readonly IInputProvider<Day02> _inputProvider;

    public Day02(IInputProvider<Day02> inputProvider)
    {
        _inputProvider = inputProvider;
    }

    public Game GetGame()
    {
        string[] input = _inputProvider.Read();
        return new Game(input);
    }
}