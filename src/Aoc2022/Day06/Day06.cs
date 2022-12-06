namespace Aoc2022.Day06;

public class Day06 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        char[] input = inputProvider.ReadAllText().ToCharArray();
        return FindUnique(input, 4);
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        char[] input = inputProvider.ReadAllText().ToCharArray();
        return FindUnique(input, 14);
    }

    private static string FindUnique(char[] input, int consecutiveUniques)
    {
        Queue<char> q = new();
        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];
            if (q.Count >= consecutiveUniques)
            {
                if (q.Distinct().Count() == consecutiveUniques)
                {
                    return i.ToString();
                }
                q.Dequeue();
            }
            q.Enqueue(currentChar);
        }

        return "";
    }
}
