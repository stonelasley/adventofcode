namespace Aoc2022.Day14;

public record Sand(Position Position, Cave Cave)
{
    public Position Position { get; private set; } = Position;

    public bool Fall()
    {
        if (Cave.PositionIsOpen(Position.Down))
        {
            Position = Position.Down;
            return true;
        }

        if (Cave.PositionIsOpen(Position.DownLeft))
        {
            Position = Position.DownLeft;
            return true;
        }

        if (Cave.PositionIsOpen(Position.DownRight))
        {
            Position = Position.DownRight;
            return true;
        }

        return false;
        //if (
        //    Cave.SettledSand.Contains(Position.Down)
        //    && Cave.SettledSand.Contains(Position.DownLeft)
        //    && Cave.SettledSand.Contains(Position.DownRight))
        //{
        //    return false;
        //}

        Position = Position.Down;
        return true;
    }
}
