using System;
using System.Collections.Generic;
using static System.Linq.Enumerable;

namespace AdventOfCode.Day3
{
    public class Day3
    {
        public int Solve(int input)
        {
            var layersOfSpiral = 1;

            while (Math.Pow(layersOfSpiral, 2) < input)
            {
                layersOfSpiral += 2;
            }

            var corners = new List<int>();

            foreach (int corner in Range(0, 4))
            {
                corners.Add((int)Math.Pow(layersOfSpiral, 2) - corner * (layersOfSpiral - 1));
            }

            foreach (var corner in corners)
            {
                var distance = Math.Abs((corner - input));
                if (distance <= (layersOfSpiral - 1) / 2)
                {
                    return layersOfSpiral - 1 - distance;
                }
            }
            return 0;
        }
    }
}
