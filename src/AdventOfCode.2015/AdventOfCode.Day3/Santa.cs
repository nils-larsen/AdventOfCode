using System;
using System.Collections.Generic;
namespace AdventOfCode.Day3
{
    public static class Santa
    {
        public static List<(int, int)> DeliverBy(this char[] direction, int nrOfSantas)
        {
            var visitedCoordinate = new List<(int, int)>();
            var coordinate = (X: 0, Y: 0);

            for (var i = 0; i < nrOfSantas; i++)
            {
                visitedCoordinate.Add(coordinate);
            }

            for (var i = 0; i < direction.Length; i++)
            {
                var dir = direction[i];

                if (i % 2 == 0)
                {
                    coordinate = visitedCoordinate[i];
                    coordinate = Move(dir, coordinate);
                }
                else
                {
                    coordinate = visitedCoordinate[i];
                    coordinate = Move(dir, coordinate);
                }
                visitedCoordinate.Add(coordinate);
            }
            return visitedCoordinate;
        }

        public static (int, int) Move(char direction, (int X, int Y) coordinate)
        {
            if (direction.Equals('>'))
                coordinate.X += 1;

            else if (direction.Equals('v'))
                coordinate.Y -= 1;

            else if (direction.Equals('<'))
                coordinate.X -= 1;

            else if (direction.Equals('^'))
                coordinate.Y += 1;

            return coordinate;
        }
    }
}
