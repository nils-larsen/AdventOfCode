using System.Linq;
using Xunit;

namespace AdventOfCode.Day1.Tests
{
    public class TestDay1
    {
        Day1 _day1;

        public TestDay1()
        {
            _day1 = new Day1();
        }

        [Fact]
        public void GetResultToPart1()
        {
            var input = FileReader.ReadFile("Day1.txt");

            var workOn = input.Select(x => int.Parse(x.ToString())).ToList();
            var result = _day1.ReviewSequenceBasedOnNextDigit(workOn);

            Assert.Equal(1182, result);
        }

        [Fact]
        public void GetResultToPart2()
        {
            var input = FileReader.ReadFile("Day1.txt");

            var workOn = input.Select(x => int.Parse(x.ToString())).ToList();
            var result = _day1.ReviewSequenceBasedOnHalfWayAround(workOn);

            Assert.Equal(1152, result);
        }

        [Theory]
        [InlineData("1122", 3)]
        [InlineData("1111", 4)]
        [InlineData("1234", 0)]
        [InlineData("91212129", 9)]
        public void TestPart1(string input, int expectedResult)
        {
            var workOn = input.Select(x => int.Parse(x.ToString())).ToList();
            var actualResult = _day1.ReviewSequenceBasedOnNextDigit(workOn);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("1212", 6)]
        [InlineData("1221", 0)]
        [InlineData("123425", 4)]
        //[InlineData("123123", 12)]
        //[InlineData("12131415", 4)]
        public void TestPart2(string input, int expectedResult)
        {
            var workOn = input.Select(x => int.Parse(x.ToString())).ToList();
            var actualResult = _day1.ReviewSequenceBasedOnHalfWayAround(workOn);

            Assert.Equal(expectedResult, actualResult);
        }

    }
}