namespace Aoc2023.Day04;

public class Card
{

    public string Name { get; }
    public int Points => Convert.ToInt32(Math.Pow(2, Matches - 1));
    public int[] WinningPool { get; }
    public int[] Actual { get; }
    public int Matches => WinningPool.Intersect(Actual).Count();
    public Card[] Copies { get; }

    public int Count => Copies.Sum(x => x.Count) + 1;

    public Card(string cardLine)
    {
        string[] nameSplit = Regex.Replace(cardLine, @"\s+", " ").Trim().Split(':');
        string[] nums = nameSplit[1].Trim().Split('|', StringSplitOptions.TrimEntries);

        Name = nameSplit[0].Trim();
        WinningPool = nums[0].Trim().Split(" ", StringSplitOptions.TrimEntries).Select(int.Parse).ToArray();
        Actual = nums[1].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    }

    public Card(string cardLine, string[] inputs) : this(cardLine)
    {
        int startingIndex = Array.IndexOf(inputs, cardLine) + 1;
        int count = startingIndex + Matches > inputs.Length ? inputs.Length - startingIndex : Matches;
        Copies = new ArraySegment<string>(inputs, startingIndex, count)
                .Select(x => new Card(x, inputs))
                .ToArray();

    }

}