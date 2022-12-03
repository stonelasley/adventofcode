namespace Aoc2022.Day02;

public class GameThrow
{
    private readonly char _alias;
    public RpsShape Shape =>
        _alias switch
        {
            'A' => RpsShape.Rock,
            'B' => RpsShape.Paper,
            'C' => RpsShape.Scissors,
            'X' => RpsShape.Rock,
            'Y' => RpsShape.Paper,
            'Z' => RpsShape.Scissors,
            _ => throw new ArgumentOutOfRangeException()
        };

    public int Score =>
        Shape switch
        {
            RpsShape.Rock => 1,
            RpsShape.Paper => 2,
            RpsShape.Scissors => 3,
            _ => throw new ArgumentOutOfRangeException()
        };

    public RpsShape WinningShape =>
        Shape switch
        {
            RpsShape.Rock => RpsShape.Paper,
            RpsShape.Paper => RpsShape.Scissors,
            RpsShape.Scissors => RpsShape.Rock,
            _ => throw new ArgumentOutOfRangeException()
        };

    public RpsShape LosingShape =>
        Shape switch
        {
            RpsShape.Rock => RpsShape.Scissors,
            RpsShape.Paper => RpsShape.Rock,
            RpsShape.Scissors => RpsShape.Paper,
            _ => throw new ArgumentOutOfRangeException()
        };

    public RpsShape CounterShapeByOutcome(RpsOutcome outcome)
    {
        switch (outcome)
        {
            case RpsOutcome.Lose:
                return LosingShape;
            case RpsOutcome.Draw:
                return Shape;
            case RpsOutcome.Win:
                return WinningShape;
            default:
                throw new ArgumentOutOfRangeException(nameof(outcome), outcome, null);
        }
    }

    public GameThrow(char alias)
    {
        _alias = alias;
    }

    public GameThrow(RpsShape shape)
    {
        _alias = shape switch
        {
            RpsShape.Rock => 'A',
            RpsShape.Paper => 'B',
            RpsShape.Scissors => 'C',
            _ => throw new ArgumentOutOfRangeException(nameof(shape), shape, null)
        };
    }
}