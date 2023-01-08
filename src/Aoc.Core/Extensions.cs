namespace Aoc.Core;

public static class Extensions
{
    public static T[] GetRow<T>(this T[,] matrix, int rowNumber)
    {
        return Enumerable.Range(0, matrix.GetLength(1)).Select(x => matrix[rowNumber, x]).ToArray();
    }

    public static Queue<char> ToCharQueue(this string input, StringSplitOptions? options = null)
    {
        Queue<char> queue = new();
        foreach (char c in input)
        {
            if(options == StringSplitOptions.RemoveEmptyEntries && c == ' ')
            {
                continue;
            }
            queue.Enqueue(c);
        }

        return queue;
    }
    
    public static long GCD(long a, long b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }
}
