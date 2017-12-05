using System;
using System.Collections.Generic;
using static System.Linq.Enumerable;

namespace AdventOfCode.Day3
{
    public class Day3
    {
        public int Solve(int input)
        {
            var swirl = (int)Math.Ceiling(Math.Sqrt(input));
            swirl = swirl % 2 != 0 ? swirl : swirl + 1;

            var corners = new List<int>();
            foreach (int corner in Range(0, 4))
            {
                corners.Add((int)Math.Pow(swirl, 2) - corner * (swirl - 1));
            }

            foreach (var corner in corners)
            {
                var distance = corner - input;
                if (distance <= (swirl - 1) / 2)
                {
                    return swirl - 1 - distance;
                }
            }
            return 0;
        }
    }
}
