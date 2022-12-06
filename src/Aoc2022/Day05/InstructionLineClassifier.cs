using System.Text.RegularExpressions;

namespace Aoc2022.Day05;

public class InstructionLineClassifier
{
    public static InputType Classify(string lineInput)
    {
        var line = lineInput.Trim();
        if (line.Contains('[')) return InputType.CrateStackIndex;

        if (line.Contains("move")) return InputType.TransferInstruction;

        if (Regex.IsMatch(line, "^[0-9]{1,}")) return InputType.StackCount;
        return InputType.Unknown;
    }
}

public enum InputType
{
    CrateStackIndex,
    StackCount,
    TransferInstruction,
    Unknown
}