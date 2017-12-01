﻿using System.IO;

namespace AdventOfCode
{
    public class FileReader
    {
        public static string ReadFile(string fileName)
        {
            var pathToFile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, $@"DataInputFiles\{fileName}");
            return File.ReadAllText(pathToFile);
        }
    }
}