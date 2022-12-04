namespace Aoc2022.Day04;

public class Day04 : IDay
{
    public int SolveOne(IInputProvider inputProvider) =>
        GetElfTeams(inputProvider).Where(x => x.HasFullOverlap).Count();
    public int SolveTwo(IInputProvider inputProvider) => 0;

    public List<ElfTeam> GetElfTeams(IInputProvider inputProvider)
    {
        return inputProvider.Read().Select(line =>
        {
            var rangesArr = line.Split(',');
            var rangeOne = rangesArr[0];
            var rangeTwo = rangesArr[1];
            return new ElfTeam(rangeOne, rangeTwo);

        }).ToList();
    }
    
}

public class ElfTeam
{
    public Range RangeOne { get; }
    public Range RangeTwo { get; }
    public bool OneIsSuper => RangeOne.Start.Value <= RangeTwo.Start.Value && RangeOne.End.Value >= RangeTwo.End.Value;
    public bool TwoIsSuper => RangeOne.Start.Value >= RangeTwo.Start.Value && RangeOne.End.Value <= RangeTwo.End.Value;
    public bool HasFullOverlap => OneIsSuper || TwoIsSuper;
    public ElfTeam(string rangeOne, string rangeTwo)
    {
        var rangeOneArr = rangeOne.Split('-');
        var rangeTwoArr = rangeTwo.Split('-');
        RangeOne = new (int.Parse(rangeOneArr.First()), int.Parse(rangeOneArr.Last()));
        RangeTwo = new (int.Parse(rangeTwoArr.First()), int.Parse(rangeTwoArr.Last()));

    }
}