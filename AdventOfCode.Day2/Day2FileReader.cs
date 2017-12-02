using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day2
{
    public class FileReader
    {
        public static IEnumerable<string> ReadLinesFromFile(string fileName)
        {
            var pathToFile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, $@"DataInputFiles\{fileName}");

            foreach (var line in File.ReadAllLines(pathToFile))
            {
                var newLine = line.Replace("\t", " ");
                yield return newLine;
            }
        }
    }
}