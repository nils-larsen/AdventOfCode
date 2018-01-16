using AdventOfCode.Day18;
using System.Collections.Generic;
using System.Globalization;

namespace AdventOfCode.Day23
{
    public static class Coprocessor
    {
        public static int ReadNewInstructions(this List<Register> registers, IList<string> instructions)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            var i = 0;
            var multiplications = 0;

            while (true)
            {
                if (i + 1 > instructions.Count)
                    return multiplications;
                var instruction = instructions[i++].Split();

                var X = instruction[1].ToChar();
                var Y = instruction.Length > 2 ? instruction[2] : "";

                int indexOfX = 0;

                if (instruction[0] != "jnz")
                    indexOfX = registers.FindIndexAt(X);

                switch (instruction[0])
                {
                    case "set":
                        registers.Set(indexOfX, Y);
                        break;
                    case "sub":
                        registers.Decrease(indexOfX, Y);
                        break;
                    case "mul":
                        registers.Multiply(indexOfX, Y);
                        multiplications++;
                        break;
                    case "jnz":
                        i += Jump(registers, instruction) - 1;
                        break;
                }
            }
        }

        static void Decrease(this List<Register> registers, int index, string Y)
        {
            registers[index].Value -= registers.GetValue(Y);
        }

        static int Jump(List<Register> registers, string[] instruction)
        {
            var X = instruction[1];
            var Y = instruction[2];

            if (int.TryParse(X, out int intX))
            {
                return registers[intX].Value != 0 ? (int)registers.GetValue(Y) : 1;
            }

            return registers[registers.FindIndexAt(X.ToChar())].Value != 0 ? (int)registers.GetValue(Y) : 1;
        }
    }
}
