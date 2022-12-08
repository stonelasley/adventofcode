namespace Aoc2022.Day07;

using System.Linq;

public class Day07 : IDay
{
    private const int FileSystemSize = 70000000;
    private const int UpdateSize = 30000000;

    public string SolveOne(IInputProvider inputProvider)
    {
        FileSystem fs = new(inputProvider.Read());
        int total = fs.AllDirectories.Where(x => x.Size <= 100000).Sum(x => x.Size);

        return $"{total}";
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        FileSystem fs = new(inputProvider.Read());

        int unusedSpace = FileSystemSize - fs.RootDirectory.Size;
        int total = fs.AllDirectories
            .Where(x => x.Size + unusedSpace > UpdateSize)
            .Min(x => x.Size);

        return $"{total}";
    }
}
