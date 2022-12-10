namespace Aoc2022.Day09;

public class DirectionInstruction
{
    public Direction Direction { get; set; }
    public int Distance { get; set; }

    public int XMove =>
        Direction switch
        {
            Direction.Right => 1,
            Direction.Left => -1,
            _ => 0
        };

    public int YMove =>
        Direction switch
        {
            Direction.Up => 1,
            Direction.Down => -1,
            _ => 0
        };

    public DirectionInstruction(string input)
    {
        Direction = input[0] switch
        {
            'R' => Direction.Right,
            'L' => Direction.Left,
            'U' => Direction.Up,
            'D' => Direction.Down,
            _ => throw new ArgumentException("Unknown Direction")
        };
        Distance = int.Parse(input[2..]);
    }
}
