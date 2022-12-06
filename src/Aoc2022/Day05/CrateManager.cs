namespace Aoc2022.Day05;

public class CrateManager
{
    public CrateManager(string stackCountLine)
    {
        Stacks = stackCountLine
            .Split(' ')
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => new Stack<char>())
            .ToList();
    }

    public List<Stack<char>> Stacks { get; } = new();

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
        var currentStack = Stacks.ElementAt(instruction.StartPosition - 1);
        var destinationStack = Stacks.ElementAt(instruction.Destination - 1);
        Stack<char> tempStack = new();
        for (var i = 0; i < instruction.CrateNumber; i++)
        {
            var crateToMove = currentStack.Pop();
            tempStack.Push(crateToMove);
        }

        while (tempStack.Count > 0)
        {
            var crate = tempStack.Pop();
            destinationStack.Push(crate);
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var stack in Stacks)
            sb.Append(stack.Peek().ToString());

        return sb.ToString();
    }
}