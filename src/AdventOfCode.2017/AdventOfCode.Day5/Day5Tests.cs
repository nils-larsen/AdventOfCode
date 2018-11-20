using System.IO;
using Xunit;

namespace AdventOfCode.Day5
{
    public class TestDay5
    {
        readonly Day5 _day5;

        public TestDay5()
        {
            _day5 = new Day5();
        }

        [Fact]
        public void Part1_GetResult()
        {
            var input = File.ReadAllText("Day5.txt")
                            .Replace("\n", "");
            var actual = _day5.SolveJumps(input);

            Assert.Equal(394829, actual);
        }

        [Fact]
        public void Part2_GetResult()
        {
            var input = File.ReadAllText("Day5.txt")
                            .Replace("\n", "");
            var actual = _day5.SolveStrangerJumps(input);

            Assert.Equal(31150702, actual);
        }

        [Theory]
        [InlineData("0 3 0 1 -3", 5)]
        public void Test_Part1(string input, int expected)
        {
            var actual = _day5.SolveJumps(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("0 3 0 1 -3", 10)]
        public void Test_part2(string input, int expected)
        {
            var actual = _day5.SolveStrangerJumps(input);

            Assert.Equal(expected, actual);
        }
    }
}
