using System.Collections.Generic;
namespace AdventOfCode.Day3
{
    public class Santa
    {
        public HashSet<(int, int)> Visited;
        public HashSet<Coordinate> Visited2;
        readonly Coordinate currentCoordinate;

        public Santa()
        {
            currentCoordinate = new Coordinate();

            Visited = new HashSet<(int, int)> { };
            Visited.Add(currentCoordinate.ToTuple());
        }

        public void ReadInstructions(char[] direction)
        {
            foreach (var dir in direction)
            {
                if (dir.Equals('>'))
                {
                    currentCoordinate.X += 1;
                }

                else if (dir.Equals('v'))
                {
                    currentCoordinate.Y -= 1;
                }

                else if (dir.Equals('<'))
                {
                    currentCoordinate.X -= 1;
                }

                else if (dir.Equals('^'))
                {
                    currentCoordinate.Y += 1;
                }

                Visited.Add(currentCoordinate.ToTuple());
            }
        }
    }
}
