using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021
{
    public class Day1
    {
        public int Part1(string input)
        {
            var tokens = input.Split("\r\n").Select(int.Parse).ToList();
            var increaseCount = 0;
            var last = tokens.First();
            foreach (var token in tokens.Skip(1))
            {
                if (token > last)
                    increaseCount++;
                last = token;
            }

            return increaseCount;
        }

        public int Part2(string input)
        {
            var tokens = input.Split("\r\n").Select(int.Parse);
            var windowed = tokens.Window(3).ToList();
            var increaseCount = 0;
            var last = windowed.First().Sum();
            foreach (var window in windowed.Skip(1))
            {
                var sum = window.Sum();
                if (sum > last)
                    increaseCount++;
                last = sum;
            }

            return increaseCount;
        }
    }
    
    [TestClass]
    public class Day1Tests
    {
        private string _smallInput = @"199
200
208
210
200
207
240
269
260
263";
        
        [TestMethod]
        public void TestPart1()
        {
            var expected = 7;
            var actual = new Day1().Part1(_smallInput);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestPart2()
        {
            var expected = 5;
            var actual = new Day1().Part2(_smallInput);
            Assert.AreEqual(expected, actual);
        }
    }
}