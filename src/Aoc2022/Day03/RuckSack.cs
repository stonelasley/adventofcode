namespace Aoc2022.Day03;

public class RuckSack
{
    public RuckSack(string contents)
    {
        Contents = contents;
    }

    public string Contents { get; }

    public string Left => Contents[..(Contents.Length / 2)];
    public string Right => Contents[(Contents.Length / 2)..Contents.Length];
    public char CommonItem => Left.ToCharArray().Intersect(Right.ToCharArray()).First();
    public int Priority => CommonItem.Priority();
}
