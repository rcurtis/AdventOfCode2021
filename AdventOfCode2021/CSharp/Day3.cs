using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021
{
    public class Day3
    {
        public (int gamma, int epsilon) Part1(string input)
        {
            var lines = input.Split("\r\n");
            var columnCount = lines.First().Length;
            var counts = string.Empty;
            for (var i = 0; i < columnCount; i++)
            {
                var count = 0;
                foreach (var line in lines)
                {
                    if (line[i] == '0')
                        count--;
                    else 
                        count++;
                }
                counts += count > 0 ? "1" : "0";
            }

            var inverseCount = new string(counts.Select(it => it == '1' ? '0' : '1').ToArray());
            var gamma = Convert.ToInt32(counts, 2);
            var epsilon = Convert.ToInt32(inverseCount, 2);
            return (gamma, epsilon);
        }
        
        public (int oxygen, int co2) Part2(string input)
        {
            var lines = input.Split("\r\n");
            var columnCount = lines.First().Length;

            string NarrowAndPrefer(string[] inpt, int prefer)
            {
                while (true)
                {
                    for (var i = 0; i < columnCount; i++)
                    {
                        var count = 0;
                        foreach (var line in inpt)
                        {
                            if (line[i] == '0')
                                count--;
                            else 
                                count++;
                        }

                        var preference = prefer switch
                        {
                            0 => count >= 0 ? '0' : '1',
                            1 => count >= 0 ? '1' : '0',
                            _ => throw new InvalidEnumArgumentException(nameof(prefer))
                        };

                        inpt = inpt.Where(it => it[i] == preference).ToArray();

                        if (inpt.Length == 1)
                            return inpt.First();
                    }
                }
            }

            var oxygenStr = NarrowAndPrefer((string[])lines.Clone(), 1);
            var co2Str = NarrowAndPrefer((string[])lines.Clone(), 0);

            var oxygen = Convert.ToInt32(oxygenStr, 2);
            var co2 = Convert.ToInt32(co2Str, 2);
            
            return (oxygen, co2);
        }
    }
    
    [TestClass]
    public class Day3Tests
    {
        private string _smallInput = @"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";
        
        [TestMethod]
        public void TestPart1()
        {
            var expected = (22, 9);
            var actual = new Day3().Part1(_smallInput);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestPart2()
        {
            var expected = (23, 10);
            var actual = new Day3().Part2(_smallInput);
            Assert.AreEqual(expected, actual);
        }
    }
}