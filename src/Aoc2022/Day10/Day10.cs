namespace Aoc2022.Day10;

public class Day10 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        return $"{CathodRayTube.Execute(inputProvider.Read())}";
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        return CathodRayTube.DrawScreen(inputProvider.Read());
    }
}

public static class CathodRayTube
{
    public static int Execute(string[] inputs)
    {
        int sum = 1;
        int cycleCount = 0;
        int power = 0;
        foreach (string line in inputs)
        {
            Tick(ref cycleCount, ref power, sum);
            if (line.StartsWith("noop"))
            {
                continue;
            }
            Tick(ref cycleCount, ref power, sum);
            sum += int.Parse(line[4..]);
        }
        return power;
    }

    public static string DrawScreen(string[] inputs)
    {
        int cycleCount = 0;
        int spriteCol = 1;
        int currentRow = 0;
        bool[,] screenGrid = new bool[6, 40];
        foreach (string line in inputs)
        {
            screenGrid[currentRow, cycleCount] = PixelInFrame(cycleCount, spriteCol);
            ScreenTick(ref cycleCount, ref currentRow);
            
            if (line.StartsWith("noop"))
            {
                continue;
            }
            
            screenGrid[currentRow, cycleCount] = PixelInFrame(cycleCount, spriteCol);
            ScreenTick(ref cycleCount, ref currentRow);
            
            spriteCol += int.Parse(line[5..]);
        }
        Render(screenGrid);
        return "See Above Output";
    }
    public static bool PixelInFrame(int cycleCount, int spriteCol) =>
        cycleCount >= spriteCol - 1 && cycleCount <= spriteCol + 1;

    public static void ScreenTick(ref int cycleCount, ref int currentRow)
    {
        cycleCount++;
        if (cycleCount == 40)
        {
            currentRow++;
            cycleCount = 0;
        }
    }

    private static void Render(bool[,] crt)
    {
        for (int y = 0; y < 6; y++)
        {
            for (int x = 0; x < 40; x++)
            {
                string pixel = crt[y, x] ? " X " : "   ";
                Console.Write(pixel);
            }
            Console.WriteLine();
        }
    }

    public static void Tick(ref int cycleCount, ref int power, int sum)
    {
        cycleCount++;
        if ((cycleCount - 20) % 40 == 0)
        {
            power += cycleCount * sum;
        }
    }
}
