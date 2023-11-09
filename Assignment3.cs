
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Export
{
    class Program
    {
        // List all files in a folder recursively using LINQ
        static IEnumerable<string> EnumerateFilesRecursively(string path)
        {
            return Directory.EnumerateFiles(path)
                .Concat(Directory.EnumerateDirectories(path)
                    .SelectMany(directory => EnumerateFilesRecursively(directory)));
        }

        static void Main(string[] args)
        {
            string rootFolder = "your/root/folder/path";
            IEnumerable<string> allFiles = EnumerateFilesRecursively(rootFolder);

            foreach (string file in allFiles)
            {
                Console.WriteLine(file);
            }
        }
    }
}
