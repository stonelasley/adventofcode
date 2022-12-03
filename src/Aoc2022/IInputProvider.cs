namespace Aoc2022;

public interface IInputProvider<T> where T : class
{
    string[] Read(string? fileName = null);
    string ReadAllText();
}

public class InputReader<T> : IInputProvider<T> where T : class
{
    public string[] Read(string? fileName = null) =>
        File.ReadLines(fileName ?? $"{typeof(T).Name}/input.txt").ToArray();

    public string ReadAllText() =>
        File.ReadAllText($"{typeof(T).Name}/input.txt").Trim();
}