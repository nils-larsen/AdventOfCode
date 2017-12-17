using Xunit;
using FluentAssertions;
using System.Linq;

namespace AdventOfCode.Day15
{
    public class TestDuelingGenerator
    {
        [Fact]
        public void Part1_GetResult()
        {
            Dueling
                .Generator(516, 16807)
                .CompareLowerBits(Dueling.Generator(190, 48271), 40000000)
                .Sum()
                .Should()
                .Be(597);
        }

        [Fact]
        public void Part2_GetResult()
        {
            Dueling
                .Generator(516, 16807, 4)
                .CompareLowerBits(Dueling.Generator(190, 48271, 8), 5000000)
                .Sum()
                .Should()
                .Be(303);
        }

        [Fact]
        public void Part1_Test()
        {
            Dueling
                .Generator(65, 16807)
                .CompareLowerBits(Dueling.Generator(8921, 48271), 5)
                .Sum()
                .Should()
                .Be(1);
        }

        [Fact]
        public void Part2_Test()
        {
            Dueling
                .Generator(65, 16807, 4)
                .CompareLowerBits(Dueling.Generator(8921, 48271, 8), 5)
                .Sum()
                .Should()
                .Be(0);
        }
    }
}
