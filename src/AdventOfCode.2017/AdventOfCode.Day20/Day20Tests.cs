using System.IO;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Day20
{
    public class SwarmTests
    {
        [Fact]
        public void Part1_GetResult()
        {
            File
                .ReadLines("Day20Input.txt")
                .ToList()
                .CreateListOfParticles()
                .Tick(400)
                .GetClosestParticleToOrigo()
                .Should()
                .Be(376);
        }

        [Fact]
        public void Part2_GetResult()
        {
            File
                .ReadLines("Day20Input.txt")
                .ToList()
                .CreateListOfParticles()
                .Tick(400, true)
                .Count
                .Should()
                .Be(574);
        }

        [Fact]
        public void Part2_Test()
        {
            File
                .ReadLines("TestDay20Input.txt")
                .ToList()
                .CreateListOfParticles()
                .Tick(3, true)
                .Count
                .Should()
                .Be(1);
        }
    }
}
