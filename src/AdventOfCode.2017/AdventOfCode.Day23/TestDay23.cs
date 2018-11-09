using Xunit;
using AdventOfCode.Day18;
using System.Linq;
using FluentAssertions;
using System.IO;

namespace AdventOfCode.Day23
{
    public class TestCoprocessor
    {
        [Fact]
        public void Part1_GetResult()
        {
            var input = File.ReadLines("Day23Input.txt").ToList();
            var actual = Registers
                .CreateRegisters('a', 'h')
                .ReadNewInstructions(input)
                .Should()
                .Be(5929);


        }
    }

}
