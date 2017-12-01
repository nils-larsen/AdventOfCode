using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day1
    {
        private int CalculateSum(IList<int> sequence, int stepSize)
        {
            var sum = 0;
            var sequenceLength = sequence.Count;

            for (var idx = 0; idx < sequenceLength; idx++)
            {
                if (sequence[idx] == sequence[stepSize])
                {
                    sum += sequence[idx];
                }

                stepSize++;
                if (stepSize == sequenceLength)
                {
                    stepSize = 0;
                }
            }
            return sum;
        }

        public int ReviewSequenceBasedOnNextDigit(IList<int> sequence)
        {
            return CalculateSum(sequence, 1);
        }

        public int ReviewSequenceBasedOnHalfWayAround(IList<int> sequence)
        {
            return CalculateSum(sequence, sequence.Count / 2);
        }

        //public int ReviewSequencePart1(IList<int> sequence)
        //{
        //    var sum = 0;

        //    for (var idx = 1; idx < sequence.Count; idx++)
        //    {
        //        if (sequence[idx] == sequence[idx - 1])
        //        {
        //            sum += sequence[idx];
        //        }
        //    }

        //    if (sequence.First() == sequence.Last())
        //    {
        //        sum += sequence.Last();
        //    }

        //    return sum;
        //}

        //public int ReviewSequencePart2(IList<int> sequence)
        //{
        //    var sum = 0;
        //    var sequenceLength = sequence.Count;
        //    var idxAhead = sequenceLength / 2;

        //    for (var idx = 0; idx < sequenceLength; idx++)
        //    {
        //        if (sequence[idx] == sequence[idxAhead])
        //        {
        //            sum += sequence[idx];
        //        }

        //        idxAhead++;

        //        if (idxAhead == sequenceLength)
        //        {
        //            idxAhead = 0;
        //        }
        //    }

        //    return sum;
        //}
    }
}