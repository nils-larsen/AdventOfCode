using System.Collections.Generic;

namespace AdventOfCode.Day15
{
    public static class Dueling
    {
        public static IEnumerator<long> Generator(this long num, int factor, int modulos = 1)
        {
            while (true)
            {
                var next = (num * factor) % 2147483647;

                if (next % modulos == 0)
                {
                    yield return next;
                }
                num = next;
            }
        }

        public static IEnumerable<int> CompareLowerBits(this IEnumerator<long> listA, IEnumerator<long> listB, int repetitions)
        {
            for (var i = 0; i < repetitions; i++)
            {
                listA.MoveNext();
                listB.MoveNext();

                if ((listA.Current & 0xFFFF) == (listB.Current & 0xFFFF))
                    yield return 1;
            }
        }
    }
}