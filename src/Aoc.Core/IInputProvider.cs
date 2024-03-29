﻿namespace Aoc.Core;

using System.Diagnostics.CodeAnalysis;

public interface IInputProvider
{
    string[] Read();
    string ReadAllText();
}

[ExcludeFromCodeCoverage]
public class InputReader : IInputProvider
{
    private readonly string _directory;

    public InputReader(string directory)
    {
        _directory = directory;
    }

    public string[] Read() =>
      File.ReadLines($"{_directory}/input.txt").ToArray();

    public string ReadAllText()
    {
        return File.ReadAllText($"{_directory}/input.txt").Trim();
    }
}
