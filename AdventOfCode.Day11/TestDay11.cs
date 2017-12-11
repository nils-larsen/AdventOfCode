using System.Linq;
using System.IO;
using Xunit;

namespace AdventOfCode.Day11
{
    public class Day11Test
    {
        readonly HexEd _hexEd;

        public Day11Test()
        {
            _hexEd = new HexEd();
        }

        [Fact]
        public void Part1_GetResult()
        {
            var input = File.ReadAllText("Day11.txt");

            var actual = _hexEd
                .CalculateSteps(input)
                .Last();

            Assert.Equal(682, actual);
        }

        [Fact]
        public void Part2_GetResult()
        {
            var input = File.ReadAllText("Day11.txt");

            var actual = _hexEd
                .CalculateSteps(input)
                .Max();

            Assert.Equal(1406, actual);
        }

        [Theory]
        [InlineData("ne,ne,ne", 3)]
        [InlineData("ne,ne,sw,sw", 0)]
        [InlineData("ne,ne,s,s", 2)]
        [InlineData("se,sw,se,sw,sw", 3)]
        public void Part1_CalculateSteps(string input, int expected)
        {
            var actual = _hexEd
                .CalculateSteps(input)
                .Last();

            Assert.Equal(expected, actual);
        }
    }
}

