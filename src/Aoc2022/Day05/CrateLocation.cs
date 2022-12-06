namespace Aoc2022.Day05;

public class CrateLocation
{
    public CrateLocation(char crate, int stackIndex)
    {
        Crate = crate;
        StackNumber = stackIndex;
    }

    public char Crate { get; }
    public int StackNumber { get; }
}