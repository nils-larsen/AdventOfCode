using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day7
{
    public class Day7
    {
        public string FindBottomProgram(IEnumerable<string> input)
        {
            var linesWithParents = input.Select(x => x).Where(x => x.Contains("->"));

            var parents = linesWithParents.Select(x => x.Split().First());

            var children = string
                .Join(" ", linesWithParents
                      .Select(x => string.Join(" ", x.Replace(",", "").Split().Skip(3))))
                .Split();

            return parents.Except(children).First();
        }
    }
}