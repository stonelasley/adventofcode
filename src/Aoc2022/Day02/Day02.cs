namespace Aoc2022;

public class Day02
{
    private readonly IInputProvider<Day02> _inputProvider;

    public Day02(IInputProvider<Day02> inputProvider)
    {
        _inputProvider = inputProvider;
    }

    public RpsGame GetGame()
    {
        string[] input = _inputProvider.Read();
        return new RpsGame(input);
    }
}

public class RpsGame
{
    public List<RpsRound> Rounds { get; } = new();
    public List<RpsRound> Rounds2 { get; } = new();
    public int Score => Rounds.Sum(x => x.Score);
    public int Score2 => Rounds2.Sum(x => x.Score);

    public RpsGame(string[] rounds)
    {
        foreach (string round in rounds)
        {
            string[] roundInput = round.Split(' ');
            Rounds.Add(new RpsRound(char.Parse(roundInput[1]), char.Parse(roundInput[0])));
            Rounds2.Add(
                new RpsRound(char.Parse(roundInput[0]), new ThrowOutcome(char.Parse(roundInput[1])))
            );
        }
    }
}

public class RpsRound
{
    public RpsThrow MyThrow { get; }
    public RpsThrow TheirThrow { get; }

    public bool Won => TheirThrow.Shape == MyThrow.LosingShape;

    public bool Draw => MyThrow.Shape == TheirThrow.Shape;

    public int Score
    {
        get
        {
            if (Draw)
            {
                return MyThrow.Score + 3;
            }
            if (Won)
            {
                return 6 + MyThrow.Score;
            }
            return MyThrow.Score;
        }
    }

    public RpsRound(char myThrowAlias, char theirThrowAlias)
    {
        MyThrow = new RpsThrow(myThrowAlias);
        TheirThrow = new RpsThrow(theirThrowAlias);
    }

    public RpsRound(char theirThrowAlias, ThrowOutcome throwOutcome)
    {
        TheirThrow = new RpsThrow(theirThrowAlias);
        var x = TheirThrow.CounterShapeByOutcome(throwOutcome.Outcome);
        MyThrow = new RpsThrow(x);
    }
}

public class ThrowOutcome
{
    private char _alias;

    public ThrowOutcome(char alias)
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

public class RpsThrow
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

    public RpsThrow(char alias)
    {
        _alias = alias;
    }

    public RpsThrow(RpsShape shape)
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

public enum RpsShape
{
    Rock,
    Paper,
    Scissors
}

public enum RpsOutcome
{
    Lose,
    Draw,
    Win
}
