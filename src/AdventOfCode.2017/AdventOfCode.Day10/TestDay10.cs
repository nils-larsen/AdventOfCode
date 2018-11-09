using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode.Day10
{
    public class Day10Test
    {
        [Fact]
        public void Part1_GetResult()
        {
            var actual = File
                .ReadAllText("Day10.txt")
                .FormatInputToLengths()
                .Hash(256)
                .Take(2)
                .Aggregate((x, y) => x * y);

            Assert.Equal(7888, actual);
        }

        [Fact]
        public void Part2_GetResult()
        {
            var actual = File
                .ReadAllText("Day10.txt")
                .FormatInputToASCII()
                .Hash(256, 64)
                .MakeItDenser();

            Assert.Equal("decdf7d377879877173b7f2fb131cf1b", actual);
        }

        [Theory]
        [InlineData("3,4,1,5", 12)]
        public void Part1_TestData(string input, int expected)
        {
            var actual = input
                .FormatInputToLengths()
                .Hash(5)
                .Take(2)
                .Aggregate((x, y) => x * y);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("", "a2582a3a0e66e6e86e3812dcb672a272")]
        [InlineData("AoC 2017", "33efeb34ea91902bb2f59c9920caa6cd")]
        [InlineData("1,2,3", "3efbe78a8d82f29979031a4aa0b16a9d")]
        [InlineData("1,2,4", "63960835bcdc130f0b66d7ff4f6a5a8e")]
        public void Part2_TestData(string input, string expected)
        {
            var actual = input
                .FormatInputToASCII()
                .Hash(256, 64)
                .MakeItDenser();

            Assert.Equal(expected, actual);
        }
    }
}
