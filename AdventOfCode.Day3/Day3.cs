using System;
using System.Collections.Generic;
using static System.Linq.Enumerable;

namespace AdventOfCode.Day3
{
    public class Day3
    {
        public int Solve(int input)
        {
            var lowerRightCornerSteps = 1;

            while (Math.Pow(lowerRightCornerSteps, 2) < input)
            {
                lowerRightCornerSteps += 2;
            }

            var corners = new List<int>();

            foreach (int corner in Range(0, 4))
            {
                corners.Add((int)Math.Pow(lowerRightCornerSteps, 2) - corner * (lowerRightCornerSteps - 1));
                //Console.WriteLine($"Corner {corner} - {corners.ElementAt(corner)}");
            }

            foreach (var corner in corners)
            {
                var distance = Math.Abs((corner - input));
                //Console.WriteLine($"INPUT: {input}. DISTANCE: {distance}. CORNER: {corner}");
                if (distance <= (lowerRightCornerSteps - 1) / 2)
                {
                    //  Console.WriteLine($"{distance} - {corner} - {lowerRightCornerSteps - 1 - distance}");

                    return lowerRightCornerSteps - 1 - distance;
                }
            }
            return 0;
        }
    }
}
