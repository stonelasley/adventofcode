namespace Aoc2022.Day09;

using System.Runtime.InteropServices;

public class CoursePlotter
{
    public static List<List<Point>> Navigate(
        int chainLength,
        List<DirectionInstruction> instructions
    )
    {
        Point destinationPoint = new Point(0, 0);
        List<List<Point>> pointChain = new();
        for (int i = 0; i < chainLength; i++)
        {
            List<Point> history = new() { new Point(0, 0) };
            pointChain.Add(history);
        }

        instructions.ForEach(instruction =>
        {
            // Copy Current Location
            Point currentPoint = new Point(destinationPoint.X, destinationPoint.Y);
            // Calculate Next Location
            destinationPoint = GetNextPoint(currentPoint, instruction);

            // Generate Incremental Points
            List<Point> incrementalMoves = BuildIncrementalMoves(
                currentPoint,
                destinationPoint,
                instruction
            );

            // Add Incremental Points to History up to Destination
            List<Point> headHistory = pointChain.First();
            foreach (var incrementalDestination in incrementalMoves)
            {
                headHistory.Add(incrementalDestination);
                // Cascade Incremental Move
                for (int i = 1; i < pointChain.Count; i++)
                {
                    List<Point> currentHistory = pointChain.ElementAt(i);
                    List<Point> relativeHeadHistory = pointChain.ElementAt(i - 1);

                    if (i == pointChain.Count - 1)
                    {
                        var b = 0;
                    }

                    UpdateMoveHistory(
                        incrementalDestination,
                        ref currentHistory,
                        relativeHeadHistory
                    );
                }
            }
            headHistory.Add(destinationPoint);

            for (int i = 1; i < pointChain.Count; i++)
            {
                var currentHistory = pointChain.ElementAt(i);
                var relativeHeadHistory = pointChain.ElementAt(i - 1);

                if (i == pointChain.Count - 1)
                {
                    var b = 0;
                }

                UpdateMoveHistory(
                    relativeHeadHistory.Last(),
                    ref currentHistory,
                    relativeHeadHistory
                );
            }
        });
        return pointChain;
    }

    public static void UpdateMoveHistory(
        Point referencePoint,
        ref List<Point> currentHistory,
        List<Point> relativeHeadHistory
    )
    {
        int lookBackOffset = relativeHeadHistory.Count < 2 ? 1 : 2;

        var newTail = CalculateTailPosition(
            referencePoint,
            currentHistory.Last(),
            relativeHeadHistory.ElementAt(relativeHeadHistory.Count() - lookBackOffset)
        );

        if (newTail != currentHistory.Last())
        {
            currentHistory.Add(newTail);
        }
    }

    public static Point GetNextPoint(Point currentPoint, DirectionInstruction instruction)
    {
        switch (instruction.Plane)
        {
            case Plane.X:
                return new Point(currentPoint.X + instruction.Distance, currentPoint.Y);
            case Plane.Y:
                return new Point(currentPoint.X, currentPoint.Y + instruction.Distance);
            default:
                throw new ArgumentOutOfRangeException();
        }
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
        Point current,
        Point futureLocation,
        DirectionInstruction instruction
    )
    {
        List<Point> histories = new();
        switch (instruction.Plane)
        {
            case Plane.X:
                if (instruction.Distance > 0)
                {
                    for (int i = current.X + 1; i < futureLocation.X; i++)
                    {
                        histories.Add(new Point(i, current.Y));
                    }
                }
                else
                {
                    for (int i = current.X - 1; i > futureLocation.X; i--)
                    {
                        histories.Add(new Point(i, current.Y));
                    }
                }

                break;
            case Plane.Y:
                if (instruction.Distance > 0)
                {
                    for (int i = current.Y + 1; i < futureLocation.Y; i++)
                    {
                        histories.Add(new Point(current.X, i));
                    }
                }
                else
                {
                    for (int i = current.Y - 1; i > futureLocation.Y; i--)
                    {
                        histories.Add(new Point(current.X, i));
                    }
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        return histories;
    }
}
