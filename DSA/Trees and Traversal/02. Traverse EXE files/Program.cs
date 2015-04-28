using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traverse_EXE_files
{
    class Program
    {
        static void Main(string[] args)
        {
            string startDirectory = "C:\\Users\\Angel\\Downloads";
            List<string> exeFiles = new List<string>();

            TraverseDirectories(startDirectory, ref exeFiles);
            Console.WriteLine(exeFiles.Count);

            foreach (var item in exeFiles)
            {
                Console.WriteLine(item);
            }

        }

        public static void TraverseDirectories(string startDirectory, ref List<string> searchedFiles)
        {
            try
            {
                string[] directories = Directory.GetDirectories(startDirectory);
                CheckForEXEFiles(startDirectory, ref searchedFiles);

                foreach (var directory in directories)
                {
                    TraverseDirectories(directory, ref searchedFiles);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void CheckForEXEFiles(string directory, ref List<string> searchedFiles)
        {
            var allEXEFiles = Directory.EnumerateFiles(directory, "*.exe");

            foreach (string currentFile in allEXEFiles)
            {
                string fileName = currentFile.Substring(directory.Length + 1);
                searchedFiles.Add(fileName);
            }
        }
    }
}
