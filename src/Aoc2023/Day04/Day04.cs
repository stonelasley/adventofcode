namespace Aoc2023.Day04;

public class Day04 : IDay
{
    public string SolveOne(IInputProvider inputProvider) =>
        inputProvider.Read()
                     .Select(line => new Card(line))
                     .Sum(x => x.Points)
                     .ToString();

    public string SolveTwo(IInputProvider inputProvider)
    {
        string[] input = inputProvider.Read();
        Card[] cards = input.Select(line => new Card(line)).ToArray();
        int[] counts = cards.Select(x => 1).ToArray();

        for (int i = 0; i < cards.Length; i++)
        {
            var (card, count) = (cards[i], counts[i]);
            for (int j = 0; j < card.Matches; j++)
            {
                counts[i + j + 1] += count;

            }

        }
        return counts.Sum().ToString();
    }
}