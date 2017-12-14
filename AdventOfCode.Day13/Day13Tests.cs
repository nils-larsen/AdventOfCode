using System.IO;
using Xunit;

namespace AdventOfCode.Day13
{
    public class TestDay13
    {
        [Fact]
        public void Part1_GetResult()
        {
            var input = File.ReadLines("Day13Input.txt");

            var packerScanner = new PackerScanner(input);

            var actual = packerScanner.HitchHike();

            Assert.Equal(3184, actual);
        }

        [Fact]
        public void Part2_GetResult()
        {
            var input = File.ReadLines("Day13Input.txt");

            var packerScanner = new PackerScanner(input);

            var actual = packerScanner.FindDelay();

            Assert.Equal(3878062, actual);
        }

        [Fact]
        public void Part1_TestData()
        {
            var input = File.ReadLines("Day13TestInput.txt");

            var packerScanner = new PackerScanner(input);

            var actual = packerScanner.HitchHike();

            Assert.Equal(24, actual);
        }

        [Fact]
        public void Part2_TestData()
        {
            var input = File.ReadLines("Day13TestInput.txt");

            var packerScanner = new PackerScanner(input);

            var actual = packerScanner.FindDelay();

            Assert.Equal(10, actual);
        }
    }
}
