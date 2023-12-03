namespace Aoc2023.Day03;

public class Day03 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        var input = inputProvider.Read();
        List<SchematicNumber> schematicNumbers = new();
        for (int i = 0; i < input.Length; i++)
        {
            schematicNumbers.AddRange(ParseLine(i, input[i]));
        }

        int total = 0;
        for (int i = 0; i < input.Length; i++)
        {
            int parNumbers = ParsePartNumbers(i, schematicNumbers);
            total += parNumbers;
        }
        return $"{total}";
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        var input = inputProvider.Read();
        return "unsolved";
    }

    public int ParsePartNumbers(int lineIndex, IList<SchematicNumber> schematicNumbers)
    {
        List<int> partNumbers = new();

        var currentLine = schematicNumbers.Where(x => x.LineNumber == lineIndex).ToList();
        var currentLineNumbers = currentLine.Where(x => x.IsNumber).ToList();
        var symbols = schematicNumbers.Where(x => x.IsSymbol)
            .Where(x => x.LineNumber >= lineIndex -1 && x.LineNumber <= lineIndex + 1).ToList();
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

    public IList<SchematicNumber> ParseLine(int lineIndex, string inputLine)
    {
        List<SchematicNumber> result = new();
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
                
                var schematicNumber = new SchematicNumber(lineIndex, number, currentAdjustedIndex);
                currentAdjustedIndex = schematicNumber.EndIndex + 1;
                result.Add(schematicNumber);
                var schematicSymbol= new SchematicNumber(lineIndex, symbol, currentAdjustedIndex);
                currentAdjustedIndex = schematicSymbol.EndIndex + 1;
                result.Add(schematicSymbol);
                var schematicSecondNumber = new SchematicNumber(lineIndex, secondNumber, currentAdjustedIndex);
                currentAdjustedIndex = schematicSecondNumber.EndIndex + 1;
                result.Add(schematicSecondNumber);
            }
            else if (tMatch.Success)
            {
                // if trailing 467*
                string number = tMatch.Groups[1].Value;
                string symbol = tMatch.Groups[2].Value;
                
                var schematicNumber = new SchematicNumber(lineIndex, number, currentAdjustedIndex);
                currentAdjustedIndex = schematicNumber.EndIndex + 1;
                result.Add(schematicNumber);
                var schematicSymbol= new SchematicNumber(lineIndex, symbol, currentAdjustedIndex);
                currentAdjustedIndex = schematicSymbol.EndIndex + 1;
                result.Add(schematicSymbol);
            }
            else if (lMatch.Success)
            {
                string symbol = lMatch.Groups[1].Value;
                string number = lMatch.Groups[2].Value;
                
                var schematicSymbol= new SchematicNumber(lineIndex, symbol, currentAdjustedIndex);
                currentAdjustedIndex = schematicSymbol.EndIndex + 1;
                result.Add(schematicSymbol);
                var schematicNumber = new SchematicNumber(lineIndex, number, currentAdjustedIndex);
                currentAdjustedIndex = schematicNumber.EndIndex + 1;
                result.Add(schematicNumber);
            }
            else
            {
                var s = new SchematicNumber(lineIndex, currentVal, currentAdjustedIndex);
                currentAdjustedIndex = s.EndIndex + 1;
                result.Add(s);
            }
        }
        return result;
    }
}

public record SchematicNumber(int LineNumber, string Value, int Index)
{
    public bool IsEmpty => string.IsNullOrEmpty(Value) || Value == "_";
    public bool IsSymbol => !IsNumber && !IsEmpty;
    public int EndIndex => IsEmpty ? Index : Index + (Value.Length - 1);
    public bool IsNumber => int.TryParse(Value, out int _);
}
