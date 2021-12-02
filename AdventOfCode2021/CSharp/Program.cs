using System;
using System.IO;
using AdventOfCode2021;

var day1Input = File.ReadAllText("Day1Input.txt");
var day1Part1 = new Day1().Part1(day1Input);
Console.WriteLine($"Day 1 Part 1 answer: {day1Part1}");

var day1Part2 = new Day1().Part2(day1Input);
Console.WriteLine($"Day 1 Part 2 answer: {day1Part2}");


var day2Input = File.ReadAllText("Day2Input.txt");
var day2Part1Answer = new Day2().Part1(day2Input);
Console.WriteLine($"Day 2 Part 1 answer: {day2Part1Answer}: multiplied: {day2Part1Answer.x * day2Part1Answer.y}");

var day2Part2Answer = new Day2().Part2(day2Input);
Console.WriteLine($"Day 2 Part 1 answer: {day2Part2Answer}: multiplied: {day2Part2Answer.x * day2Part2Answer.y}");