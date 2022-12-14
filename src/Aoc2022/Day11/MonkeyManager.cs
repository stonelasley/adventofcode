namespace Aoc2022.Day11;

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

        List<Monkey> sortedMonkeys = monkeys.OrderByDescending(x => x.Inspections).ToList();

        return $"{(long)sortedMonkeys[0].Inspections * sortedMonkeys[1].Inspections}";
    }
}