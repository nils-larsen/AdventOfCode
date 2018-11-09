using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day6
{
    public class Day6
    {
        public string GetOneRedistribution(string input)
        {
            var distribution = input.Split().Select(int.Parse).ToList();

            var index = distribution.IndexOf(distribution.Max());
            var blocks = distribution[index];

            distribution[index] = 0;
            index++;

            while (blocks > 0)
            {
                if (index > distribution.Count - 1)
                    index = 0;

                distribution[index]++;

                index++;
                blocks--;
            }
            return string.Join(" ", distribution);
        }

        public int NumberOfValidRedistributions(string input)
        {
            return AllRedistributions(input).Count;
        }

        private List<string> AllRedistributions(string input)
        {
            var redistributions = new List<string>();
            while (!redistributions.GroupBy(x => x).Any(x => x.Skip(1).Any()))
            {
                var result = GetOneRedistribution(input);
                redistributions.Add(result);
                input = result;
            }

            return redistributions;
        }

        public int NumberOfRedistributionsBetweenFirstDuplicate(string input)
        {
            var redistributions = AllRedistributions(input);
            var indexOfLastDuplicate = redistributions.Last();

            var indexOfFirstDuplicate = redistributions
                .FindIndex(x => x == indexOfLastDuplicate);

            return redistributions.Count - 1 - indexOfFirstDuplicate;
        }
    }

}
