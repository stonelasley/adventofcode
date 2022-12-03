namespace Aoc2022.Day02;

public class Game
{
    public List<GameRound> Rounds { get; } = new();
    public List<GameRound> RoundsTwo { get; } = new();
    public int Score => Rounds.Sum(x => x.Score);
    public int ScoreTwo => RoundsTwo.Sum(x => x.Score);

    public Game(string[] rounds)
    {
        foreach (string round in rounds)
        {
            string[] roundInput = round.Split(' ');
            Rounds.Add(new GameRound(char.Parse(roundInput[1]), char.Parse(roundInput[0])));
            RoundsTwo.Add(
                new GameRound(char.Parse(roundInput[0]), new GameThrowOutcome(char.Parse(roundInput[1])))
            );
        }
    }
}