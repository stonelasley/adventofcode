namespace Aoc2022.Day08;

using System.ComponentModel;

public class Day08 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        TreePatchCounter counter = new();
        List<List<int>> input = inputProvider
            .Read()
            .Select(x => x.ToCharArray().Select(x => int.Parse(x.ToString())).ToList())
            .ToList();

        return counter.Count(input).ToString();
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        return "";
    }

    private List<List<int>> ToList(IEnumerable<string> input) =>
        input.Select(x => x.ToCharArray().Select(x => int.Parse(x.ToString())).ToList()).ToList();
}

public class TreePatchCounter
{
    public int CountPerimiter(List<List<int>> input)
    {
        return (input.Count * 2) + (input.Count - 2) * 2;
    }

    public int Count(List<List<int>> input)
    {
        var count = CountPerimiter(input);

        for (int x = 1; x < input.Count - 1; x++)
        {
            for (int y = 1; y < input.ElementAt(x).Count - 1; y++)
            {
                int treeHeight = input.ElementAt(y).ElementAt(x);
                if (
                    VisibleFromLeft(input, treeHeight, x, y)
                    || VisibleFromRight(input, treeHeight, x, y)
                    || VisibleFromTop(input, treeHeight, x, y)
                    || VisibleFromBottom(input, treeHeight, x, y)
                )
                {
                    count++;
                }
            }
        }

        return count;
    }

    public bool VisibleFromLeft(List<List<int>> input, int treeHeight, int treeX, int treeY) =>
        !input.ElementAt(treeY).GetRange(0, treeX).Any(x => x >= treeHeight);

    public bool VisibleFromRight(List<List<int>> input, int treeHeight, int treeX, int treeY)
    {
        var row = input.ElementAt(treeY);
        var remainingIndexes = (row.Count - treeX) - 1;
        var rowSegment = row.GetRange(treeX + 1, remainingIndexes);
        return !rowSegment.Any(x => x >= treeHeight);
    }

    public bool VisibleFromTop(List<List<int>> input, int treeHeight, int treeX, int treeY) =>
        !input
            .Select(x => x.ElementAt(treeX))
            .ToList()
            .GetRange(0, treeY)
            .Any(x => x >= treeHeight);

    public bool VisibleFromBottom(List<List<int>> input, int treeHeight, int treeX, int treeY)
    {
        var column = input.Select(x => x.ElementAt(treeX)).ToList();
        var remainingIndexes = (column.Count - treeY) - 1;

        return !column.GetRange(treeY + 1, remainingIndexes).Any(x => x >= treeHeight);
    }
}
