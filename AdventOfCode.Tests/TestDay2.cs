using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day2.Tests
{
    public class TestDay2
    {
        private CalculatePart1 _day2Part1Result;
        private CalculatePart2 _day2Part2Result;

        private CalculatePart1 _mockPart1Calculator;
        private CalculatePart2 _mockPart2Calculator;

        public TestDay2()
        {
            _day2Part1Result = new CalculatePart1();
            _day2Part2Result = new CalculatePart2();

            _mockPart1Calculator = new CalculatePart1();
            _mockPart2Calculator = new CalculatePart2();

            foreach (string line in FileReader.ReadLinesFromFile("Day2.txt"))
            {
                _day2Part1Result.AddChecksumOnEachLine(line);
                _day2Part2Result.AddSumFromEvenDivisors(line);
            }
        }

        [Fact]
        public void GetResult_Part1()
        {
            var actualCheckSum = _day2Part1Result.CalculateSum();
            Assert.Equal(39126, actualCheckSum);
        }

        [Fact]
        public void GetResult_Part2()
        {
            var actualSum = _day2Part2Result.CalculateSum();
            Assert.Equal(258, actualSum);
        }

        [Theory]
        [MemberData(nameof(DataGenerator.GetNumbersPart1), MemberType = typeof(DataGenerator))]
        public void TestSampleDataPart1(string input, int expectedResult)
        {
            _mockPart1Calculator.AddChecksumOnEachLine(input);
            var actualSum = _mockPart1Calculator.CalculateSum();
            Assert.Equal(expectedResult, actualSum);
        }

        [Theory]
        [MemberData(nameof(DataGenerator.GetNumbersPart2), MemberType = typeof(DataGenerator))]
        public void TestSampleDataPart2(string input, int expectedResult)
        {
            _mockPart2Calculator.AddSumFromEvenDivisors(input);
            var actualSum = _mockPart2Calculator.CalculateSum();
            Assert.Equal(expectedResult, actualSum);
        }

        [Fact]
        public void TestWholePart1()
        {
            _mockPart1Calculator.AddChecksumOnEachLine("5 1 9 5");
            _mockPart1Calculator.AddChecksumOnEachLine("7 5 3");
            _mockPart1Calculator.AddChecksumOnEachLine("2 4 6 8");
            var actualCheckSum = _mockPart1Calculator.CalculateSum();
            Assert.Equal(18, actualCheckSum);
        }
    }

    public class DataGenerator
    {
        public static IEnumerable<object[]> GetNumbersPart1()
        {
            yield return new object[] { "5 1 9 5", 8 };
            yield return new object[] { "7 5 3", 4 };
            yield return new object[] { "2 4 6 8", 6 };
        }

        public static IEnumerable<object[]> GetNumbersPart2()
        {
            yield return new object[] { "5 9 2 8", 4 };
            yield return new object[] { "9 4 7 3", 3 };
            yield return new object[] { "3 8 6 5", 2 };
        }
    }
}