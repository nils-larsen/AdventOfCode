using System.Text.RegularExpressions;

namespace AdventOfCode.Day6
{
    public class LightSwitch
    {
        public delegate void Command(Light light);

        public void ReadInstruction(string instruction, LightGrid grid)
        {
            var match = Regex.Match(instruction, @"[a-z]+ (\d+),(\d+) through (\d+),(\d+)$", RegexOptions.IgnoreCase);

            var xFrom = int.Parse(match.Groups[1].ToString());
            var yFrom = int.Parse(match.Groups[2].ToString());
            var xTo = int.Parse(match.Groups[3].ToString());
            var yTo = int.Parse(match.Groups[4].ToString());

            if (instruction.Contains("turn on"))
            {
                Cmd(TurnOn, grid, xFrom, yFrom, xTo, yTo);
            }
            else if (instruction.Contains("toggle"))
            {
                Cmd(Toggle, grid, xFrom, yFrom, xTo, yTo);
            }
            else
            {
                Cmd(TurnOff, grid, xFrom, yFrom, xTo, yTo);
            }
        }

        public void Cmd(Command cmd, LightGrid grid, int xFrom, int yFrom, int xTo, int yTo)
        {
            for (var x = xFrom; x <= xTo; x++)
            {
                for (var y = yFrom; y <= yTo; y++)
                {
                    var light = grid.Lights[x * 1000 + y];
                    cmd(light);
                }
            }
        }

        public void TurnOn(Light light)
        {
            light.On = true;
            light.Brightness++;
        }

        public void Toggle(Light light)
        {
            light.On = !light.On;
            light.Brightness += 2;
        }

        public void TurnOff(Light light)
        {
            light.On = false;
            light.Brightness--;

            if (light.Brightness < 0)
            {
                light.Brightness = 0;
            }
        }
    }
}
