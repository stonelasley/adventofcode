namespace Aoc2022.Day05;

public class CrateLocationLine
{
    public CrateLocationLine(string inputLine)
    {
        var chunks = ChunkString(inputLine, 4);
        for (var i = 0; i < chunks.Count; i++)
        {
            var val = chunks[i].Replace("[", "").Replace("]", "").Trim();
            if (!string.IsNullOrEmpty(val))
                CrateLocations.Add(new CrateLocation(char.Parse(val), i));
        }
    }

    public List<CrateLocation> CrateLocations { get; } = new();

    private List<string> ChunkString(string input, int chunkSize)
    {
        List<string> chunks = new();
        var chunkCount = Convert.ToInt32((input.Length + 1) / chunkSize);
        for (var i = 0; i <= chunkCount; i++)
        {
            var chunk = new string(input.Skip(i * chunkSize).Take(chunkSize).ToArray());
            chunks.Add(chunk);
        }

        return chunks;
    }

    // public override bool IsValid(string line) => line.Contains("[");
}