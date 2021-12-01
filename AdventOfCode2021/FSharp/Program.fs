

open FSharp
open System

let day1Input = Day1.parseFileInput "Day1Input.txt"
let day1Part1 = Day1.part1 day1Input
Console.WriteLine $"Day 1 Part 1: {day1Part1}"

let day1Part2 = Day1.part2 day1Input
Console.WriteLine $"Day 1 Part 2: {day1Part2}"