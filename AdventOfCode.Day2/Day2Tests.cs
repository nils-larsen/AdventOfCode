using Xunit;

namespace AdventOfCode.Day2.Tests
{
    public class TestDay2
    {
        private CalculatePart1 _part1Calculator;
        private CalculatePart2 _part2Calculator;

        public TestDay2()
        {
            _part1Calculator = new CalculatePart1();
            _part2Calculator = new CalculatePart2();
        }

        [Fact]
        public void GetResult_Part1()
        {
            foreach (string line in FileReader.ReadLinesFromFile("Day2.txt"))
            {
                _part1Calculator.AddChecksumOnEachLine(line);
            }
            var actualCheckSum = _part1Calculator.CalculateSum();
            Assert.Equal(39126, actualCheckSum);
        }

        [Fact]
        public void GetResult_Part2()
        {
            foreach (string line in FileReader.ReadLinesFromFile("Day2.txt"))
            {
                _part2Calculator.AddSumFromEvenDivisors(line);
            }
            var actualSum = _part2Calculator.CalculateSum();
            Assert.Equal(258, actualSum);
        }

        [Theory]
        [InlineData("5 1 9 5", 8)]
        [InlineData("7 5 3", 4)]
        [InlineData("2 4 6 8", 6)]
        public void TestSampleDataPart1(string input, int expectedResult)
        {
            _part1Calculator.AddChecksumOnEachLine(input);
            var actualSum = _part1Calculator.CalculateSum();
            Assert.Equal(expectedResult, actualSum);
        }

        [Theory]
        [InlineData("5 9 2 8", 4)]
        [InlineData("9 4 7 3", 3)]
        [InlineData("3 8 6 5", 2)]
        public void TestSampleDataPart2(string input, int expectedResult)
        {
            _part2Calculator.AddSumFromEvenDivisors(input);
            var actualSum = _part2Calculator.CalculateSum();
            Assert.Equal(expectedResult, actualSum);
        }

        [Fact]
        public void TestWholePart1()
        {
            _part1Calculator.AddChecksumOnEachLine("5 1 9 5");
            _part1Calculator.AddChecksumOnEachLine("7 5 3");
            _part1Calculator.AddChecksumOnEachLine("2 4 6 8");
            var actualCheckSum = _part1Calculator.CalculateSum();
            Assert.Equal(18, actualCheckSum);
        }
    }
}