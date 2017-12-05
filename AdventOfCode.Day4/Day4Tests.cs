using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode.Day4
{
    public class TestDay4
    {
        readonly Day4 _day4;

        public TestDay4()
        {
            _day4 = new Day4();
        }

        [Fact]
        public void Part1_GetResult()
        {
            var actual = File.ReadAllLines("Day4.txt")
                .Select(x => _day4.ValidPassphrase(x))
                .Count(x => x == true);

            Assert.Equal(386, actual);
        }

        [Fact]
        public void Part2_GetResult()
        {

            var actual = File.ReadAllLines("Day4.txt")
                .Select(x => _day4.ValidPassphraseAnagram(x))
                .Count(x => x == true);

            Assert.Equal(208, actual);
        }

        [Theory]
        [InlineData("aa bb cc dd ee", true)]
        [InlineData("aa bb cc dd aa", false)]
        [InlineData("aa bb cc dd aaa", true)]
        public void Part1_TestValidPassphrases(string input, bool expected)
        {
            var actual = _day4.ValidPassphrase(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("abcde fghij", true)]
        [InlineData("abcde xyz ecdab", false)]
        [InlineData("a ab abc abd abf abj", true)]
        [InlineData("iiii oiii ooii oooi oooo", true)]
        [InlineData("oiii ioii iioi iiio", false)]
        public void Part2_TestValidPassphrases(string input, bool expected)
        {
            var actual = _day4.ValidPassphraseAnagram(input);

            Assert.Equal(expected, actual);
        }
    }
}
