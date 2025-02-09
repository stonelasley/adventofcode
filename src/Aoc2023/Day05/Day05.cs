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

        return seeds
            .Select(seed =>
            {
                var soil = mappers["seed-to-soil map:"].Map(seed);
                var fertilizer = mappers["soil-to-fertilizer map:"].Map(soil);
                var water = mappers["fertilizer-to-water map:"].Map(fertilizer);
                var light = mappers["water-to-light map:"].Map(water);
                var temp = mappers["light-to-temperature map:"].Map(light);
                var humidity = mappers["temperature-to-humidity map:"].Map(temp);
                return mappers["humidity-to-location map:"].Map(humidity);
            })
            .Min()
            .ToString();
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        string[] lines = inputProvider.Read();
        List<Interval> seedIntervals = ParseSeedIntervals(lines[0]);
        Dictionary<string, Mapper> mappers = BuildMappers(lines);

        List<Interval> soilIntervals = MapIntervals(seedIntervals, mappers["seed-to-soil map:"]);
        List<Interval> fertIntervals = MapIntervals(
            soilIntervals,
            mappers["soil-to-fertilizer map:"]
        );
        List<Interval> waterIntervals = MapIntervals(
            fertIntervals,
            mappers["fertilizer-to-water map:"]
        );
        List<Interval> lightIntervals = MapIntervals(
            waterIntervals,
            mappers["water-to-light map:"]
        );
        List<Interval> tempIntervals = MapIntervals(
            lightIntervals,
            mappers["light-to-temperature map:"]
        );
        List<Interval> humIntervals = MapIntervals(
            tempIntervals,
            mappers["temperature-to-humidity map:"]
        );
        List<Interval> locationIntervals = MapIntervals(
            humIntervals,
            mappers["humidity-to-location map:"]
        );

        // 4) The puzzle wants the *lowest* location
        long minLocation = locationIntervals.Min(iv => iv.Start);
        return minLocation.ToString();
    }

    long[] ParseSeeds(string input) =>
        Regex.Matches(input, @"(\d+)").Select(x => long.Parse(x.Groups[1].Value)).ToArray();

    private List<Interval> ParseSeedIntervals(string seedLine)
    {
        // e.g. "seeds: 79 14 55 13"
        // becomes pairs (79,14) and (55,13).
        // => intervals [79..(79+14-1)] and [55..(55+13-1)]
        var numbers = Regex.Matches(seedLine, @"\d+").Select(m => long.Parse(m.Value)).ToArray();

        List<Interval> intervals = new();
        for (int i = 0; i < numbers.Length; i += 2)
        {
            long start = numbers[i];
            long length = numbers[i + 1];
            long end = start + length - 1; // inclusive
            intervals.Add(new Interval(start, end));
        }
        return intervals;
    }

    Dictionary<string, Mapper> BuildMappers(string[] input)
    {
        Dictionary<string, Mapper> mappers = new();
        List<string> mapperInput = new();

        // i = 2: skip line 0 (seeds: ...) and line 1 (empty or puzzle text).
        // input.Length - 2: skip the last lines if they are blank or puzzle text.
        for (int i = 2; i < input.Length - 2; i++)
        {
            string inputLine = input[i];
            if (string.IsNullOrEmpty(inputLine))
            {
                // Construct a Mapper from the lines read so far
                Mapper mapper = new(mapperInput.ToArray());
                mappers.Add(mapper.Name, mapper);
                mapperInput.Clear();
            }
            else
            {
                mapperInput.Add(inputLine);
            }
        }

        // Build the last mapper, after the loop ends.
        if (mapperInput.Count > 0)
        {
            Mapper lastMapper = new(mapperInput.ToArray());
            mappers.Add(lastMapper.Name, lastMapper);
        }

        return mappers;
    }

    private List<Interval> MapIntervals(List<Interval> sourceIntervals, Mapper mapper)
    {
        List<Interval> result = [];

        foreach (Interval interval in sourceIntervals)
        {
            long current = interval.Start;

            while (current <= interval.End)
            {
                bool foundSpec = false;

                foreach (MapSpec spec in mapper.Specs)
                {
                    if (spec.HasMap(current))
                    {
                        long subEnd = Math.Min(interval.End, spec.SourceEnd);
                        long count = subEnd - current + 1;

                        long offset = current - spec.SourceStart;
                        long destStart = spec.DestinationStart + offset;
                        long destEnd = destStart + count - 1;

                        result.Add(new Interval(destStart, destEnd));

                        current = subEnd + 1;
                        foundSpec = true;
                        break;
                    }
                }

                if (!foundSpec)
                {
                    long nextSpecStart = long.MaxValue;

                    foreach (MapSpec s in mapper.Specs)
                    {
                        if (s.SourceStart > current)
                        {
                            nextSpecStart = Math.Min(nextSpecStart, s.SourceStart);
                        }
                    }

                    long identityEnd =
                        (nextSpecStart == long.MaxValue) ? interval.End : (nextSpecStart - 1);

                    if (identityEnd >= current)
                    {
                        result.Add(new Interval(current, identityEnd));
                        current = identityEnd + 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        return result;
    }
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
    public long DestinationStart { get; }
    public long DestinationEnd { get; }
    public long SourceStart { get; }
    public long SourceEnd { get; }
    public long Length { get; }

    public MapSpec(string input)
    {
        var values = input
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToArray();

        DestinationStart = values[0];
        SourceStart = values[1];
        Length = values[2];

        // FIXED: length means the count of mapped values
        SourceEnd = SourceStart + Length - 1;
        DestinationEnd = DestinationStart + Length - 1;
    }

    public bool HasMap(long num)
    {
        // Covers exactly [SourceStart..SourceEnd], inclusive
        return (num >= SourceStart && num <= SourceEnd);
    }

    public long Map(long num)
    {
        // If in the source range, shift by the offset to get the destination.
        if (!HasMap(num))
            return num;

        long offset = num - SourceStart; // e.g. if num=99, SourceStart=98 => offset=1
        return DestinationStart + offset; // e.g. DestinationStart=50 => 50+1=51
    }
}
