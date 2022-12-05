using System.Drawing;

namespace Aoc2021.Day05;

public class Line
{
    public Point Start { get; }
    public Point End { get; }
    public int MaxX => Math.Max(Start.X, End.X);
    public int MaxY => Math.Max(Start.Y, End.Y);
    public bool IsHorizontal => Start.Y == End.Y;
    public bool IsVertical => Start.X == End.X;
    public bool IsDiagonal => !IsHorizontal && !IsVertical;

    public Line(string inputLine)
    {
        var pointsArr = inputLine.Split("->");
        var startStr = pointsArr[0].Split(',');
        var endStr = pointsArr[1].Split(',');
        Start = new Point(int.Parse(startStr[0].Trim()), int.Parse(startStr[1].Trim()));
        End = new Point(int.Parse(endStr[0].Trim()), int.Parse(endStr[1].Trim()));
    }
    
    const float EPSILON = 0.001f;

    public bool IsPointOnLine(Point point) 
    {
        float a = (End.Y - Start.Y) / (End.X - Start.X);
        float b = Start.Y - a * Start.X;
        if ( Math.Abs(point.Y - (a*point.X+b)) < EPSILON)
        {
            return true;
        }

        return false;
    }
}