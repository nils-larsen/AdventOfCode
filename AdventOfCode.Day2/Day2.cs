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

            foreach (var value in values)
            {
                for (var i = 0; i < numberOfValues; i++)
                {
                    if ((value % values.ElementAt(i)) == 0 && (value != values.ElementAt(i)))
                    {
                        var lineValue = value / values.ElementAt(i);
                        _day2.Add(lineValue);
                        return;
                    }
                }
            }
        }
    }
}