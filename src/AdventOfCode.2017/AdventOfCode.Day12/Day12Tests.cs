using System.IO;
using Xunit;
using System;

namespace AdventOfCode.Day12
{
    public class TestDay12
    {
        [Fact]
        public void Part1_GetResult()
        {
            var input = File.ReadLines("Day12Input.txt");

            var actual = new DigitalPlumber(input).NumberOfProgramsThatContainsProgramId0();

            Assert.Equal(130, actual);
        }

        [Fact]
        public void Part2_GetResult()
        {
            var input = File.ReadLines("Day12Input.txt");

            var actual = new DigitalPlumber(input).GroupsInTotal();

            Assert.Equal(189, actual);
        }

        [Fact]
        public void Part1_TestData()
        {
            var input = File.ReadLines("Day12SampleInput.txt");

            var actual = new DigitalPlumber(input).NumberOfProgramsThatContainsProgramId0();

            Assert.Equal(6, actual);
        }

        [Fact]
        public void Part2_TestData()
        {
            var input = File.ReadLines("Day12SampleInput.txt");

            var actual = new DigitalPlumber(input).GroupsInTotal();

            Assert.Equal(2, actual);
        }
    }
}
