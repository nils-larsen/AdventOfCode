using System.Linq;

namespace AdventOfCode.Day5
{
    public static class Rules
    {
        public static bool HasThreeVowels(this string input)
        {
            var niceVowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

            int vowelCount = input.Count(c => niceVowels.Contains(c));

            return vowelCount > 2;
        }

        public static bool HasDoubleLetters(this string input)
        {
            var all = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            foreach (var c in all.Where(c => input.Contains($"{c}{c}")))
            {
                return true;
            }
            return false;
        }

        public static bool HasNoForbiddenStrings(this string input)
        {
            var forbidden = new string[] { "ab", "cd", "pq", "xy" };

            foreach (var f in forbidden)
            {
                if (input.Contains(f))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool HasDoublePairs(this string input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                var pair = input.Substring(i, 2);

                if (input.IndexOf(pair, i + 2) != -1)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool HasRepeatingLetter(this string input)
        {
            var letters = input.ToCharArray();

            for (var i = 0; i < letters.Length - 2; i++)
            {
                if (letters[i] == letters[i + 2])
                    return true;
            }
            return false;
        }
    }
}
