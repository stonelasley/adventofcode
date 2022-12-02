// See https://aka.ms/new-console-template for more information
using Aoc2022;
using Aoc2022.Day01;


var day1 = new Day01(new InputProvider<Day01>());

Console.WriteLine($"Day One: {day1.GetMost()}");
Console.WriteLine($"Day One Part Two: {day1.GetTopThree()}");
