namespace Aoc2022.Day02;

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
    public int Score => Rounds.Sum(x => x.Score);

    public RpsGame(string[] rounds)
    {
        foreach (string round in rounds)
        {
            string[] roundInput = round.Split(' ');
            Rounds.Add(new RpsRound(char.Parse(roundInput[1]), char.Parse(roundInput[0])));
        }
    }
}

public class RpsRound
{
    public RpsThrow MyThrow { get; }
    public RpsThrow TheirThrow { get; }

    public bool Won =>
        TheirThrow.Shape switch
        {
            RpsShape.Rock => MyThrow.Shape == RpsShape.Paper,
            RpsShape.Paper => MyThrow.Shape == RpsShape.Scissors,
            RpsShape.Scissors => MyThrow.Shape == RpsShape.Rock,
            _ => throw new ArgumentOutOfRangeException()
        };

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

    public RpsRound(char myAlias, char theirAlias)
    {
        MyThrow = new RpsThrow(myAlias);
        TheirThrow = new RpsThrow(theirAlias);
    }
}

public class RpsThrow
{
    public RpsShape Shape { get; }
    public int Score =>
        Shape switch
        {
            RpsShape.Rock => 1,
            RpsShape.Paper => 2,
            RpsShape.Scissors => 3,
            _ => throw new ArgumentOutOfRangeException()
        };

    public RpsThrow(char alias)
    {
        Shape = GetByAlias(alias);
    }

    private RpsShape GetByAlias(char alias)
    {
        switch (alias)
        {
            case 'A':
                return RpsShape.Rock;
            case 'B':
                return RpsShape.Paper;
            case 'C':
                return RpsShape.Scissors;
            case 'X':
                return RpsShape.Rock;
            case 'Y':
                return RpsShape.Paper;
            case 'Z':
                return RpsShape.Scissors;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

public enum RpsShape
{
    Rock,
    Paper,
    Scissors
}
