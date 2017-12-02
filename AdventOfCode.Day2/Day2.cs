using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day2
{
    public class Day2
    {
        protected List<int> _day2 = new List<int>();

        public int CalculateSum()
        {
            return _day2.Sum();
        }
    }

    public class CalculatePart1 : Day2
    {
        public void AddChecksumOnEachLine(string input)
        {
            var orderedInput = input.Split(" ").Select(int.Parse).OrderBy(x => x);
            var lineCheckSum = orderedInput.Last() - orderedInput.First();
            _day2.Add(lineCheckSum);
        }
    }

    public class CalculatePart2 : Day2
    {
        public void AddSumFromEvenDivisors(string input)
        {
            var values = input.Split(" ").Select(int.Parse);
            int numberOfValues = values.Count();

            for (var i = 0; i < numberOfValues; i++)
            {
                for (var j = 0; j < numberOfValues; j++)
                {
                    if (i == j)
                        continue;

                    if (values.ElementAt(i) % values.ElementAt(j) == 0)
                    {
                        _day2.Add(values.ElementAt(i) / values.ElementAt(j));
                        return;
                    }
                }
            }
        }
    }
}