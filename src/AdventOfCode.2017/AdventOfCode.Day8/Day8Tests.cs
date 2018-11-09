using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode.Day8
{
    public class TestDay8
    {
        readonly Day8 _day8;

        public TestDay8()
        {
            _day8 = new Day8();
        }

        [Fact]
        public void Part1_GetResult()
        {
            var input = File.ReadLines("Day8.txt").ToList();
            input.ToList().ForEach(_day8.HandleInput);

            var actual = _day8.CheckRegister()
                              .Select(x => x.Value)
                              .Max();

            Assert.Equal(5966, actual);
        }

        [Fact]
        public void Part2_GetResult()
        {
            var input = File.ReadLines("Day8.txt").ToList();
            input.ToList().ForEach(_day8.HandleInput);

            var actual = _day8.HighestValue;

            Assert.Equal(6347, actual);
        }

        [Fact]
        public void Part1_TestData()
        {
            var input = File.ReadLines("Day8Test.txt").ToList();
            input.ForEach(_day8.HandleInput);

            var actual = _day8.CheckRegister()
                              .Select(x => x.Value)
                              .Max();

            Assert.Equal(1, actual);
        }

        [Fact]
        public void Part2_TestData()
        {
            var input = File.ReadLines("Day8Test.txt").ToList();
            input.ForEach(_day8.HandleInput);

            var actual = _day8.HighestValue;
            Assert.Equal(10, actual);
        }
    }
}
