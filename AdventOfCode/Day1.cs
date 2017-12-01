using System.Collections.Generic;

namespace AdventOfCode
{
    public class Day1
    {
        public int ReviewSequenceBasedOnNextDigit(IList<int> sequence)
        {
            return CalculateSum(sequence, 1);
        }

        public int ReviewSequenceBasedOnHalfWayAround(IList<int> sequence)
        {
            return CalculateSum(sequence, sequence.Count / 2);
        }

        private int CalculateSum(IList<int> sequence, int idxAhead)
        {
            var sum = 0;
            var sequenceLength = sequence.Count;

            for (var idx = 0; idx < sequenceLength; idx++)
            {
                if (sequence[idx] == sequence[idxAhead])
                {
                    sum += sequence[idx];
                }

                idxAhead++;

                if (idxAhead == sequenceLength)
                {
                    idxAhead = 0;
                }
            }
            return sum;
        }
    }
}