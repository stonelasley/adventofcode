namespace Aoc2022.Day07;

public class FileSystem
{
    public Directory? RootDirectory { get; }
    public List<Directory> AllDirectories = new();

    public FileSystem(string[] commands)
    {
        Directory? currentDirectory = null;
        for (int i = 0; i < commands.Length; i++)
        {
            var line = commands[i];
            var lineSegments = line.Split(' ');

            if (line.Contains("$ ls"))
            {
                continue;
            }

            if (RootDirectory == null)
            {
                RootDirectory = new Directory("Root");
                AllDirectories.Add(RootDirectory);
            }

            if (line.Contains("$ cd /"))
            {
                currentDirectory = RootDirectory;
                continue;
            }

            if (line.Contains("$ cd .."))
            {
                currentDirectory = currentDirectory.Parent ?? RootDirectory;
                continue;
            }

            if (line.Contains("$ cd "))
            {
                string dirName = lineSegments[2];
                var existingDir = currentDirectory.Directories.FirstOrDefault(
                    x => x.Name == dirName
                );
                currentDirectory = existingDir;
                continue;
            }

            if (line.StartsWith("dir "))
            {
                string dirName = lineSegments[1];
                var newDir = new Directory(dirName, currentDirectory);
                currentDirectory.Directories.Add(newDir);
                AllDirectories.Add(newDir);
                continue;
            }

            var size = int.Parse(lineSegments[0]);
            var fileName = lineSegments[1];
            currentDirectory.Files.Add(new DirectoryFile(fileName, size));
        }
    }
}
