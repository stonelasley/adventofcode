namespace Aoc2022.Day08;

public class Day08 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        List<List<int>> input = ToList(inputProvider.Read());

        return TreeCounter.Count(input).ToString();
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        List<List<int>> input = ToList(inputProvider.Read());

        return TreeCounter.CalculateMaxTreeScore(input).ToString();
    }

    private List<List<int>> ToList(IEnumerable<string> input) =>
        input.Select(x => x.ToCharArray().Select(x => int.Parse(x.ToString())).ToList()).ToList();
}

public class TreeCounter
{
    public static int CountPerimiter(List<List<int>> input) =>
        (input.Count * 2) + (input.Count - 2) * 2;

    public static int Count(List<List<int>> input)
    {
        int maxTreeScore = 0;
        int count = CountPerimiter(input);

        for (int x = 1; x < input.Count - 1; x++)
        {
            for (int y = 1; y < input.ElementAt(x).Count - 1; y++)
            {
                int treeHeight = input.ElementAt(y).ElementAt(x);
                if (
                    IsVisibleFromLeft(input, treeHeight, x, y)
                    || IsVisibleFromRight(input, treeHeight, x, y)
                    || IsVisibleFromTop(input, treeHeight, x, y)
                    || IsVisibleFromBottom(input, treeHeight, x, y)
                )
                {
                    count++;
                }
            }
        }

        return count;
    }

    public static int CalculateMaxTreeScore(List<List<int>> input)
    {
        int maxTreeScore = 0;
        for (int x = 1; x < input.Count - 1; x++)
        {
            for (int y = 1; y < input.ElementAt(x).Count - 1; y++)
            {
                int treeHeight = input.ElementAt(y).ElementAt(x);
                int treeScore =
                    LeftScore(input, treeHeight, x, y)
                    * TopScore(input, treeHeight, x, y)
                    * ScoreRight(input, treeHeight, x, y)
                    * ScoreBottom(input, treeHeight, x, y);
                if (treeScore > maxTreeScore)
                {
                    maxTreeScore = treeScore;
                }
            }
        }

        return maxTreeScore;
    }

    public static bool IsVisibleFromLeft(
        List<List<int>> input,
        int treeHeight,
        int treeX,
        int treeY
    ) => !input.ElementAt(treeY).GetRange(0, treeX).Any(x => x >= treeHeight);

    public static int LeftScore(List<List<int>> input, int treeHeight, int treeX, int treeY)
    {
        var treeScore = 1;
        for (int i = treeX - 1; i > 0; i--)
        {
            var height = input[treeY][i];
            if (height < treeHeight)
            {
                treeScore++;
            }
            else
            {
                break;
            }
        }
        return treeScore;
    }

    public static bool IsVisibleFromRight(List<List<int>> input, int treeHeight, int treeX, int treeY)
    {
        var row = input.ElementAt(treeY);
        var remainingIndexes = (row.Count - treeX) - 1;
        var rowSegment = row.GetRange(treeX + 1, remainingIndexes);
        return !rowSegment.Any(x => x >= treeHeight);
    }

    public static int ScoreRight(List<List<int>> input, int treeHeight, int treeX, int treeY)
    {
        var treeScore = 1;
        for (int i = treeX + 1; i < input[treeY].Count - 1; i++)
        {
            var height = input[treeY][i];
            if (height < treeHeight)
            {
                treeScore++;
            }
            else
            {
                break;
            }
        }
        return treeScore;
    }

    public static bool IsVisibleFromTop(
        List<List<int>> input,
        int treeHeight,
        int treeX,
        int treeY
    ) =>
        !input
            .Select(x => x.ElementAt(treeX))
            .ToList()
            .GetRange(0, treeY)
            .Any(x => x >= treeHeight);

    public static int TopScore(List<List<int>> input, int treeHeight, int treeX, int treeY)
    {
        var treeScore = 1;
        for (int i = treeY - 1; i > 0; i--)
        {
            var height = input[i][treeX];
            if (height < treeHeight)
            {
                treeScore++;
            }
            else
            {
                break;
            }
        }
        return treeScore;
    }

    public static bool IsVisibleFromBottom(
        List<List<int>> input,
        int treeHeight,
        int treeX,
        int treeY
    )
    {
        var column = input.Select(x => x.ElementAt(treeX)).ToList();
        var remainingIndexes = (column.Count - treeY) - 1;

        return !column.GetRange(treeY + 1, remainingIndexes).Any(x => x >= treeHeight);
    }

    public static int ScoreBottom(List<List<int>> input, int treeHeight, int treeX, int treeY)
    {
        var treeScore = 1;
        for (int i = treeY + 1; i < input.Count - 1; i++)
        {
            var height = input[i][treeX];
            if (height < treeHeight)
            {
                treeScore++;
            }
            else
            {
                break;
            }
        }
        return treeScore;
    }
}
