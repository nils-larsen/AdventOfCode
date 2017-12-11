using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode.Day10
{
    public class Day10Test
    {
        readonly Day10 _day10;

        public Day10Test()
        {
            _day10 = new Day10();
        }

        [Fact]
        public void Part1_GetResult()
        {
            var list = Enumerable.Range(0, 256).ToList();
            var input = File.ReadAllText("Day10.txt");
            var actual = _day10.Solve(input, list);
            Assert.Equal(7888, actual);
        }

        [Theory]
        [InlineData("3,4,1,5", 12)]
        public void Test1(string input, int expected)
        {
            var list = Enumerable.Range(0, 5).ToList();
            var actual = _day10.Solve(input, list);

            Assert.Equal(expected, actual);
        }
    }
}
