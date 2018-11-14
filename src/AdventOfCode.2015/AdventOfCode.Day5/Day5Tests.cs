using System.Linq;
using System.IO;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;

namespace AdventOfCode.Day5
{
    public class Day5Tests
    {
        [Fact]
        public void GetResult_Part1()
        {
            File.ReadLines("Day5Input.txt")
                .Count(x => x.HasThreeVowels()
                         && x.HasDoubleLetters()
                         && x.HasNoForbiddenStrings())
                .Should()
                .Be(236);
        }

        [Fact]
        public void GetResult_Part2()
        {
            File.ReadLines("Day5Input.txt")
                .Count(x => x.HasDoublePairs()
                         && x.HasRepeatingLetter())
                .Should()
                .Be(51);
        }

        [Theory]
        [InlineData("ugknbfddgicrmopn", 1)]
        [InlineData("aaa", 1)]
        [InlineData("jchzalrnumimnmhp", 0)]
        [InlineData("haegwjzuvuyypxyu", 0)]
        [InlineData("dvszwmarrgswjxmb", 0)]
        public void Test1(string input, int expected)
        {
            var inputArray = new List<string> { input };

            inputArray
                .Count(x => x.HasThreeVowels()
                         && x.HasDoubleLetters()
                         && x.HasNoForbiddenStrings())
                .Should()
                .Be(expected);
        }

        [Theory]
        [InlineData("qjhvhtzxzqqjkmpb", 1)]
        [InlineData("xxyxx", 1)]
        [InlineData("uurcxstgmygtbstg", 0)]
        [InlineData("ieodomkazucvgmuy", 0)]
        public void Test2(string input, int expected)
        {
            var inputArray = new List<string> { input };

            inputArray
                .Count(x => x.HasDoublePairs()
                         && x.HasRepeatingLetter())
                .Should()
                .Be(expected);
        }
    }
}
