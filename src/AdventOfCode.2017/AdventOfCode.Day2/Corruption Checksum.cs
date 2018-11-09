using System.Linq;

namespace AdventOfCode.Day2
{
    public static class Day2
    {
        public static int CalculateChecksum(this string input)
        {
            var orderedInput = input
                .Split()
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToList();

            return orderedInput.Last() - orderedInput.First();
        }

        public static int CalculateEvenlyDivisibleChecksum(this string input)
        {
            var values = input
                .Split()
                .Select(int.Parse)
                .ToList();

            int numberOfValues = values.Count;

            for (var i = 0; i < numberOfValues; i++)
            {
                for (var j = 0; j < numberOfValues; j++)
                {
                    if (values[i] % values[j] == 0 && i != j)
                    {
                        return values[i] / values[j];
                    }
                }
            }
            return 0;
        }
    }
}