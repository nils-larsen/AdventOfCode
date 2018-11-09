using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AdventOfCode.Day5
{
    public class Day5
    {
        public Day5()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        }

        public int SolveJumps(string input)
        {
            var numbers = ToNumbers(input);

            var index = 0;
            var steps = 0;
            var size = numbers.Count;

            while (index >= 0 && index < size)
            {
                numbers[index] += 1;
                index = index + numbers[index] - 1;
                steps++;
            }
            return steps;
        }

        public int SolveStrangerJumps(string input)
        {
            var numbers = ToNumbers(input);

            var index = 0;
            var steps = 0;
            var size = numbers.Count;

            while (index >= 0 && index < size)
            {
                var strangeIndex = index;
                index += numbers[index];
                numbers[strangeIndex] += numbers[strangeIndex] >= 3 ? -1 : 1;
                steps++;
            }
            return steps;
        }

        IList<int> ToNumbers(string input) => input.Split().Select(int.Parse).ToList();
    }
}
