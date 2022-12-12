namespace Aoc2022.Day11;

using System.Runtime.CompilerServices;

public class Day11 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        List<Monkey> monkeys = Setup(inputProvider);
        return $"{MonkeyManager.Manage(20, monkeys)}";
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

    public string SolveTwo(IInputProvider inputProvider)
    {
        List<Monkey> monkeys = Setup(inputProvider);
        long lcm = monkeys[0].TestNumber;
        for (int i = 1; i < monkeys.Count; i++)
        {
            var num = lcm * monkeys[i].TestNumber;
            var denom = GCD(lcm, monkeys[i].TestNumber);
            lcm = num / denom;
        }
        return $"{MonkeyManager.Manage(10000, monkeys, lcm)}";
    }

    private static long GCD(long a, long b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }
}

public static class MonkeyManager
{
    public static string Manage(int roundsCount, List<Monkey> monkeys, long divisor = 0)
    {
        int rounds = 0;
        while (rounds++ < roundsCount)
        {
            foreach (var monkey in monkeys)
            {
                while (monkey.Items.Any())
                {
                    monkey.Inspections++;
                    long item = monkey.Items[0];
                    long newWorry =
                        divisor == 0
                            ? monkey.Operation(item) / 3L
                            : monkey.Operation(item) % divisor;

                    bool b = monkey.Test(newWorry);
                    int targetMonkeyIndex = b ? monkey.TrueMonkey : monkey.FalseMonkey;
                    monkeys[targetMonkeyIndex].Items.Add(newWorry);
                    monkey.Items.Remove(item);
                }
            }
        }

        List<Monkey> inspections = monkeys.OrderByDescending(x => x.Inspections).Take(2).ToList();

        return $"{inspections[0].Inspections * inspections[1].Inspections}";
    }
}
