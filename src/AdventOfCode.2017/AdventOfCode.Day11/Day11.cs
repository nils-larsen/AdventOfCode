using System;
using System.Collections.Generic;

namespace AdventOfCode.Day11
{
    public class HexEd
    {
        public IEnumerable<int> CalculateSteps(string input)
        {
            var directions = input.Split(',');

            var x = 0;
            var y = 0;

            var coordinates = new List<int>();

            foreach (var dir in directions)
            {
                switch (dir)
                {
                    case "n":
                        y -= 1;
                        break;
                    case "ne":
                        x += 1;
                        y -= 1;
                        break;
                    case "se":
                        x += 1;
                        break;
                    case "s":
                        y += 1;
                        break;
                    case "sw":
                        x -= 1;
                        y += 1;
                        break;
                    case "nw":
                        x -= 1;
                        break;
                }
                coordinates.Add((Math.Abs(x) + Math.Abs(y) + Math.Abs(x + y)) / 2);
            }
            return coordinates;
        }
    }
}
