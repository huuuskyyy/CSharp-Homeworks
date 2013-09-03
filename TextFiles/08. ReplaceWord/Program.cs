//Modify the solution of the previous problem (07. ReplaceSubstring) to replace only whole words (not substrings)

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class ReplaceWord
{
    static void Main()
    {
        Console.WriteLine("Enter the full path of the text file");
        string path = Console.ReadLine();
        StreamReader reader = new StreamReader(path);

        StreamWriter writer = new StreamWriter("text.txt", false, Encoding.GetEncoding("windows-1251"));

        using (writer)
        {
            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    writer.WriteLine(Regex.Replace(line, @"\bstart\b", "finish"));
                    line = reader.ReadLine();
                }

            }
        }

    }
}
