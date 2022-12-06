namespace Aoc2022.Day05;

public class TransferInstruction
{
    public TransferInstruction(string instructionInput)
    {
        var splitInstructions = instructionInput.Split(' ').ToList();
        CrateNumber = int.Parse(splitInstructions[splitInstructions.IndexOf("move") + 1]);
        StartPosition = int.Parse(splitInstructions[splitInstructions.IndexOf("from") + 1]);
        Destination = int.Parse(splitInstructions[splitInstructions.IndexOf("to") + 1]);
    }

    public int StartPosition { get; }
    public int Destination { get; }
    public int CrateNumber { get; }
}