namespace Aoc2022.Day05;

public static class InstructionBuilder
{
    public static InstructionSet Parse(IList<string> rawInstructions)
    {
        List<TransferInstruction> transferInstructions = new();
        List<CrateLocationLine> crateLocations = new();
        var indexCount = string.Empty;
        foreach (var line in rawInstructions)
        {
            var inputLineType = InstructionLineClassifier.Classify(line);
            switch (inputLineType)
            {
                case InputType.Unknown:
                    continue;
                case InputType.CrateStackIndex:
                    crateLocations.Add(new CrateLocationLine(line));
                    continue;
                case InputType.StackCount:
                    indexCount = line.Trim();
                    continue;
                case InputType.TransferInstruction:
                    transferInstructions.Add(new TransferInstruction(line));
                    continue;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return new InstructionSet(indexCount, crateLocations, transferInstructions);
    }
}
