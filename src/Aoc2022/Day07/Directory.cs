namespace Aoc2022.Day07;

public class Directory
{
    public Directory(string name, Directory parent = null)
    {
        Name = name;
        Parent = parent;
    }

    public Directory? Parent { get; }
    public string Name { get; }
    public int DirectorySize => Directories.Sum(x => x.Size);
    public int FileSize => Files.Sum(x => x.Size);
    public int Size => DirectorySize + FileSize;
    public List<Directory> Directories { get; } = new();
    public List<DirectoryFile> Files { get; } = new();
}
