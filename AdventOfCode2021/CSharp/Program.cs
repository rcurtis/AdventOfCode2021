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
Console.WriteLine($"Day 2 Part 2 answer: {day2Part2Answer}: multiplied: {day2Part2Answer.x * day2Part2Answer.y}");


var day3Input = File.ReadAllText("Day3Input.txt");
var day3Part1Answer = new Day3().Part1(day3Input);
Console.WriteLine($"Day 3 Part 1 answer: {day3Part1Answer}: multiplied: {day3Part1Answer.gamma * day3Part1Answer.epsilon}");

var day3Part2Answer = new Day3().Part2(day3Input);
Console.WriteLine($"Day 3 Part 2 answer: {day3Part2Answer}: multiplied: {day3Part2Answer.oxygen * day3Part2Answer.co2}");

var day4Input = File.ReadAllText("Day4Input.txt");
var day4Part1Answer = new Day4().Part1(day4Input);
Console.WriteLine($"Day 4 Part 1 answer: {day4Part1Answer}: multiplied: {day4Part1Answer.undaubedSum * day4Part1Answer.lastDrawn}");