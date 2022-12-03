namespace Aoc2022.Day03;

public class Day03
{
    private readonly IInputProvider<Day03> _inputProvider;

    public Day03(IInputProvider<Day03> inputProvider)
    {
        _inputProvider = inputProvider;
    }

    public IEnumerable<RuckSack> GetRuckSacks()
    {
        return _inputProvider.Read().Select(x => new RuckSack(x));
    }

    public int RuckSackTotal() => GetRuckSacks().Sum(x => x.Priority);
}