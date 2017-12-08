using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace AdventOfCode.Day8
{
    public class Day8
    {
        public int HighestValue { get; private set; }
        List<Register> _registers;

        public Day8()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            _registers = new List<Register>();
        }

        public void HandleInput(string input)
        {
            var splitLine = input.Split();

            var firstRegister = splitLine.First();
            AddRegister(firstRegister);

            var secondRegister = splitLine[4];
            AddRegister(secondRegister);

            var command = splitLine[1];
            var addValue = int.Parse(splitLine[2]);
            var logicOperator = splitLine[5];
            var compareValue = int.Parse(splitLine.Last());

            var currentValue = _registers
                .Select(x => x)
                .First(x => x.Name == secondRegister)
                .Value;

            if (LogicOperator.Compare(currentValue, compareValue, logicOperator))
            {
                var register = _registers
                    .Select(x => x)
                    .First(x => x.Name == firstRegister);

                if (command == "inc")
                    register.Value += addValue;
                else
                    register.Value -= addValue;

                ChangeHighestValueIfConditionIsMet(register.Value);
            }
        }
        public List<Register> CheckRegister()
        {
            return _registers;
        }

        void AddRegister(string registerName)
        {
            if (!_registers.Any(r => r.Name == registerName))
            {
                _registers.Add(new Register
                {
                    Name = registerName,
                    Value = 0
                });
            }
        }

        void ChangeHighestValueIfConditionIsMet(int value)
        {
            HighestValue = (value > HighestValue) ? value : HighestValue;
        }
    }

    public class Register
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public static class LogicOperator
    {
        public static bool Compare(int currentValue, int compareValue, string logicOperator)
        {
            switch (logicOperator)
            {
                case ">":
                    return currentValue > compareValue;
                case "<":
                    return currentValue < compareValue;
                case ">=":
                    return currentValue >= compareValue;
                case "<=":
                    return currentValue <= compareValue;
                case "==":
                    return currentValue == compareValue;
                case "!=":
                    return currentValue != compareValue;
                default:
                    return false;
            }
        }
    }
}
