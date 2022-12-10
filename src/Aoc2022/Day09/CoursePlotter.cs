namespace Aoc2022.Day09;

public class CoursePlotter
{
    public static HashSet<Point> Navigate(int knotCount, List<DirectionInstruction> instructions)
    {
        HashSet<Point> tailHistory = new();
        Point[] rope = new Point[knotCount];

        foreach (var instruction in instructions)
        {
            int moveDistance = instruction.Distance;

            while (moveDistance-- > 0)
            {
                rope[0] = new Point(rope[0].X + instruction.XMove, rope[0].Y + instruction.YMove);

                for (int i = 1; i < rope.Length; i++)
                {
                    Point currentItem = rope[i];
                    Point lastItem = rope[i - 1];

                    int diffX = (lastItem.X - currentItem.X);
                    int diffY = (lastItem.Y - currentItem.Y);

                    var requiresMove = Math.Abs(diffX) > 1 || Math.Abs(diffY) > 1;

                    if (requiresMove)
                    {
                        rope[i] = new Point(
                            rope[i].X + Math.Sign(diffX),
                            rope[i].Y + Math.Sign(diffY)
                        );
                    }
                }

                Point currentTail = rope.ElementAt(^1);
                tailHistory.Add(currentTail);
            }
        }
        return tailHistory;
    }
}
