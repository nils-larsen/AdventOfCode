using Xunit;
using FluentAssertions;

namespace AdventOfCode.Day17
{
    public class UnitTest1
    {
        [Fact]
        public void Part1_GetResult()
        {
            Spinlock
                .StartInsertion(349)
                .Should()
                .Be(640);
        }

        [Fact]
        public void Part2_GetResult()
        {
            Spinlock
                .Part2(349)
                .Should()
                .Be(47949463);
        }

        [Fact]
        public void Part1_Test()
        {
            Spinlock
                .StartInsertion(3)
                .Should()
                .Be(638);
        }
    }
}
