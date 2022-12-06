namespace Aoc2021.Day03;

public class Day03 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        IEnumerable<char[]> lines = inputProvider.Read().Select(x => x.ToCharArray()).ToList();
        var rows = new string[lines.First().Length];

        // Flip Array
        var i = 0;
        foreach (var digits in lines)
        {
            var j = 0;
            foreach (var digit in digits)
            {
                rows[j] += digit;
                j++;
            }

            i++;
        }

        var gamma = "";
        var epsilon = "";
        foreach (var row in rows)
        {
            var ones = row.ToCharArray().Count(x => x == '1');
            var zeros = row.ToCharArray().Count(x => x == '0');
            if (ones > zeros)
            {
                gamma += "1";
                epsilon += "0";
            }
            else
            {
                gamma += "0";
                epsilon += "1";
            }
        }

        var gammaTotal = Convert.ToInt32(gamma, 2);
        var epsilonTotal = Convert.ToInt32(epsilon, 2);

        return $"{epsilonTotal * gammaTotal}";
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        IEnumerable<string> lines = inputProvider.Read().ToList();
        IList<char[]> lineArrays = lines.Select(_ => _.ToCharArray()).ToList();

        var co2Rating = GetCo2Rating(lineArrays);
        var o2Rating = GetO2Rating(lineArrays);

        return $"{o2Rating * co2Rating}";
    }

    private static int GetO2Rating(IList<char[]> lines)
    {
        List<char[]> bitBuffer = new(lines);
        var i = 0;
        while (bitBuffer.Count > 1)
        {
            var bitsByIndex = RotateBits(bitBuffer);
            var bitsAtIndex = bitsByIndex[i];

            var bitCountByState = GetBitCountByState(bitsAtIndex);

            var targetState = bitCountByState.Item1 >= bitCountByState.Item2 ? '1' : '0';

            bitBuffer = GetLinesByIndexState(targetState, i, bitBuffer);
            i++;
        }

        var number = bitBuffer.First();
        return Convert.ToInt32(new string(number), 2);
    }

    private static int GetCo2Rating(IList<char[]> lines)
    {
        List<char[]> bitBuffer = new(lines);
        var i = 0;
        while (bitBuffer.Count > 1)
        {
            var bitsByIndex = RotateBits(bitBuffer);
            var bitsAtIndex = bitsByIndex[i];

            var bitCountByState = GetBitCountByState(bitsAtIndex);

            var targetState = bitCountByState.Item1 >= bitCountByState.Item2 ? '0' : '1';

            bitBuffer = GetLinesByIndexState(targetState, i, bitBuffer);
            i++;
        }

        var number = bitBuffer.First();
        return Convert.ToInt32(new string(number), 2);
    }

    private static Tuple<int, int> GetBitCountByState(string bitsAtIndex)
    {
        var onCount = bitsAtIndex.Count(x => x == '1');
        var offCount = bitsAtIndex.Count() - onCount;
        return new Tuple<int, int>(onCount, offCount);
    }

    private static string[] RotateBits(IEnumerable<char[]> bitLine)
    {
        var rows = new string[bitLine.First().Length];
        var i = 0;
        foreach (var digits in bitLine)
        {
            var j = 0;
            foreach (var digit in digits)
            {
                rows[j] += digit;
                j++;
            }

            i++;
        }

        return rows;
    }

    private static List<char[]> GetLinesByIndexState(
        char bit,
        int index,
        IEnumerable<char[]> buffer
    )
    {
        return buffer.Where(x => x[index] == bit).ToList();
    }
}
