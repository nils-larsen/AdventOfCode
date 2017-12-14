using System.IO;
using Xunit;

namespace AdventOfCode.Day1
{
    public class TestDay1
    {
        [Fact]
        public void Part1_GetResult()
        {
            var actual = File
                .ReadAllText("Day1.txt")
                .FormatInput()
                .ReviewSequenceBasedOnNextDigit();

            Assert.Equal(1182, actual);
        }

        [Fact]
        public void Part2_GetResult()
        {
            var actual = File
                .ReadAllText("Day1.txt")
                .FormatInput()
                .ReviewSequenceBasedOnHalfWayAround();

            Assert.Equal(1152, actual);
        }

        [Theory]
        [InlineData("1122", 3)]
        [InlineData("1111", 4)]
        [InlineData("1234", 0)]
        [InlineData("91212129", 9)]
        public void TestPart1(string input, int expected)
        {
            var actual = input
                .FormatInput()
                .ReviewSequenceBasedOnNextDigit();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1212", 6)]
        [InlineData("1221", 0)]
        [InlineData("123425", 4)]
        [InlineData("123123", 12)]
        [InlineData("12131415", 4)]
        public void TestPart2(string input, int expected)
        {
            var actual = input
                .FormatInput()
                .ReviewSequenceBasedOnHalfWayAround();

            Assert.Equal(expected, actual);
        }
    }
}