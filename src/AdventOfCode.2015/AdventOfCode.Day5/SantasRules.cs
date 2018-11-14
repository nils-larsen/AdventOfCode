using System.Linq;
namespace AdventOfCode.Day5
{
    public static class Rules
    {
        public static string HasThreeVowels(this string input)
        {
            var niceVowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

            int vowelCount = input.Count(c => niceVowels.Contains(c));

            return vowelCount > 2 ? input : "";
        }

        public static string HasDoubleLetters(this string input)
        {
            if (input == "")
                return "";

            var all = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            foreach (var c in all.Where(c => input.Contains($"{c}{c}")))
            {
                return input;
            }
            return "";
        }

        public static int HasNoForbiddenStrings(this string input)
        {
            if (input == "")
                return 0;

            var forbidden = new string[] { "ab", "cd", "pq", "xy" };

            foreach (var f in forbidden)
            {
                if (input.Contains(f))
                {
                    return 0;
                }
            }

            return 1;
        }
    }
}
