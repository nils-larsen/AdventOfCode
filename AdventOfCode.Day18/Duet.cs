using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace AdventOfCode.Day18
{
    public static class Duet
    {
        public static long ReadInstructions(this List<Register> registers, List<string> instructions)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            var i = 0;
            long latestSound = 0;

            while (true)
            {
                var instruction = instructions[i++].Split();

                var X = instruction[1].ToChar();
                var Y = instruction.Length > 2 ? instruction[2] : "";

                var indexOfX = registers.FindIndexAt(X);

                switch (instruction[0])
                {
                    case "snd":
                        latestSound = registers.PlaySound(indexOfX);
                        break;
                    case "set":
                        registers.Set(indexOfX, Y);
                        break;
                    case "add":
                        registers.Increase(indexOfX, Y);
                        break;
                    case "mul":
                        registers.Multiply(indexOfX, Y);
                        break;
                    case "mod":
                        registers.Remainder(indexOfX, Y);
                        break;
                    case "rcv":
                        if (registers.Recover(indexOfX))
                            return latestSound;
                        break;
                    case "jgz":
                        i += registers.Jump(indexOfX, Y) - 1;
                        break;
                }
            }
        }

        static long PlaySound(this List<Register> registers, int index)
        {
            return registers.First(x => x.Index == index).Value;
        }

        public static void Set(this List<Register> registers, int index, string Y)
        {
            registers[index].Value = registers.GetValue(Y);
        }

        static void Increase(this List<Register> registers, int index, string Y)
        {
            registers[index].Value += registers.GetValue(Y);
        }

        public static void Multiply(this List<Register> registers, int index, string Y)
        {
            registers[index].Value *= registers.GetValue(Y);
        }

        static void Remainder(this List<Register> registers, int index, string Y)
        {
            registers[index].Value %= registers.GetValue(Y);
        }

        static bool Recover(this List<Register> registers, int index)
        {
            return !(registers.First(x => x.Index == index).Value == 0);
        }

        public static int Jump(this List<Register> registers, int index, string Y)
        {
            return registers[index].Value > 0 ? (int)registers.GetValue(Y) : 1;
        }

        public static int FindIndexAt(this List<Register> registers, char letter)
        {
            return registers.First(x => x.Letter == letter).Index;
        }

        public static long GetValue(this List<Register> registers, string Y)
        {
            if (long.TryParse(Y, out long num))
                return num;

            var indexY = registers.FindIndexAt(Y.ToChar());
            return registers[indexY].Value;
        }

        public static char ToChar(this string c) => Convert.ToChar(c);
    }
}