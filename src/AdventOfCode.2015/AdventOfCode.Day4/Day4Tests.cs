using Xunit;
using FluentAssertions;

namespace AdventOfCode.Day4
{
    public class Day4Tests
    {
        [Fact]
        public void GetResult_Part1()
        {
            AdventCoin
                .Mine("ckczppom", nrOfZeroes: 5)
                .Should()
                .Be(117946);
        }

        [Fact]
        public void GetResult_Part2()
        {
            AdventCoin
                .Mine("ckczppom", nrOfZeroes: 6)
                .Should()
                .Be(3938038);
        }

        [Theory]
        [InlineData("abcdef", 609043)]
        [InlineData("pqrstuv", 1048970)]
        public void Test1(string input, long expected)
        {
            AdventCoin
                .Mine(input, nrOfZeroes: 5)
                .Should()
                .Be(expected);
        }
    }
}
