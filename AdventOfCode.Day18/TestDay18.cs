using System.IO;
using Xunit;
using FluentAssertions;
using System.Linq;

namespace AdventOfCode.Day18
{
    public class TestDuet
    {
        [Fact]
        public void Part1_GetResult()
        {
            var input = File.ReadAllLines("Day18Input.txt").ToList();

            var actual = Registers
                .CreateRegisters('a', 'z')
                .ReadInstructions(input)
                .Should()
                .Be(7071);
        }

        [Fact]
        public void Part1_TestData()
        {
            var input = File.ReadAllLines("Day18TestInput.txt").ToList();

            var actual = Registers
                .CreateRegisters('a', 'a')
                .ReadInstructions(input)
                .Should()
                .Be(4);
        }
    }
}
