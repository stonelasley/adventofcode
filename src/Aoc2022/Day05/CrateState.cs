namespace Aoc2022.Day05;

public class CrateState
{
    private const int StackSize = 9999;

    public CrateState(string stackCountLine)
    {
        Stacks = stackCountLine
            .Split(' ').Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => new Stack<char>(StackSize))
            .ToList();
    }

    public List<Stack<char>> Stacks { get; }

    public void Initialize(List<CrateLocationLine> initialState)
    {
        initialState.Reverse();
        foreach (var crateLocationLine in initialState)
        foreach (var crateLocation in crateLocationLine.CrateLocations)
            Stacks.ElementAt(crateLocation.StackNumber).Push(crateLocation.Crate);
    }

    public void ProcessTransfer(TransferInstruction instruction)
    {
        var currentStack = Stacks.ElementAt(instruction.StartPosition - 1);
        var destinationStack = Stacks.ElementAt(instruction.Destination - 1);
        for (var i = 0; i < instruction.CrateNumber; i++)
        {
            var crateToMove = currentStack.Pop();
            destinationStack.Push(crateToMove);
        }
    }
    public void ProcessBatchTransfer(TransferInstruction instruction)
    {
        Stack<char> tempStack = new ();
        var currentStack = Stacks.ElementAt(instruction.StartPosition - 1);
        var destinationStack = Stacks.ElementAt(instruction.Destination - 1);
        for (var i = 0; i < instruction.CrateNumber; i++)
        {
            var crateToMove = currentStack.Pop();
            tempStack.Push(crateToMove);
        }

        while (tempStack.Count > 0)
        {
            char crate = tempStack.Pop();
            destinationStack.Push(crate);
        }
   }
}