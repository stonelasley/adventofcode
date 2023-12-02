namespace Aoc2023.Day02;

public class CubeSet
{
    private readonly Dictionary<string, int> _maxCubes;
    public List<CubeCount> CubeCounts { get; private set; } = new();

    public CubeSet(string input, Dictionary<string, int>? maxCubes = null)
    {
        _maxCubes = maxCubes ?? new Dictionary<string, int>();
        string[] cubeCounts = input.Split(',', StringSplitOptions.TrimEntries);
        foreach (var cubeCount in cubeCounts)
        {
            CubeCounts.Add(new CubeCount(cubeCount));
        }
    }

    public bool Possible
    {
        get
        {

            foreach (var colorKey in _maxCubes.Keys)
            {
                int max = _maxCubes[colorKey];
                CubeCount? cubeCount = CubeCounts.FirstOrDefault(x => x.Color == colorKey);
                if (cubeCount == null) continue;
                if (cubeCount.Count > max)
                {
                    return false;
                }

            }
            return true;
        }
    }
}