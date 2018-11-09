namespace AdventOfCode.Day8
{
    public static class Operators
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
