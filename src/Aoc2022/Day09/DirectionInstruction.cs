namespace Aoc2022.Day09;

public record DirectionInstruction
{
    public Plane Plane { get; init; }
    public Direction Direction { get; init; }
    public int Distance { get; init; }
    public DirectionInstruction(string directionInput)
    {
        string[] inputs = directionInput.Split(' ');
        switch (inputs[0])
        {
            case "U":
                Plane = Plane.Y;
                Direction = Direction.Up;
                Distance = int.Parse(inputs[1]);
                break;
            case "D":
                Plane = Plane.Y;
                Direction = Direction.Down;
                Distance = -1 * int.Parse(inputs[1]);
                break;
            case "L":
                Plane = Plane.X;
                Direction = Direction.Left;
                Distance = -1 * int.Parse(inputs[1]);
                break;
            case "R":
                Plane = Plane.X;
                Direction = Direction.Right;
                Distance = int.Parse(inputs[1]);
                break;
            default:
                throw new ArgumentOutOfRangeException("Uknown Direction");
        }

    }
    
};