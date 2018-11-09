using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode.Day19
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    };

    public static class Tubes
    {
        public static (string, int) Solve(string input)
        {
            var letters = new List<char>();
            var map = input.Split('\n').ToList();

            var steps = 0;

            var x = input.IndexOf('|');
            var y = 0;
            var coord = new Coordinate(x, y);

            var direction = Direction.Down;

            while (true)
            {
                steps++;
                coord = GetNextCoordinate(coord, direction);
                var nextChar = map[coord.Y][coord.X];

                if (nextChar == ' ')
                    break;

                if (nextChar == '|' || nextChar == '-')
                    continue;

                if (nextChar >= 'A' && nextChar <= 'Z')
                {
                    letters.Add(nextChar);
                    continue;
                }

                if (nextChar == '+')
                {
                    direction = ChangeDirection(coord, direction, map);
                    continue;
                }
            }
            return (letters.Join(), steps);
        }

        public static bool AtChar(this char c)
        {
            return (c >= 'A' && c <= 'Z');
        }

        public static Direction ChangeDirection(Coordinate coord, Direction direction, List<string> map)
        {
            if (direction == Direction.Up || direction == Direction.Down)
            {
                if (map[coord.Y][coord.X - 1] == '-' || map[coord.Y][coord.X - 1].AtChar())
                    return Direction.Left;

                if (map[coord.Y][coord.X + 1] == '-' || map[coord.Y][coord.X + 1].AtChar())
                    return Direction.Right;
            }
            if (direction == Direction.Left || direction == Direction.Right)
            {
                if (map[coord.Y - 1][coord.X] == '|' || map[coord.Y - 1][coord.X].AtChar())
                    return Direction.Up;

                if (map[coord.Y + 1][coord.X] == '|' || map[coord.Y + 1][coord.X].AtChar())
                    return Direction.Down;
            }
            return direction;
        }

        public static Coordinate GetNextCoordinate(Coordinate coord, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return new Coordinate(coord.X, coord.Y - 1);
                case Direction.Down:
                    return new Coordinate(coord.X, coord.Y + 1);
                case Direction.Left:
                    return new Coordinate(coord.X - 1, coord.Y);
                case Direction.Right:
                    return new Coordinate(coord.X + 1, coord.Y);
            }
            return coord;
        }
    }

    public static class TubesExtensions
    {
        public static string Join<T>(this IList<T> letters)
        {
            return string.Join("", letters);
        }
    }
}