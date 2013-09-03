//Write a program that reads a text file and inserts line numbers in front of each of its lines. The result should be written to another text file

using System;
using System.IO;
using System.Text;

class InsertLines
    {
        static void Main()
        {
            Console.WriteLine("Enter the full path of the text file that you want to read");
            string path = Console.ReadLine();
            StreamReader reader = new StreamReader(path);
            StreamWriter writer = new StreamWriter("result.txt",false, Encoding.GetEncoding("windows-1251"));
            int counter = 1;

            using (reader)
            {
                string text = reader.ReadLine();

                using (writer)
                {
                    while (text != null)
                    {
                        writer.WriteLine("{0}: {1}", counter, text);
                        counter++;
                        text = reader.ReadLine();
                        
                    }
                }
            }

        }
    }
