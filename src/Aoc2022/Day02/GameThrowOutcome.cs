namespace Aoc2022.Day02;

public class GameThrowOutcome
{
    private char _alias;

    public GameThrowOutcome(char alias)
    {
        _alias = alias;
    }

    public RpsOutcome Outcome =>
        _alias switch
        {
            'X' => RpsOutcome.Lose,
            'Y' => RpsOutcome.Draw,
            'Z' => RpsOutcome.Win,
            _ => throw new ArgumentOutOfRangeException()
        };
}