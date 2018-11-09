using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day18
{
    public class Register
    {
        public char Letter { get; set; }
        public long Value { get; set; }
        public int Index { get; set; }
    }

    public static class Registers
    {
        public static List<Register> CreateRegisters(char start, char end)
        {
            return Enumerable
                .Range(start, end - start + 1)
                .Select(i => new Register
                {
                    Letter = (char)i,
                    Value = 0,
                    Index = -97 + i++
                })
            .ToList();
        }
    }
}
