//Write a program that deletes from a text file all words that start with the prefix "test". Words contain only the symbols 0...9, a...z, A…Z, _.

using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class ReplaceWordByPrefix
{
    static void Main()
    {
        Console.WriteLine("Enter the full path of the text file");
        string path = Console.ReadLine();
        StreamReader reader = new StreamReader(path);

        
        List<string> lines = new List<string>();

            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    line = (Regex.Replace(line, @"\btest\w*\b", ""));
                    lines.Add(Regex.Replace(line, @"(\s){2,}", " "));
                    line = reader.ReadLine();
                }

            }

            StreamWriter writer = new StreamWriter(path, false, Encoding.GetEncoding("windows-1251"));

            using (writer)
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    writer.WriteLine(lines[i]);
                }
            }
    }
}
