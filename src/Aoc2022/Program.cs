// See https://aka.ms/new-console-template for more information
using Aoc2022;
using Aoc2022.Day01;
using Aoc2022.Day02;


var day1 = new Day01(new InputProvider<Day01>());
var day2 = new Day02(new InputProvider<Day02>());

Console.WriteLine($"Day One: {day1.GetMost()}");
Console.WriteLine($"Day One Part Two: {day1.GetTopThree()}");
Console.WriteLine($"Day Two: {day2.GetGame().Score}");
Console.WriteLine($"Day Two Part Two: {day2.GetGame().Score2}");
