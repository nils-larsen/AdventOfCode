using System.IO;
using Xunit;

namespace AdventOfCode.Day9
{
    public class TestDay9
    {
        [Fact]
        public void Part1_GetResult()
        {
            var input = File.ReadAllText("Day9.txt");

            var actual = Day9.ProcessStreamOfCharacters(input).Item1;

            Assert.Equal(23588, actual);
        }

        [Fact]
        public void Part2_GetResult()
        {
            var input = File.ReadAllText("Day9.txt");

            var actual = Day9.ProcessStreamOfCharacters(input).Item2;

            Assert.Equal(10045, actual);
        }

        [Theory]
        [InlineData("{}", 1)]
        [InlineData("{{{}}}", 6)]
        [InlineData("{{},{}}", 5)]
        [InlineData("{{{},{},{{}}}}", 16)]
        [InlineData("{<a>,<a>,<a>,<a>}", 1)]
        [InlineData("{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
        [InlineData("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
        [InlineData("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
        public void Test1(string input, int expected)
        {
            var actual = Day9.ProcessStreamOfCharacters(input).Item1;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("<>", 0)]
        [InlineData("<random characters>", 17)]
        [InlineData("<<<<>", 3)]
        [InlineData("<{!>}>", 2)]
        [InlineData("<!!>", 0)]
        [InlineData("<!!!>>", 0)]
        public void Part2_SampleData(string input, int expected)
        {
            var actual = Day9.ProcessStreamOfCharacters(input).Item2;

            Assert.Equal(expected, actual);
        }
    }
}
