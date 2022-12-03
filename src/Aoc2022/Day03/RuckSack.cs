namespace Aoc2022.Day03;

public class RuckSack
{
    private static List<char> charPriority = new()
    {
        '_', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
        'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O',
        'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
    };

    private string _contents;
    public RuckSack(string contents) => _contents = contents;

    public string Left => _contents[0..(_contents.Length / 2)];
    public string Right => _contents[(_contents.Length / 2).._contents.Length];
    public char CommonItem => Left.ToCharArray().Intersect(Right.ToCharArray()).First();

    public int Priority => charPriority.IndexOf(CommonItem);
}