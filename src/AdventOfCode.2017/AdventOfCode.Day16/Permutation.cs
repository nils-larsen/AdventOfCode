using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day16
{
    public static class Permutation
    {
        public static IList<char> SetupPrograms(char start, char end)
        {
            return Enumerable.Range(start, end - start + 1).Select(i => (char)i).ToList();
        }

        public static string Dance(this IList<char> programs, string input, int repetitions = 1)
        {
            var commands = input.Split(',').ToList();

            for (var i = 0; i < repetitions % 36; i++)
            {
                foreach (var cmd in commands)
                {
                    switch (cmd[0])
                    {
                        case 's':
                            programs.Spin(cmd);
                            break;
                        case 'x':
                            programs.Exchange(cmd);
                            break;
                        case 'p':
                            programs.Partner(cmd);
                            break;
                    }
                }
            }
            return programs.Join();
        }

        static void Spin(this IList<char> programs, string cmd)
        {
            var number = cmd.Skip(1).Select(x => int.Parse(x.ToString())).ToInt();

            for (var i = 0; i < number; i++)
            {
                programs.MoveLastItemToFront();
            }
            programs.Reverse().Take(number);
        }

        static void Exchange(this IList<char> programs, string cmd)
        {
            var cmdList = FormatCommand(cmd);
            programs.SwapByIndex(int.Parse(cmdList[0]), int.Parse(cmdList[1]));
        }

        static void Partner(this IList<char> programs, string cmd)
        {
            var cmdList = FormatCommand(cmd);
            programs.SwapByValue(Convert.ToChar(cmdList[0]), Convert.ToChar(cmdList[1]));
        }

        static void SwapByIndex(this IList<char> programs, int indexA, int indexB)
        {
            var temp = programs[indexA];
            programs[indexA] = programs[indexB];
            programs[indexB] = temp;
        }

        static void SwapByValue(this IList<char> programs, char a, char b)
        {
            var indexA = 0;
            var indexB = 0;

            for (var i = 0; i < programs.Count; i++)
            {
                if (programs[i] == a)
                    indexA = i;

                if (programs[i] == b)
                    indexB = i;
            }
            programs.SwapByIndex(indexA, indexB);
        }

        static void MoveLastItemToFront(this IList<char> programs)
        {
            var item = programs.Last();
            var length = programs.Count;

            for (var i = length - 1; i > 0; i--)
            {
                programs[i] = programs[i - 1];
            }
            programs[0] = item;
        }

        static IList<string> FormatCommand(string cmd) => cmd.Skip(1).Join().Split('/');

        static int ToInt(this IEnumerable<int> list) => int.Parse(list.Join());

        static string Join<T>(this IEnumerable<T> list) => string.Join("", list);
    }
}
