using System.IO;
using Xunit;
using FluentAssertions;

namespace AdventOfCode.Day1
{
    public class TestDay1
    {
        [Fact]
        public void Part1_GetResult()
        {
            File
                .ReadAllText("Day1Input.txt")
                .ToCharArray()
                .CalculateFloor()
                .Should()
                .Be(138);
        }


        [Fact]
        public void Part2_GetResult()
        {
            File
                .ReadAllText("Day1Input.txt")
                .ToCharArray()
                .CalculateWhenBasementIsReached()
                .Should()
                .Be(1771);
        }

        [Theory]
        [InlineData(")", 1)]
        [InlineData("()())", 5)]
        public void TestPart2(string input, int expected)
        {
            input
                .ToCharArray()
                .CalculateWhenBasementIsReached()
                .Should()
                .Be(expected);
        }

        [Theory]
        [InlineData("(())", 0)]
        [InlineData("()()", 0)]
        [InlineData("(((", 3)]
        [InlineData("(()(()(", 3)]
        [InlineData("))(((((", 3)]
        [InlineData("())", -1)]
        [InlineData("))(", -1)]
        [InlineData(")))", -3)]
        [InlineData(")())())", -3)]
        public void TestPart1(string input, int expected)
        {
            var actual = input
                .ToCharArray()
                .CalculateFloor()
                .Should()
                .Be(expected);
        }
    }


}
