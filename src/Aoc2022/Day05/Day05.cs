namespace Aoc2022.Day05;

public class Day05 : IDay
{
    public int SolveOne(IInputProvider inputProvider)
    {
        List<TransferInstruction> transferInstructions = new();
        List<CrateLocationLine> crateLocations = new();
        var crateStateLine = "";
        var fileLines = inputProvider.Read();
        foreach (var line in fileLines)
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
                    crateStateLine = line;
                    continue;
                case InputType.TransferInstruction:
                    transferInstructions.Add(new TransferInstruction(line));
                    continue;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        var crateState = new CrateState(crateStateLine);
        crateState.Initialize(crateLocations);
        transferInstructions.ForEach(crateState.ProcessTransfer);
        foreach (var stack in crateState.Stacks)
        {
            var top = stack.Peek();
            Console.Write(top);
        }

        return 1;
    }

    public int SolveTwo(IInputProvider inputProvider)
    {
        return -1;
    }
}