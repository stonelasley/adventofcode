namespace Aoc2022.Day04;

public class Day04 : IDay
{
    public string SolveOne(IInputProvider inputProvider) =>
        GetElfTeams(inputProvider).Where(x => x.HasFullOverlap).Count().ToString();

    public string SolveTwo(IInputProvider inputProvider) =>
        GetElfTeams(inputProvider).Where(x => x.InterSection.Length > 0).Count().ToString();

    public List<ElfTeam> GetElfTeams(IInputProvider inputProvider) =>
        inputProvider.Read().Select(line =>
        {
            var rangesArr = line.Split(',');
            return new ElfTeam(rangesArr[0], rangesArr[1]);
        }).ToList();
}