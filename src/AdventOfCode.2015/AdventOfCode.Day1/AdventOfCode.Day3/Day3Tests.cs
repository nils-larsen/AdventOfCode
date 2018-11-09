using System.Linq;
using System.IO;
using Xunit;
using FluentAssertions;

namespace AdventOfCode.Day3
{
    public class Day3Tests
    {
        [Fact]
        public void GetResult_Part1()
        {
            var santa = new Santa();
            var file = File.ReadAllText("Day3Input.txt");
            santa.ReadInstructions(file.ToCharArray());
           
            santa
                .Visited
                .Count()
                .Should()
                .Be(2572);
        }

        [Theory]
        [InlineData(">", 2)]
        [InlineData("^>v<", 4)]
        [InlineData("^v^v^v^v^v", 2)]
        public void Test1(string input, int expected)
        {
            var santa = new Santa();
            santa.ReadInstructions(input.ToCharArray());

            santa
                .Visited
                .Count()
                .Should()
                .Be(expected);
        }
    }
}
