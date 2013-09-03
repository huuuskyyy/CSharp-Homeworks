//Write a program that extracts from given XML file all the text without the tags

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class FindWordsInXMLFile
{
    static void Main()
    {
        Console.WriteLine("Enter the full path of the text file");
        string path = Console.ReadLine();
        StreamReader reader = new StreamReader(path);

        StreamWriter writer = new StreamWriter("text.txt", false, Encoding.GetEncoding("windows-1251"));
        StringBuilder text = new StringBuilder();
        List<string> words = new List<string>();

        using (reader)
        {
            string line = reader.ReadLine();
            
            
            while (line != null)
            {
                int index = line.IndexOf(">", 0);

                while (index != -1)
                {
                    if (index == line.Length)
                    {
                        break;
                    }
                    if (index < line.Length-1 && line[index + 1].ToString() != "<")
                    {
                        while (line[index + 1].ToString() != "<")
                        {
                            text.Append(line[index+1]);
                            index++;
                        }

                        words.Add(text.ToString());
                        text.Clear();
                    }

                    index = line.IndexOf(">", index+1);
                }

                line = reader.ReadLine();
            }
        }

        using (writer)
        {
            for (int i = 0; i < words.Count; i++)
            {
                writer.WriteLine(words[i]);
            }
            
        }

    }
}
