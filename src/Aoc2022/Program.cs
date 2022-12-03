using Aoc2022;
using Aoc2022.Day01;
using Aoc2022.Day02;

Day01 day1 = new (new InputReader<Day01>());
Day02 day2 = new (new InputReader<Day02>());

Console.WriteLine($"Day One: {day1.GetMost()}");
Console.WriteLine($"Day One Part Two: {day1.GetTopThree()}");
Console.WriteLine($"Day Two: {day2.GetGame().Score}");
Console.WriteLine($"Day Two Part Two: {day2.GetGame().ScoreTwo}");
