namespace Aoc.Core;

public static class Extensions
{
    public static T[] GetRow<T>(this T[,] matrix, int rowNumber) =>
        Enumerable.Range(0, matrix.GetLength(1))
            .Select(x => matrix[rowNumber, x])
            .ToArray();
}
