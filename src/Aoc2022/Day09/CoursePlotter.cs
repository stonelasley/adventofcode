namespace Aoc2022.Day09;

public class CoursePlotter
{
    public static MoveHistoryies Navigate(List<DirectionInstruction> instructions)
    {
        int headLocationX = 0;
        int headLocationY = 0;

        List<Point> headHistory = new() { new Point(0, 0) };
        List<Point> tailHistory = new() { new Point(0, 0) };

        instructions.ForEach(instruction =>
        {
            int currentX = headLocationX;
            int currentY = headLocationY;
            switch (instruction.Plane)
            {
                case Plane.X:
                    headLocationX += instruction.Distance;
                    break;
                case Plane.Y:
                    headLocationY += instruction.Distance;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            var incrementalMoves = BuildIncrementalMoves(
                currentX,
                currentY,
                headLocationX,
                headLocationY,
                instruction
            );

            foreach (var move in incrementalMoves)
            {
                headHistory.Add(move);
                Point newTail = CalculateTailPosition(
                    move,
                    tailHistory.Last(),
                    headHistory.ElementAt(headHistory.Count() - 2)
                );
                if (newTail != tailHistory.Last())
                {
                    tailHistory.Add(newTail);
                }
            }
            headHistory.Add(new Point(headLocationX, headLocationY));
            Point newTail2 = CalculateTailPosition(
                headHistory.Last(),
                tailHistory.Last(),
                headHistory.ElementAt(headHistory.Count() - 2)
            );
            if (newTail2 != tailHistory.Last())
            {
                tailHistory.Add(newTail2);
            }
        });
        return new MoveHistoryies(headHistory, tailHistory);
    }

    public static Point CalculateTailPosition(
        Point currentHead,
        Point currentTail,
        Point previousHead
    )
    {
        var xDiff = currentHead.X - currentTail.X;
        var yDiff = currentHead.Y - currentTail.Y;

        if (Math.Abs(xDiff) <= 1 && Math.Abs(yDiff) <= 1)
        {
            return currentTail;
        }
        return previousHead;
    }

    private static List<Point> BuildIncrementalMoves(
        int currentX,
        int currentY,
        int futureLocationX,
        int futureLocationY,
        DirectionInstruction instruction
    )
    {
        List<Point> histories = new();
        switch (instruction.Plane)
        {
            case Plane.X:
                if (instruction.Distance > 0)
                {
                    for (int i = currentX + 1; i < futureLocationX; i++)
                    {
                        histories.Add(new Point(i, currentY));
                    }
                }
                else
                {
                    for (int i = currentX - 1; i > futureLocationX; i--)
                    {
                        histories.Add(new Point(i, currentY));
                    }
                }

                break;
            case Plane.Y:
                if (instruction.Distance > 0)
                {
                    for (int i = currentY + 1; i < futureLocationY; i++)
                    {
                        histories.Add(new Point(currentX, i));
                    }
                }
                else
                {
                    for (int i = currentY - 1; i > futureLocationY; i--)
                    {
                        histories.Add(new Point(currentX, i));
                    }
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        return histories;
    }
}