using System.IO;
using System.Collections.Generic;

namespace AdventOfCode.Day4
{
    public static class FileReader
    {
        public static string[] ReadFile(string fileName)
        {
            var pathToFile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, $@"DataInputFiles/{fileName}");
            return File.ReadAllLines(pathToFile);
        }
    }
}
