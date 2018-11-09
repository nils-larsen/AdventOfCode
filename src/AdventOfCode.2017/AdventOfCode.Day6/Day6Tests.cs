using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace AdventOfCode.Day6
{
    public class TestDay6
    {
        readonly Day6 _day6;

        public TestDay6()
        {
            _day6 = new Day6();
        }

        [Fact]
        public void Part1_GetResult()
        {
            var input = string
                .Join(" ", Regex
                    .Split(File.ReadAllText("Day6.txt"), @"\s+")
                    .Where(s => s != string.Empty));

            var actual = _day6.NumberOfValidRedistributions(input);

            Assert.Equal(5042, actual);
        }

        [Fact]
        public void Part2_GetResult()
        {
            var input = string
                .Join(" ", Regex
                      .Split(File.ReadAllText("Day6.txt"), @"\s+")
                      .Where(s => s != string.Empty));

            var actual = _day6.NumberOfRedistributionsBetweenFirstDuplicate(input);

            Assert.Equal(1086, actual);
        }

        [Theory]
        [InlineData("0 2 7 0", "2 4 1 2")]
        [InlineData("2 4 1 2", "3 1 2 3")]
        [InlineData("3 1 2 3", "0 2 3 4")]
        [InlineData("0 2 3 4", "1 3 4 1")]
        [InlineData("1 3 4 1", "2 4 1 2")]
        public void Part1_TestOneAtATime(string input, string expected)
        {
            var actual = _day6.GetOneRedistribution(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("0 2 7 0", 5)]
        public void Part1_TestWhole(string input, int expected)
        {
            var actual = _day6.NumberOfValidRedistributions(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("0 2 7 0", 4)]
        public void Part2_NumberOfRedistributionsBetweenFirstDuplicate(string input, int expected)
        {
            var actual = _day6.NumberOfRedistributionsBetweenFirstDuplicate(input);

            Assert.Equal(expected, actual);
        }
    }
}
