namespace Aoc2022.Day04;

public class ElfTeam
{
    public ElfTeam(string rangeOne, string rangeTwo)
    {
        var rangeOneArr = rangeOne.Split('-');
        var rangeTwoArr = rangeTwo.Split('-');
        RangeOne = new Range(int.Parse(rangeOneArr.First()), int.Parse(rangeOneArr.Last()));
        RangeTwo = new Range(int.Parse(rangeTwoArr.First()), int.Parse(rangeTwoArr.Last()));
    }

    public Range RangeOne { get; }
    public Range RangeTwo { get; }

    public int[] RangeOneArr =>
        Enumerable
            .Range(RangeOne.Start.Value, RangeOne.End.Value - RangeOne.Start.Value + 1)
            .ToArray();

    public int[] RangeTwoArr =>
        Enumerable
            .Range(RangeTwo.Start.Value, RangeTwo.End.Value - RangeTwo.Start.Value + 1)
            .ToArray();

    public bool OneIsSuper =>
        RangeOne.Start.Value <= RangeTwo.Start.Value && RangeOne.End.Value >= RangeTwo.End.Value;
    public bool TwoIsSuper =>
        RangeOne.Start.Value >= RangeTwo.Start.Value && RangeOne.End.Value <= RangeTwo.End.Value;
    public bool HasFullOverlap => OneIsSuper || TwoIsSuper;

    public int[] InterSection => RangeOneArr.Intersect(RangeTwoArr).ToArray();
}
