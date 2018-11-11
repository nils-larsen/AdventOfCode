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
            File.ReadAllText("Day3Input.txt")
                .ToCharArray()
                .DeliverBy(nrOfSantas: 1)
                .Distinct()
                .ToList()
                .Count()
                .Should()
                .Be(2572);
        }

        [Fact]
        public void GetResult_Part2()
        {
            File.ReadAllText("Day3Input.txt")
                .ToCharArray()
                .DeliverBy(nrOfSantas: 2)
                .Distinct()
                .ToList()
                .Count()
                .Should()
                .Be(2631);
        }

        [Theory]
        [InlineData(">", 2)]
        [InlineData("^>v<", 4)]
        [InlineData("^v^v^v^v^v", 2)]
        public void Test1(string input, int expected)
        {
            input
                .ToCharArray()
                .DeliverBy(nrOfSantas: 1)
                .Distinct()
                .ToList()
                .Count()
                .Should()
                .Be(expected);
        }

        [Theory]
        [InlineData("^v", 3)]
        [InlineData("^>v<", 3)]
        [InlineData("^v^v^v^v^v", 11)]
        public void Test2(string input, int expected)
        {
            input
                .ToCharArray()
                .DeliverBy(nrOfSantas: 2)
                .Distinct()
                .ToList()
                .Count()
                .Should()
                .Be(expected);
        }
    }
}
