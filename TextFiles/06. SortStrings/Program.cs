//Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class SortStrings
{
    static void Main()
    {
      Console.WriteLine("Enter the full path of the text file");
      string path = Console.ReadLine();
      StreamReader reader = new StreamReader(path);
      
      StreamWriter writer = new StreamWriter("text.txt", false, Encoding.GetEncoding("windows-1251"));
      List<string> list = new List<string>();
        
        using (writer)
        {
            using(reader)
            {
                string line = reader.ReadLine();
                    
                    while(line!=null)
                {
                    list.Add(line);
                    line = reader.ReadLine();
                }

                    list.Sort();
            }
            
            foreach (string s in list)
            {
                writer.WriteLine(s);
            }
        }
      
    }
}
