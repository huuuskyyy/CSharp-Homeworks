//Write a program that reads a text file and prints on the console its odd lines

using System;
using System.IO;

 class PrintOddLines
    {
        static void Main()
        {
            Console.WriteLine("Enter the full path of the text file that you want to read");
            string path = Console.ReadLine();

            StreamReader reader = new StreamReader(path);
            
            using (reader)
            {
                int line = 1;
                string currentLine = reader.ReadLine();

                while (currentLine != null)
                {
                    
                    if (line % 2 != 0)
                    {    
                        Console.WriteLine("Line {0} : {1} ", line, currentLine);       
                    }
                    line++;
                    currentLine = reader.ReadLine();
                }
            }
        }
    }

