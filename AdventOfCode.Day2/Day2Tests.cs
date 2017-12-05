using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode.Day2
{
    public class TestDay2
    {
        readonly Day2 _day2;

        public TestDay2()
        {
            _day2 = new Day2();
        }

        [Fact]
        public void Part1_GetResult()
        {
            var actual = File
                .ReadAllLines("Day2.txt")
                .Select(x => _day2.CalculateChecksum(x))
                .Sum();

            Assert.Equal(39126, actual);
        }

        [Fact]
        public void Part2_GetResult()
        {
            var actual = File
                .ReadAllLines("Day2.txt")
                .Select(x => _day2.CalculateEvenlyDivisibleChecksum(x))
                .Sum();

            Assert.Equal(258, actual);
        }

        [Theory]
        [InlineData("5 1 9 5", 8)]
        [InlineData("7 5 3", 4)]
        [InlineData("2 4 6 8", 6)]
        public void TestSampleDataPart1(string input, int expectedResult)
        {
            var actual = _day2.CalculateChecksum(input);

            Assert.Equal(expectedResult, actual);
        }

        [Theory]
        [InlineData("5 9 2 8", 4)]
        [InlineData("9 4 7 3", 3)]
        [InlineData("3 8 6 5", 2)]
        public void TestSampleDataPart2(string input, int expectedResult)
        {
            var actual = _day2.CalculateEvenlyDivisibleChecksum(input);

            Assert.Equal(expectedResult, actual);
        }

        [Fact]
        public void TestWholePart1()
        {
            string[] input = { "5 1 9 5", "7 5 3", "2 4 6 8" };

            var actual = input
                .Select(x => _day2.CalculateChecksum(x))
                .Sum();

            Assert.Equal(18, actual);
        }

        [Fact]
        public void TestWholePart2()
        {
            string[] input = { "5 9 2 8", "9 4 7 3", "3 8 6 5" };

            var actual = input
                .Select(x => _day2.CalculateEvenlyDivisibleChecksum(x))
                .Sum();

            Assert.Equal(9, actual);
        }
    }
}