namespace Aoc2023.Day02;

public class CubeSet
{
    public List<CubeCount> CubeCounts { get; private set; } = new();

    public CubeSet(string input)
    {
        string[] cubeCounts = input.Split(',', StringSplitOptions.TrimEntries);
        foreach (var cubeCount in cubeCounts)
        {
            CubeCounts.Add(new CubeCount(cubeCount));
        }
    }
    
    public bool IsPossible(Dictionary<string, int> maxColors)
    {
        foreach (var colorKey in maxColors.Keys)
        {
            int max = maxColors[colorKey];
            CubeCount? cubeCount = CubeCounts.FirstOrDefault(x => x.Color == colorKey);
            if(cubeCount == null) continue;
            if (cubeCount.Count > max)
            {
                return false;
            }

        }

        return true;
    }
}