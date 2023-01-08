namespace Aoc2022.Day13;

public static class Parser
{
    public static int ParseNum(Queue<char> input)
    {
        StringBuilder output = new();
        while (input.Any() && char.IsDigit(input.Peek()))
        {
            output.Append(input.Dequeue());
        }

        return int.Parse(output.ToString());
    }

    public static List<object> ParseList(Queue<char> input)
    {
        List<object> output = new();
        input.Dequeue();
        while (input.Peek() != ']')
        {
            object parsedItem = ParseItem(input);
            output.Add(parsedItem);
            if (input.Peek() == ',')
            {
                input.Dequeue();
            }
        }

        input.Dequeue();
        return output;
    }

    public static object ParseItem(Queue<char> data)
    {
        char next = data.Peek();
        if (char.IsDigit(next))
        {
            return ParseNum(data);
        }
        else if (next == '[')
        {
            return ParseList(data);
        }
        else
        {
            throw new Exception("");
        }
    }
}