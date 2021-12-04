using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021
{
    public class Day4
    {
        private record Spot
        {
            public int Value { get; set; }
            public bool Daubed { get; set; }
        }

        private class Card
        {
            public IEnumerable<Spot> Spots { get; init; }

            public bool HasBingo()
            {
                var rows = Spots.Chunk(5).ToList();
                var columns = rows.Transpose().ToList();
                rows.AddRange(columns);
                var bingoFound = rows
                    .Select(row => row.All(it => it.Daubed))
                    .Any(it => it);
                
                return bingoFound;
            }

            public int GetUndaubedSum()
            {
                return Spots.Where(it => !it.Daubed).Sum(it => it.Value);
            }
        }

        public (int undaubedSum, int lastDrawn) Part1(string input)
        {
            var lines = input.Split("\r\n\r\n");
            var ballDraw = lines.First().Split(",").Select(int.Parse);
            var cards = lines.Skip(1)
                .Select(ParseCard)
                .Select(it => new Card { Spots = it })
                .ToList();

            foreach (var ball in ballDraw)
            {
                for (var i = 0; i < cards.Count; i++)
                {
                    var card = cards[i];
                    var spot = card.Spots.FirstOrDefault(it => it.Value == ball);
                    if (spot == null) 
                        continue;
                    
                    spot.Daubed = true;
                    if (card.HasBingo())
                        return (card.GetUndaubedSum(), ball);
                }
            }

            throw new Exception("Bingo not found");
        }

        private List<Spot> ParseCard(string it)
        {
            return it.Replace("\r\n", " ")
                .Replace("  ", " ")
                .Trim()
                .Split(" ")
                .Select(value => new Spot { Value = int.Parse(value) })
                .ToList();
        }

        public (int sum, int number) Part2(string input)
        {
            return (0, 0);
        }
    }
    
    [TestClass]
    public class Day4Tests
    {
        private string _smallInput = @"7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19

 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7";
        
        [TestMethod]
        public void TestPart1()
        {
            (int undaubedSum, int lastDrawn) expected = (188, 24);
            var actual = new Day4().Part1(_smallInput);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestPart2()
        {
            var expected = (23, 10);
            var actual = new Day4().Part2(_smallInput);
            Assert.AreEqual(expected, actual);
        }
    }
}