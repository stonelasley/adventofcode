namespace Aoc2022.Day13;

public class Day13 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        IEnumerable<string[]> pairs = inputProvider
            .Read()
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Chunk(2);

        var ix = 1;
        var sum = 0;
        foreach (var pair in pairs)
        {
            var listOne = Parser.ParseList(pair.First().ToCharQueue());
            var listTwo = Parser.ParseList(pair.Last().ToCharQueue());
            if (Packets.CompareLists(listOne, listTwo) <= 0)
            {
                sum += ix;
            }

            ix++;
        }
        return $"{sum}";
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        string[] dividerPackets = { "[[2]]", "[[6]]" };

        List<string> pairs = inputProvider.Read()
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Concat(dividerPackets)
            .ToList();

        pairs.Sort(Packets.CompareStrings);

        var ix1 = pairs.IndexOf(dividerPackets[0]);
        var ix2 = pairs.IndexOf(dividerPackets[1]);

        return $"{++ix1 * ++ix2}";
    }
}
