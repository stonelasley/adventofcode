namespace Aoc2022.Day03;

public class Day03 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        return GetRuckSacks(inputProvider).Sum(x => x.Priority).ToString();
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        return ElfGroups(inputProvider).Sum(x => x.BadgeTotal).ToString();
    }

    public List<RuckSack> GetRuckSacks(IInputProvider inputProvider)
    {
        return inputProvider.Read().Select(x => new RuckSack(x)).ToList();
    }

    public List<ElfGroup> ElfGroups(IInputProvider inputProvider)
    {
        List<ElfGroup> elfGroups = new();
        for (var i = 0; i < GetRuckSacks(inputProvider).Count / 3; i++)
            elfGroups.Add(new ElfGroup(GetRuckSacks(inputProvider).Skip(i * 3).Take(3).ToList()));

        return elfGroups;
    }
}
