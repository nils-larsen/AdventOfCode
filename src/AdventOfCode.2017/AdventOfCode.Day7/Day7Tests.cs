using System.IO;
using Xunit;

namespace AdventOfCode.Day7
{
    public class TestDay7
    {
        [Fact]
        public void Part1_GetResult()
        {
            var input = File.ReadLines("Day7.txt");

            var actual = new Tree(input).GetRoot().Name;

            Assert.Equal("qibuqqg", actual);
        }

        [Fact]
        public void Part1_TestNew()
        {
            var input = File.ReadLines("Day7Test.txt");

            var actual = new Tree(input).GetRoot().Name;

            Assert.Equal("tknk", actual);
        }
    }
}
