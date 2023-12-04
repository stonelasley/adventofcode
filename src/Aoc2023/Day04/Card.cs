namespace Aoc2023.Day04;

public class Card
{
    public int Points => Convert.ToInt32(Math.Pow(2, Matches - 1));
    public int Matches { get; }
    public Card(string cardLine)
    {
        string[] nameSplit = Regex.Replace(cardLine, @"\s+", " ").Split(':', '|');
        int[] winners = nameSplit[1].Trim().Split(" ", StringSplitOptions.TrimEntries).Select(int.Parse).ToArray();
        int[] losers = nameSplit[2].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        Matches = winners.Intersect(losers).Count();
    }
}