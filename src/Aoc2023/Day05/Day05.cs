namespace Aoc2023.Day05;

public class Day05 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        var input = inputProvider.Read();
        long[] seeds = ParseSeeds(input[0]);
        Dictionary<string, Mapper> mappers = new();

        List<string> mapperInput = new();
        for (int i = 2; i < input.Length - 2; i++)
        {
            string inputLine = input[i];
            if (string.IsNullOrEmpty(inputLine))
            {
                Mapper mapper = new(mapperInput.ToArray());
                mappers.Add(mapper.Name, mapper);
                mapperInput = new();
                continue;
            }
            mapperInput.Add(inputLine);
        }
        var mL = new Mapper(mapperInput.ToArray());
        mappers.Add(mL.Name, mL);

        return seeds.Select(seed =>
        {
            var soil = mappers["seed-to-soil map:"].Map(seed);
            var fertilizer = mappers["soil-to-fertilizer map:"].Map(soil);
            var water = mappers["fertilizer-to-water map:"].Map(fertilizer);
            var light = mappers["water-to-light map:"].Map(water);
            var temp = mappers["light-to-temperature map:"].Map(light);
            var humidity = mappers["temperature-to-humidity map:"].Map(temp);
            return mappers["humidity-to-location map:"].Map(humidity);

        }).Min().ToString();

    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        var input = inputProvider.Read();
        return "unsolved";
    }

    long[] ParseSeeds(string input) => Regex
                                      .Matches(input, @"(\d+)")
                                      .Select(x => long.Parse(x.Groups[1].Value)).ToArray();
}

public class Mapper
{
    public string Name { get; set; }
    public MapSpec[] Specs;

    public Mapper(string[] mappingInput)
    {
        Name = mappingInput[0];
        Specs = new ArraySegment<string>(mappingInput, 1, mappingInput.Length - 1)
                .Select(x => new MapSpec(x))
                .ToArray();
    }

    public long Map(long source)
    {
        MapSpec? spec = Specs.FirstOrDefault(x => x.HasMap(source));
        return spec?.Map(source) ?? source;
    }
}

public class MapSpec
{
    private long[] values;
    public MapSpec(string input)
    {
        values = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                      .Select(long.Parse)
                      .ToArray();

        DestinationStart = values[0];
        SourceStart = values[1];
        Length = values[2];

        SourceEnd = SourceStart + Length;
        DestinationEnd = DestinationStart + Length;

    }
    public long DestinationStart { get; }
    public long DestinationEnd { get; }
    public long SourceStart { get; }
    public long SourceEnd { get; }
    public long Length { get; }

    public bool HasMap(long num)
    {
        return num >= SourceStart && num <= SourceEnd;
    }
    
    public long Map(long num)
    {
        if (!HasMap(num)) return num;
        long offSet = num - SourceStart;
        return DestinationStart + offSet;

    }


};