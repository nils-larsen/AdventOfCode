using System.IO;
using Xunit;

namespace AdventOfCode.Day19
{
    public class TestTubes
    {
        [Fact]
        public void Part1_GetResult()
        {
            var input = File.ReadAllText("Day19Input.txt");

            var actual = Tubes.Solve(input);

            Assert.Equal("KGPTMEJVS", actual.Item1);
        }

        [Fact]
        public void Part2_GetResult()
        {
            var input = File.ReadAllText("Day19Input.txt");

            var actual = Tubes.Solve(input);

            Assert.Equal(16328, actual.Item2);
        }

        [Fact]
        public void Part1_TEST()
        {
            var input = File.ReadAllText("Day19TestInput.txt");

            var actual = Tubes.Solve(input);

            Assert.Equal("ABCDEF", actual.Item1);
        }

        [Fact]
        public void Part2_TEST()
        {
            var input = File.ReadAllText("Day19TestInput.txt");

            var actual = Tubes.Solve(input);

            Assert.Equal(38, actual.Item2);
        }
    }
}
