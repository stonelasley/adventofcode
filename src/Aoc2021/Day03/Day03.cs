namespace Aoc2021.Day03;

public class Day03 : IDay
{
    public int SolveOne(IInputProvider inputProvider)
    {
        IEnumerable<char[]> lines = inputProvider.Read().Select(x => x.ToCharArray()).ToList();
        string[] rows = new string[lines.First().Length];

        // Flip Array
        int i = 0;
        foreach (var digits in lines)
        {
            int j = 0;
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
            int ones = row.ToCharArray().Count(x => x == '1');
            int zeros = row.ToCharArray().Count(x => x == '0');
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

        return epsilonTotal * gammaTotal;
    }

    public int SolveTwo(IInputProvider inputProvider)
    {
        IEnumerable<string> lines = inputProvider.Read().ToList();
        IList<char[]> lineArrays = lines.Select(_ => _.ToCharArray()).ToList();

        int co2Rating = GetCo2Rating(lineArrays);
        int o2Rating = GetO2Rating(lineArrays);

        // Console.WriteLine($"OXYGEN GENERATOR RATING: {o2Rating}");
        //Console.WriteLine($"CO2 SCRUBBER RATING: {co2Rating}");
        //Console.WriteLine($"LIFE SUPPORT RATING: {o2Rating * co2Rating}");
        return o2Rating * co2Rating;
    }
    
    static int GetO2Rating(IList<char[]> lines)
    {
        List<char[]> bitBuffer = new(lines);
        int i = 0;
        while (bitBuffer.Count > 1)
        {
            string[] bitsByIndex = RotateBits(bitBuffer);
            string bitsAtIndex = bitsByIndex[i];

            Tuple<int, int> bitCountByState = GetBitCountByState(bitsAtIndex);

            char targetState = (bitCountByState.Item1 >= bitCountByState.Item2) ? '1' : '0';

            bitBuffer = GetLinesByIndexState(targetState, i, bitBuffer);
            i++;
        }

        char[] number = bitBuffer.First();
        return Convert.ToInt32(new String(number), 2);
    }

    static int GetCo2Rating(IList<char[]> lines)
    {
        List<char[]> bitBuffer = new(lines);
        int i = 0;
        while (bitBuffer.Count > 1)
        {
            string[] bitsByIndex = RotateBits(bitBuffer);
            string bitsAtIndex = bitsByIndex[i];

            Tuple<int, int> bitCountByState = GetBitCountByState(bitsAtIndex);

            char targetState = (bitCountByState.Item1 >= bitCountByState.Item2) ? '0' : '1';

            bitBuffer = GetLinesByIndexState(targetState, i, bitBuffer);
            i++;
        }

        char[] number = bitBuffer.First();
        return Convert.ToInt32(new String(number), 2);
    }

    static Tuple<int, int> GetBitCountByState(string bitsAtIndex)
    {
        int onCount = bitsAtIndex.Count(x => x == '1');
        int offCount = bitsAtIndex.Count() - onCount;
        return new Tuple<int, int>(onCount, offCount);
    }

    static string[] RotateBits(IEnumerable<char[]> bitLine)
    {
        string[] rows = new string[bitLine.First().Length];
        int i = 0;
        foreach (var digits in bitLine)
        {
            int j = 0;
            foreach (var digit in digits)
            {
                rows[j] += digit;
                j++;
            }
            i++;
        }

        return rows;
    }

    static List<char[]> GetLinesByIndexState(char bit, int index, IEnumerable<char[]> buffer) =>
        buffer.Where(x => x[index] == bit).ToList();
}
