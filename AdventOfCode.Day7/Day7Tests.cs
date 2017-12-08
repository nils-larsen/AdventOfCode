using System.IO;
using Xunit;

namespace AdventOfCode.Day7
{
    public class TestDay7
    {
        readonly Day7 _day7;

        public TestDay7()
        {
            _day7 = new Day7();
        }

        //[Fact]
        //public void Part1_GetResult()
        //{
        //    var input = File.ReadLines("Day7.txt");

        //    var actual = _day7.FindBottomProgram(input);

        //    Assert.Equal("qibuqqg", actual);
        //}

        //[Fact]
        //public void Part1_TestSampleData()
        //{
        //    var input = File.ReadLines("Day7Test.txt");

        //    var actual = _day7.FindBottomProgram(input);

        //    Assert.Equal("tknk", actual);
        //}

        [Fact]
        public void Part1_TestWithTree()
        {
            var tree = new Tree();
            tree.ParseText("Day7Test.txt");
        }

    }
}
