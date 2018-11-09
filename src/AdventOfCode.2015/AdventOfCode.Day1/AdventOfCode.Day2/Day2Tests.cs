using System.IO;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace AdventOfCode.Day2
{
    public class Day2Tests
    {
        [Fact]
        public void GetResult_Part1()
        {
            File
                .ReadAllLines("Day2Input.txt")
                .ToList()
                .Select(x => x.CreateList().CalculateAmountOfPaper())
                .Aggregate((sum, val) => sum + val)
                .Should()
                .Be(1598415);
        }

        [Fact]
        public void GetResult_Part2()
        {
            File
                .ReadAllLines("Day2Input.txt")
                .ToList()
                .Select(x => x.CreateList().CalculateAmountOfRibbon())
                .Aggregate((sum, val) => sum + val)
                .Should()
                .Be(3812909);
        }

        [Theory]
        [InlineData("2x3x4", 58)]
        [InlineData("1x1x10", 43)]
        public void TestPart1(string input, int expected)
        {
            input.CreateList()
                 .CalculateAmountOfPaper()
                 .Should()
                 .Be(expected);
                             
        }

        [Theory]
        [InlineData("2x3x4", 34)]
        [InlineData("1x1x10", 14)]
        public void TestPart2(string input, int expected)
        {
            input.CreateList()
                 .CalculateAmountOfRibbon()
                 .Should()
                 .Be(expected);

        }
    }

    public static class PaperWrapper
    {
        public static List<int> CreateList(this string input)
        {
            return input.Split('x')
                         .Select(int.Parse)
                         .ToList();

        }

        public static int CalculateAmountOfPaper(this List<int> dimensions)
        {
            var l = dimensions[0];
            var w = dimensions[1];
            var h = dimensions[2];

            var list = new List<int>{2 * l * w, 2 * w * h, 2 * h * l};

            var amountOfPaper = list.Aggregate((sum, val) => sum + (val));
            var extra = list.Min() / 2;

            return amountOfPaper + extra;
        }

        public static int CalculateAmountOfRibbon(this List<int> dimensions)
        {
            var l = dimensions[0];
            var w = dimensions[1];
            var h = dimensions[2];

            var list = new List<int> { l, w, h };
            list.Sort();

            return list[0] + list[0] + list[1] + list[1] + l * w * h;

        }

    }



}
