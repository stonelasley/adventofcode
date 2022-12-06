namespace Aoc2022.Day03;

public class ElfGroup
{
    private readonly IList<RuckSack> _ruckSacks;

    public ElfGroup(IList<RuckSack> ruckSacks)
    {
        _ruckSacks = ruckSacks;
    }

    public int BadgeTotal
    {
        get
        {
            var badge = _ruckSacks
                .First()
                .Contents.Intersect(_ruckSacks.Skip(1).Take(1).First().Contents)
                .Intersect(_ruckSacks.Last().Contents)
                .First();

            return badge.Priority();
        }
    }
}
