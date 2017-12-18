using System.IO;
using Xunit;
using FluentAssertions;

namespace AdventOfCode.Day16
{
    public class TestPermutation
    {
        [Fact]
        public void Part1_GetResult()
        {
            Permutation
                .SetupPrograms('a', 'p')
                .Dance(File.ReadAllText("Day16Input.txt"))
                .Should()
                .Be("bijankplfgmeodhc");
        }

        [Fact]
        public void Part2_GetResult()
        {
            Permutation
                .SetupPrograms('a', 'p')
                .Dance(File.ReadAllText("Day16Input.txt"), 1000000000)
                .Should()
                .Be("bpjahknliomefdgc");
        }

        [Theory]
        [InlineData("s1,x3/4,pe/b", "baedc")]
        public void Part1_Test(string input, string expected)
        {
            Permutation
                .SetupPrograms('a', 'e')
                .Dance(input)
                .Should()
                .Be(expected);
        }

        [Theory]
        [InlineData("s1,x3/4,pe/b", "ceadb")]
        public void Part2_Test(string input, string expected)
        {
            Permutation
                .SetupPrograms('a', 'e')
                .Dance(input, 2)
                .Should()
                .Be(expected);
        }
    }
}
