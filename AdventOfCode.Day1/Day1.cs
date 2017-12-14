using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day1
{
    public static class InverseCaptcha
    {
        public static int ReviewSequenceBasedOnNextDigit(this IList<int> sequence)
        {
            return sequence.CalculateSum(1);
        }

        public static int ReviewSequenceBasedOnHalfWayAround(this IList<int> sequence)
        {
            return sequence.CalculateSum(sequence.Count / 2);
        }

        public static IList<int> FormatInput(this string input)
        {
            return input.Select(x => int.Parse(x.ToString())).ToList();
        }

        static int CalculateSum(this IList<int> sequence, int idxAhead)
        {
            var sum = 0;
            var sequenceLength = sequence.Count;

            for (var idx = 0; idx < sequenceLength; idx++)
            {
                if (sequence[idx] == sequence[(idx + idxAhead) % sequenceLength])
                    sum += sequence[idx];
            }
            return sum;
        }
    }
}