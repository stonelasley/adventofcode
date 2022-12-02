namespace Aoc2022;

public interface IInputProvider<T> where T : class
{
    string[] Read(string? fileName = null);
}

public class InputProvider<T> : IInputProvider<T> where T : class
{
    public string[] Read(string? fileName = null) =>
        File.ReadLines(fileName ?? $"{typeof(T).Name}/input.txt").ToArray(); 
}