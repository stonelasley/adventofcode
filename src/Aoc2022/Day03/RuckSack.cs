namespace Aoc2022.Day03;

public class RuckSack
{
    private string _contents;
    public string Contents => _contents;
    public RuckSack(string contents) => _contents = contents;

    public string Left => _contents[0..(_contents.Length / 2)];
    public string Right => _contents[(_contents.Length / 2).._contents.Length];
    public char CommonItem => Left.ToCharArray().Intersect(Right.ToCharArray()).First();
    public int Priority => CommonItem.Priority();
}