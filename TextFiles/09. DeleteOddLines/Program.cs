//Write a program that deletes from given text file all odd lines. The result should be in the same file

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class DeleteOddLines
{
    static void Main()
    {
        Console.WriteLine("Enter the full path of the text file that you want to read");
        string path = Console.ReadLine();

        StreamReader reader = new StreamReader(path);
        
        List<string> evenLines = new List<string>();

        using (reader)
        {
            int line = 1;
            string currentLine = reader.ReadLine();

            while (currentLine != null)
            {

                if (line % 2 == 0)
                {
                    evenLines.Add(currentLine);
                }
                line++;
                currentLine = reader.ReadLine();
            }
        }

        StreamWriter writer = new StreamWriter(path, false, Encoding.GetEncoding("windows-1251"));
        using (writer)
        {
            for (int i = 0; i < evenLines.Count; i++)
            {
                writer.WriteLine(evenLines[i]);
            }
        }
    }
}

