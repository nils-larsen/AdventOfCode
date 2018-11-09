namespace AdventOfCode.Day1
{
    public static class FloorCalculator
    {
        public static int CalculateFloor(this char[] pattern)
        {
            var floor = 0;
            foreach (var c in pattern)
            {
                if (c.Equals('('))
                    floor++;
                else
                    floor--;
            }
            return floor;
        }

        public static int CalculateWhenBasementIsReached(this char[] pattern)
        {
            var floor = 0;

            for (var i = 0; i < pattern.Length; i++)
            {
                if (pattern[i].Equals('('))
                    floor++;
                else
                    floor--;

                if (floor == -1)
                    return i + 1;
            }

            return 0;
        }
    }
}
