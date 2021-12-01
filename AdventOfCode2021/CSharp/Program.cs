using System;
using System.IO;
using AdventOfCode2021;

var day1Input = File.ReadAllText("Day1Input.txt");
var day1Part1 = new Day1().Part1(day1Input);
Console.WriteLine($"Day 1 Part 1 answer: {day1Part1}");

var day1Part2 = new Day1().Part2(day1Input);
Console.WriteLine($"Day 1 Part 2 answer: {day1Part2}");