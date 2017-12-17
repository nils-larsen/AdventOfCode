using System.Collections.Generic;

namespace AdventOfCode.Day17
{
    public static class Spinlock
    {
        public static int StartInsertion(int stepSize)
        {
            var position = 0;
            var list = new List<int>(2018);
            list.Insert(position, 0);

            for (var length = 1; length < 2018; length++)
            {
                position = (stepSize + position) % length;
                list.Insert(position, length);
                position++;

                if (length == 2017)
                {
                    return list[position];
                }
            }
            return 0;
        }

        public static int Part2(int stepSize)
        {
            int position = 0;
            int result = 0;
            for (int length = 1; length < 50000001; length++)
            {
                position = (position + stepSize) % length;
                position++;

                if (position == 1)
                {
                    result = length;
                }
            }
            return result;
        }
    }
}
