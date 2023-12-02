namespace Aoc2023.Day02;

public class CubeCount
{
    public string Color { get; private set; }
    public int Count { get; private set; }

    public CubeCount(string input)
    {
        var sp = input.Split(" ");
        Color = sp[1];
        Count = int.Parse(sp[0]);
    }

};