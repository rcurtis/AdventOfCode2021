using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021
{
    public class Day6
    {
        public static IEnumerable<int> Parse(string input) => input.Split(",").Select(int.Parse);

        public static List<int> NextDay(IEnumerable<int> input)
        {
            var minusOne = input.Select(it => it - 1);
            var negativeCount = minusOne.Count(it => it < 0);
            var negativesReset = minusOne.Select(it => it > -1 ? it : 6 ).ToList();
            
            for (int i = 0; i < negativeCount; i++)
                negativesReset.Add(8);

            return negativesReset;
        }

        public static List<int> RunIterations(IEnumerable<int> input, int numIterations)
        {
            var inpt = new List<int>(input);
            
            for (var i = 0; i < numIterations; i++)
                inpt = NextDay(inpt);

            return inpt;
        }

        public int Part1(string input)
        {
            var parsed = Parse(input);
            return RunIterations(parsed, 80).Count;
        }
        
        public int Part2(string input)
        {
            var parsed = Parse(input);
            return RunIterations(parsed, 256).Count;
        }
    }
    
    [TestClass]
    public class Day6Tests
    {
        private string _smallInput = @"3,4,3,1,2";
        
        [TestMethod]
        public void TestPart1()
        {
            var input = Day6.Parse(_smallInput);
            var expected = new List<int>{ 2,3,2,0,1 };
            var actual = Day6.NextDay(input);
            CollectionAssert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Iterate1()
        {
            var input = Day6.Parse(_smallInput);
            var expected = new List<int>{ 2,3,2,0,1 };
            var actual = Day6.RunIterations(input, 1);
            CollectionAssert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Iterate2()
        {
            var input = Day6.Parse(_smallInput);
            var expected = new List<int>{ 1,2,1,6,0,8 };
            var actual = Day6.RunIterations(input, 2);
            CollectionAssert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Iterate3()
        {
            var input = Day6.Parse(_smallInput);
            var expected = new List<int>{ 0,1,0,5,6,7,8 };
            var actual = Day6.RunIterations(input, 3);
            CollectionAssert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Iterate18()
        {
            var input = Day6.Parse(_smallInput);
            var expected = new List<int>{ 6,0,6,4,5,6,0,1,1,2,6,0,1,1,1,2,2,3,3,4,6,7,8,8,8,8 };
            var actual = Day6.RunIterations(input, 18);
            CollectionAssert.AreEqual(expected, actual);
        }
        
        [Ignore]
        [TestMethod]
        public void TestPart2()
        {
            var expected = (148, 13);
            var actual = new Day4().Part2(_smallInput);
            Assert.AreEqual(expected, actual);
        }
    }
}