using System.Drawing;
using System.Xml;

namespace Aoc2021.Day05;

public class Map
{
    public int[,] Plot { get; }
    public List<Line> Lines { get; }

    public int Dimension { get; }

    public Map(IInputProvider inputProvider)
    {
        Lines = inputProvider.Read().Select(line => new Line(line)).ToList();
        var maxX= Lines.Max(x => x.MaxX) + 1;
        var maxY = Lines.Max(x => x.MaxY) + 1;
        var dim = Math.Max(maxX, maxY);
        Dimension = dim;
        Plot = SeededPlot(dim, dim);
        Lines.ForEach(PlotLine);
    }

    public void PlotLine(Line line)
    {
        var a = line.Start;
        var b = line.End;
        var startX = Math.Min(a.X, b.X);
        var endX = Math.Max(a.X, b.X);
        var startY = Math.Min(a.Y, b.Y);
        var endY = Math.Max(a.Y, b.Y);

        if (line.IsHorizontal)
        {
            for (int x = startX; x <= endX; x++)
            {
                Plot[x, line.MaxY]++;
            }
        }

        if (line.IsVertical)
        {
            for (int y = startY; y <= endY; y++)
            {
                Plot[line.MaxX, y]++;
            }
        }
    }

    private int[,] SeededPlot(int height, int width)
    {
        int[,] plot = new int[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                plot![x, y] = 0;
            }
        }

        return plot;
    }
}