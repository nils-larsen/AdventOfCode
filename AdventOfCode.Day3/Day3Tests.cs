using System;
using Xunit;

namespace AdventOfCode.Day3.Tests
{
    public class TestDay3
    {
        readonly Day3 _day3;

        public TestDay3()
        {
            _day3 = new Day3();
        }

        [Fact]
        public void GetResultPart1()
        {
            var actualResult = _day3.Solve(277678);
            Assert.Equal(475, actualResult);

        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(12, 3)]
        [InlineData(23, 2)]
        [InlineData(1024, 31)]
        public void TestPart1(int input, int expectedResult)
        {
            var actualResult = _day3.Solve(input);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
