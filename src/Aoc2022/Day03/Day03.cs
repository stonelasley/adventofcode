namespace Aoc2022.Day03;

public class Day03
{
    private readonly IInputProvider<Day03> _inputProvider;

    public Day03(IInputProvider<Day03> inputProvider)
    {
        _inputProvider = inputProvider;
    }

    public List<RuckSack> GetRuckSacks()
    {
        return _inputProvider.Read().Select(x => new RuckSack(x)).ToList();
    }

    public int RuckSackTotal() => GetRuckSacks().Sum(x => x.Priority);

    public List<ElfGroup> ElfGroups
    {
        get
        {
            List<ElfGroup> elfGroups = new ();
            for (int i = 0; i < GetRuckSacks().Count / 3; i++)
            {
                elfGroups.Add(new ElfGroup(GetRuckSacks().Skip(i*3).Take(3).ToList()));
            }

            return elfGroups;
        }
    }

    public int BadgeTotal() => ElfGroups.Sum(x => x.BadgeTotal);

}