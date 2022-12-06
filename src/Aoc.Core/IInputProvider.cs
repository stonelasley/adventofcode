namespace Aoc.Core;

public interface IInputProvider
{
    string[] Read();
    string ReadAllText();
}

public class InputReader : IInputProvider
{
    private readonly string _directory;

    public InputReader(string directory)
    {
        _directory = directory;
    }

    public string[] Read()
    {
        return File.ReadLines($"{_directory}/input.txt").ToArray();
    }

    public string ReadAllText()
    {
        return File.ReadAllText($"{_directory}/input.txt").Trim();
    }
}