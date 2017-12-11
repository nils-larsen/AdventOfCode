using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode.Day10
{
    public class Day10
    {
        public int Solve(string input, List<int> list)
        {
            var lengths = input.Split(',').Select(int.Parse).ToList();

            var currentPosition = 0;
            var skipSize = 0;

            var lengthOfList = list.Count;

            foreach (var length in lengths)
            {
                list = Twist(list, currentPosition, length, lengthOfList);

                currentPosition = (currentPosition + length + skipSize++) % lengthOfList;
            }
            return list[0] * list[1];
        }

        List<int> Pinch(List<int> list, int currentPosition, int length, int lengthOfList)
        {
            var subList = new List<int>(lengthOfList);

            return Enumerable
            .Range(0, length)
            .Select(i => list[(currentPosition + i) % lengthOfList])
            .Reverse()
            .ToList();
        }

        List<int> Twist(List<int> list, int currentPosition, int length, int lengthOfList)
        {
            var subList = Pinch(list, currentPosition, length, lengthOfList);

            for (var i = 0; i < length; i++)
            {
                list[(currentPosition + i) % lengthOfList] = subList[i];
            }
            return list;
        }
    }
}