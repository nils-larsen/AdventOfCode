using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode.Day4
{
    public class Day4
    {
        public bool ValidPassphrase(string input)
        {
            var words = input.Split(" ");
            HashSet<string> hashSet = new HashSet<string>();

            return !(words.Any(x => !hashSet.Add(x)));
        }

        public bool ValidPassphraseAnagram(string input)
        {
            var lineWithSortedWords = input
                .Split(" ")
                .Select(w => new string(w.OrderBy(c => c).ToArray()));

            return ValidPassphrase(string.Join(" ", lineWithSortedWords));

        }
    }
}
