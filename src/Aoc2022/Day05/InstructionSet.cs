namespace Aoc2022.Day05;

public record InstructionSet(string StackIndexLine, List<CrateLocationLine> InitialLocations,
    List<TransferInstruction> TransferInstructions);