namespace Aoc2023.Day05;

public record struct Interval(long Start, long End)
{
    public long Length => End - Start + 1;
}