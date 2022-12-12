namespace Aoc2022.Day11;

public class Monkey
{
    public int Inspections { get; set; } = 0;
    public int Number { get; init; }
    public List<long> Items { get; init; } = new();
    public int TrueMonkey { get; init; }
    public int FalseMonkey { get; init; }
    public int TestNumber { get; init; }
    public Predicate<long> Test { get; init; }
    public Func<long, long> Operation;

    public Monkey(string[] input)
    {
        for (int i = 0; i < 6; i++)
        {
            string line = input[i].Trim();

            if (line[0] == 'M')
            {
                Number = int.Parse(line[7..8]);
            }
            if (line[0] == 'S')
            {
                Items = new(line[15..].Split(',').Select(long.Parse));
                var b = 0;
            }
            if (line[0] == 'O')
            {
                var operationValRaw = line[23..];
                if (operationValRaw == "old")
                {
                    switch (line[21])
                    {
                        case '+':
                            Operation = x => x + x;
                            break;
                        case '-':
                            Operation = x => x - x;
                            break;
                        case '*':
                            Operation = x => x * x;
                            break;
                        case '/':
                            Operation = x => x / x;
                            break;
                    }
                }
                else
                {
                    int operationVal = int.Parse(line[22..]);
                    switch (line[21])
                    {
                        case '+':
                            Operation = x => x + operationVal;
                            break;
                        case '-':
                            Operation = x => x - operationVal;
                            break;
                        case '*':
                            Operation = x => x * operationVal;
                            break;
                        case '/':
                            Operation = x => x / operationVal;
                            break;
                    }
                }
            }
            if (line[0] == 'T')
            {
                TestNumber = int.Parse(line[19..]);
                Test = number => number % TestNumber == 0;
            }
            if (line[3..7] == "true")
            {
                TrueMonkey = int.Parse(line[24..]);
            }
            if (line[3..8] == "false")
            {
                FalseMonkey = int.Parse(line[25..]);
            }
        }
    }
}
