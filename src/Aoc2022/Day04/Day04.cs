namespace Aoc2022.Day04;

public class Day04 : IDay
{
    public int SolveOne(IInputProvider inputProvider) =>
        GetElfTeams(inputProvider).Where(x => x.HasFullOverlap).Count();

    public int SolveTwo(IInputProvider inputProvider) =>
        GetElfTeams(inputProvider).Where(x => x.InterSection.Length > 0).Count();

    public List<ElfTeam> GetElfTeams(IInputProvider inputProvider) =>
        inputProvider.Read().Select(line =>
        {
            var rangesArr = line.Split(',');
            return new ElfTeam(rangesArr[0], rangesArr[1]);
        }).ToList();
}