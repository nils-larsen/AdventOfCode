using System.Linq;

namespace AdventOfCode.Day2
{
    public class Day2
    {
        public int AddCheckSum(string input)
        {
            var orderedInput = input
               .Split()
               .Select(int.Parse)
               .OrderBy(x => x);

            return orderedInput.Last() - orderedInput.First();
        }

        public int AddCheckSumEven(string input)
        {
            var values = input
               .Split()
               .Select(int.Parse);

            int numberOfValues = values.Count();

            for (var i = 0; i < numberOfValues; i++)
            {
                for (var j = 0; j < numberOfValues; j++)
                {
                    if (i == j)
                        continue;

                    if (values.ElementAt(i) % values.ElementAt(j) == 0)
                    {
                        return values.ElementAt(i) / values.ElementAt(j);
                    }
                }
            }
            return 0;
        }
    }
}