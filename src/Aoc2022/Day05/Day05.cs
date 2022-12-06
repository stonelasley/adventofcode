namespace Aoc2022.Day05;

public class Day05 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        var instructions = InstructionBuilder.Parse(inputProvider.Read());

        var crateManager = new CrateManager(instructions.StackIndexLine);
        crateManager.Initialize(instructions.InitialLocations);
        instructions.TransferInstructions.ForEach(crateManager.ProcessTransfer);

        return crateManager.ToString();
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        var instructions = InstructionBuilder.Parse(inputProvider.Read());

        var crateState = new CrateManager(instructions.StackIndexLine);
        crateState.Initialize(instructions.InitialLocations);
        instructions.TransferInstructions.ForEach(crateState.ProcessBatchTransfer);

        return crateState.ToString();
    }
}