namespace Aoc2022.Day03;

public class Day03 : IDay
{
    public List<RuckSack> GetRuckSacks(IInputProvider inputProvider)
    {
        return inputProvider.Read().Select(x => new RuckSack(x)).ToList();
    }

    public string SolveOne(IInputProvider inputProvider) => GetRuckSacks(inputProvider).Sum(x => x.Priority).ToString();

    public List<ElfGroup> ElfGroups(IInputProvider inputProvider)
    {
            List<ElfGroup> elfGroups = new ();
            for (int i = 0; i < GetRuckSacks(inputProvider).Count / 3; i++)
            {
                elfGroups.Add(new ElfGroup(GetRuckSacks(inputProvider).Skip(i*3).Take(3).ToList()));
            }

            return elfGroups;
    }

    public string SolveTwo(IInputProvider inputProvider) => ElfGroups(inputProvider).Sum(x => x.BadgeTotal).ToString();

}