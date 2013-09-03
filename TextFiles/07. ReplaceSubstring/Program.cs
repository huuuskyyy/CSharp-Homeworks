//Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file.
//Ensure it will work with large files (e.g. 100 MB)
using System;
using System.IO;
using System.Text;

class ReplaceSubstring
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
                
                while (line!=null)
                {
                    writer.WriteLine(line.Replace("start", "finish"));
                      line = reader.ReadLine();               
                }
                
            }
        }
        
    }
}
