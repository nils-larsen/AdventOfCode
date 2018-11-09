using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode.Day10
{
    public static class KnotHash
    {
        public static IList<int> Hash(this IList<int> lengths, int listSize, int repetitions = 1)
        {
            var list = Enumerable.Range(0, listSize).ToList();

            var currentPosition = 0;
            var skipSize = 0;

            var lengthOfList = list.Count;

            for (var rep = 0; rep < repetitions; rep++)
            {
                foreach (var length in lengths)
                {
                    list = Twist(list, currentPosition, length, lengthOfList);

                    currentPosition = (currentPosition + length + skipSize++) % lengthOfList;
                }
            }
            return list;
        }

        private static IList<int> DenseHash(this IList<int> list)
        {
            var temp = new List<int>();

            var dense = 0;
            for (var i = 1; i <= 256; i++)
            {
                dense ^= list[i - 1];

                if (i % 16 == 0)
                {
                    temp.Add(dense);
                    dense = 0;
                }
            }
            return temp;
        }

        public static string MakeItDenser(this IList<int> hash)
        {
            return hash.DenseHash().ToHex().Join();
        }

        public static IList<int> FormatInputToLengths(this string input)
        {
            return input.Split(',').Select(int.Parse).ToList();
        }

        public static IList<int> FormatInputToASCII(this string input)
        {
            var extraLenghts = new List<int> { 17, 31, 73, 47, 23 };
            return input.ToASCII().Concat(extraLenghts).ToList();
        }

        private static IList<int> Pinch(IList<int> list, int currentPosition, int length, int lengthOfList)
        {
            var subList = new List<int>(lengthOfList);

            return Enumerable
                .Range(0, length)
                .Select(i => list[(currentPosition + i) % lengthOfList])
                .Reverse()
                .ToList();
        }

        private static List<int> Twist(List<int> list, int currentPosition, int length, int lengthOfList)
        {
            var subList = Pinch(list, currentPosition, length, lengthOfList);

            for (var i = 0; i < length; i++)
            {
                list[(currentPosition + i) % lengthOfList] = subList[i];
            }
            return list;
        }

        private static string Join(this IEnumerable<string> hexList)
        {
            return string.Join("", hexList);
        }

        private static IEnumerable<string> ToHex(this IEnumerable<int> chaos)
        {
            return chaos.Select(x => x.ToString("x2"));
        }

        private static IEnumerable<int> ToASCII(this string input)
        {
            return input.ToCharArray().Select(x => (int)x);
        }
    }
}