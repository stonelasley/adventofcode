namespace Aoc2022.Day11;

public class Day11 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        List<Monkey> monkeys = Setup(inputProvider);
        return $"{MonkeyManager.Manage(20, monkeys)}";
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        List<Monkey> monkeys = Setup(inputProvider);
        long lcm = GetDivisor(monkeys);
        return $"{MonkeyManager.Manage(10000, monkeys, lcm)}";
    }
    private static long GetDivisor(List<Monkey> monkeys)
    {
        long lcm = monkeys[0].TestNumber;
        for (int i = 1; i < monkeys.Count; i++)
        {
            var gcd = Extensions.GCD(lcm, monkeys[i].TestNumber);
            var tempgcd = monkeys[i].TestNumber / gcd;
            lcm = lcm * tempgcd;
        }
        return lcm;
    }

    private static List<Monkey> Setup(IInputProvider inputProvider)
    {
        string[] lines = inputProvider.Read().Where(x => x != "").ToArray();
        List<Monkey> monks = new();
        for (int i = 0; i < lines.Length / 6; i++)
        {
            var r = lines[(i * 6)..((i + 1) * 6)];
            monks.Add(new Monkey(r));
        }

        return monks;
    }
}