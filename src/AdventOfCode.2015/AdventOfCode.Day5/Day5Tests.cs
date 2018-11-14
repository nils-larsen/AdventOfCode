using System.Linq;
using System.IO;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Day5
{
    public class Day5Tests
    {
        [Fact]
        public void GetResult_Part1()
        {
            File.ReadLines("Day5Input.txt")
                .ToList()
                .Select(x => x.HasThreeVowels()
                              .HasDoubleLetters()
                              .HasNoForbiddenStrings())
                .Count(x => x.Equals(1))
                .Should()
                .Be(236);
        }

        [Theory]
        [InlineData("ugknbfddgicrmopn", 1)]
        [InlineData("aaa", 1)]
        [InlineData("jchzalrnumimnmhp", 0)]
        [InlineData("haegwjzuvuyypxyu", 0)]
        [InlineData("dvszwmarrgswjxmb", 0)]
        public void Test1(string input, int expected)
        {
            input
                .HasThreeVowels()
                .HasDoubleLetters()
                .HasNoForbiddenStrings()
                .Should()
                .Be(expected);
        }
    }
}
