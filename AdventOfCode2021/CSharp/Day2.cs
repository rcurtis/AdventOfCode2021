using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021
{
    public class Day2
    {
        public (int x, int y) Part1(string input)
        {
            var lines = input.Split("\r\n");
            var instructions = lines.Select(it => it.Split(" "));

            var x = 0;
            var y = 0;

            foreach (var instruction in instructions)
            {
                var magnitude = int.Parse(instruction[1]);
                switch (instruction[0])
                {
                    case "forward":
                        x += magnitude;
                        break;
                    case "up":
                        y -= magnitude;
                        break;
                    case "down":
                        y += magnitude;
                        break;
                }
            }

            return (x, y);
        }
        
        public (int x, int y) Part2(string input)
        {
            var lines = input.Split("\r\n");
            var instructions = lines.Select(it => it.Split(" "));

            var x = 0;
            var y = 0;
            var aim = 0;

            foreach (var instruction in instructions)
            {
                var magnitude = int.Parse(instruction[1]);
                switch (instruction[0])
                {
                    case "forward":
                        x += magnitude;
                        y += aim * magnitude;
                        break;
                    case "up":
                        aim -= magnitude;
                        break;
                    case "down":
                        aim += magnitude;
                        break;
                }
            }

            return (x, y);
        }
    }
    
    [TestClass]
    public class Day2Tests
    {
        private string _smallInput = @"forward 5
down 5
forward 8
up 3
down 8
forward 2";
        
        [TestMethod]
        public void TestPart1()
        {
            var expected = (15, 10);
            var actual = new Day2().Part1(_smallInput);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestPart2()
        {
            var expected = (15, 60);
            var actual = new Day2().Part2(_smallInput);
            Assert.AreEqual(expected, actual);
        }
    }
}