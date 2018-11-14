using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace AdventOfCode.Day6
{
    public class Day6Tests
    {
        [Fact]
        public async Task GetResult_Part1()
        {
            var lightGrid = new LightGrid(1000, 1000);
            var lightSwitch = new LightSwitch();

            var instructions = await File.ReadAllLinesAsync("Day6Input.txt");

            foreach (var instruction in instructions)
                lightSwitch.ReadInstruction(instruction, lightGrid);

            lightGrid
                .Lights
                .Count(x => x.On == true)
                .Should()
                .Be(569999);
        }

        [Fact]
        public async Task GetResult_Part2()
        {
            var lightGrid = new LightGrid(1000, 1000);
            var lightSwitch = new LightSwitch();

            var instructions = await File.ReadAllLinesAsync("Day6Input.txt");

            foreach (var instruction in instructions)
                lightSwitch.ReadInstruction(instruction, lightGrid);

            lightGrid
                .Lights
                .Sum(light => light.Brightness)
                .Should()
                .Be(17836115);
        }

        [Theory]
        [InlineData("turn on 0,0 through 999,999", 1000000)]
        [InlineData("toggle 0,0 through 999,0", 1000)]
        [InlineData("turn off 499,499 through 500,500", 0)]
        public void Test1(string input, int expected)
        {
            var lightGrid = new LightGrid(1000, 1000);
            var lightSwitch = new LightSwitch();

            lightSwitch.ReadInstruction(input, lightGrid);

            lightGrid
                .Lights
                .Count(x => x.On == true)
                .Should()
                .Be(expected);
        }

        [Fact]
        public void Test1_2()
        {
            var instructions = new List<string>
            {
                "turn on 0,0 through 999,999",
                "turn off 499,499 through 500,500"
            };

            var lightGrid = new LightGrid(1000, 1000);
            var lightSwitch = new LightSwitch();

            foreach (var instruction in instructions)
                lightSwitch.ReadInstruction(instruction, lightGrid);

            lightGrid
                .Lights
                .Count(x => x.On == true)
                .Should()
                .Be(999996);
        }

        [Theory]
        [InlineData("turn on 0,0 through 0,0", 1)]
        [InlineData("toggle 0,0 through 999,999", 2000000)]
        public void Test2(string input, int expected)
        {
            var lightGrid = new LightGrid(1000, 1000);
            var lightSwitch = new LightSwitch();

            lightSwitch.ReadInstruction(input, lightGrid);

            lightGrid
                .Lights
                .Sum(light => light.Brightness)
                .Should()
                .Be(expected);
        }
    }
}
