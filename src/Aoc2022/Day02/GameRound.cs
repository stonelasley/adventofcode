namespace Aoc2022.Day02;

public class GameRound
{
    public GameThrow MyThrow { get; }
    public GameThrow TheirThrow { get; }

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

    public GameRound(char myThrowAlias, char theirThrowAlias)
    {
        MyThrow = new GameThrow(myThrowAlias);
        TheirThrow = new GameThrow(theirThrowAlias);
    }

    public GameRound(char theirThrowAlias, GameThrowOutcome gameThrowOutcome)
    {
        TheirThrow = new GameThrow(theirThrowAlias);
        var x = TheirThrow.CounterShapeByOutcome(gameThrowOutcome.Outcome);
        MyThrow = new GameThrow(x);
    }
}