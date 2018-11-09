namespace AdventOfCode.Day3
{
    public class Coordinate
    {
        public Coordinate()
        {
            X = 0;
            Y = 0;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public (int, int) ToTuple()
        {
            return (X, Y);
        }
    }
}
