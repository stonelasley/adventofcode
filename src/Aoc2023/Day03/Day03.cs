namespace Aoc2023.Day03;

public class Day03 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        var input = inputProvider.Read();
        List<SchematicItem> schematicNumbers = new();
        for (int i = 0; i < input.Length; i++)
        {
            schematicNumbers.AddRange(ParseLine(i, input[i]));
        }

        int total = 0;
        for (int i = 0; i < input.Length; i++)
        {
            int partNumbers = ParsePartNumbers(i, schematicNumbers);
            total += partNumbers;
        }
        return $"{total}";
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        var input = inputProvider.Read();
        List<SchematicItem> schematicNumbers = new();
        for (int i = 0; i < input.Length; i++)
        {
            schematicNumbers.AddRange(ParseLine(i, input[i]));
        }

        int total = 0;
        for (int i = 0; i < input.Length; i++)
        {
            int gears = ParseGears(i, schematicNumbers);
            total += gears;
        }
        return $"{total}";
    }

    public IList<SchematicItem> ParseLine(int lineIndex, string inputLine)
    {
        List<SchematicItem> result = new();
        var splitLine = inputLine
            .Replace(".", "._.")
            .Split('.', StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        int currentAdjustedIndex = 0;
        for (int i = 0; i < splitLine.Count; i++)
        {
            string currentVal = splitLine[i];

            // check for hybrid cases
            var trailing = new Regex($"(\\d+)([^0-9.])");
            var leading = new Regex($"([^0-9.])(\\d+)");
            var tMatch = trailing.Match(currentVal);
            var lMatch = leading.Match(currentVal);

            // handle hybrid cases
            if (tMatch.Success && lMatch.Success)
            {
                string number = tMatch.Groups[1].Value;
                string symbol = tMatch.Groups[2].Value;
                string secondNumber = lMatch.Groups[2].Value;

                var schematicNumber = new SchematicItem(lineIndex, number, currentAdjustedIndex);
                currentAdjustedIndex = schematicNumber.EndIndex + 1;
                result.Add(schematicNumber);
                var schematicSymbol = new SchematicItem(lineIndex, symbol, currentAdjustedIndex);
                currentAdjustedIndex = schematicSymbol.EndIndex + 1;
                result.Add(schematicSymbol);
                var schematicSecondNumber = new SchematicItem(
                    lineIndex,
                    secondNumber,
                    currentAdjustedIndex
                );
                currentAdjustedIndex = schematicSecondNumber.EndIndex + 1;
                result.Add(schematicSecondNumber);
            }
            else if (tMatch.Success)
            {
                // if trailing 467*
                string number = tMatch.Groups[1].Value;
                string symbol = tMatch.Groups[2].Value;

                var schematicNumber = new SchematicItem(lineIndex, number, currentAdjustedIndex);
                currentAdjustedIndex = schematicNumber.EndIndex + 1;
                result.Add(schematicNumber);
                var schematicSymbol = new SchematicItem(lineIndex, symbol, currentAdjustedIndex);
                currentAdjustedIndex = schematicSymbol.EndIndex + 1;
                result.Add(schematicSymbol);
            }
            else if (lMatch.Success)
            {
                string symbol = lMatch.Groups[1].Value;
                string number = lMatch.Groups[2].Value;

                var schematicSymbol = new SchematicItem(lineIndex, symbol, currentAdjustedIndex);
                currentAdjustedIndex = schematicSymbol.EndIndex + 1;
                result.Add(schematicSymbol);
                var schematicNumber = new SchematicItem(lineIndex, number, currentAdjustedIndex);
                currentAdjustedIndex = schematicNumber.EndIndex + 1;
                result.Add(schematicNumber);
            }
            else
            {
                var s = new SchematicItem(lineIndex, currentVal, currentAdjustedIndex);
                currentAdjustedIndex = s.EndIndex + 1;
                result.Add(s);
            }
        }
        return result;
    }

    public int ParsePartNumbers(int lineIndex, IList<SchematicItem> schematicNumbers)
    {
        List<int> partNumbers = new();

        var currentLine = schematicNumbers.Where(x => x.LineNumber == lineIndex).ToList();
        var currentLineNumbers = currentLine.Where(x => x.IsNumber).ToList();
        var symbols = schematicNumbers
            .Where(x => x.IsSymbol)
            .Where(x => x.LineNumber >= lineIndex - 1 && x.LineNumber <= lineIndex + 1)
            .ToList();
        foreach (var number in currentLineNumbers)
        {
            bool adjacentSymbols = symbols.Any(
                sym => sym.Index >= number.Index - 1 && sym.Index <= number.EndIndex + 1
            );
            if (!adjacentSymbols)
                continue;

            int numberValue = int.Parse(number.Value);
            partNumbers.Add(numberValue);
        }
        return partNumbers.Sum();
    }

    public int ParseGears(int lineIndex, IList<SchematicItem> schematicNumbers)
    {
        var currentLine = schematicNumbers.Where(x => x.LineNumber == lineIndex).ToList();
        var stars = currentLine.Where(x => x.IsStar).ToList();

        int gearTotal = 0;
        foreach (var star in stars)
        {
            var adjascentNumbers = schematicNumbers
                .Where(x => x.IsNumber)
                .Where(x => x.LineNumber >= lineIndex - 1 && x.LineNumber <= lineIndex + 1)
                .Where(num => num.EndIndex >= star.Index - 1 && num.Index <= star.EndIndex + 1)
                .ToList();

            if (adjascentNumbers.Count != 2)
                continue;

            gearTotal += adjascentNumbers.First().NumberValue.Value * adjascentNumbers.Last().NumberValue.Value;
        }
        return gearTotal;
    }
}
