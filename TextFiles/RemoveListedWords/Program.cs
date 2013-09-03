//Write a program that removes from a text file all words listed in given another text file. Handle all possible exceptions in your methods

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace RemoveListedWords
{
    class Program
    {
        static void Main()
        {
            try
            {
            Console.WriteLine("Enter the full path of the file you want to edit");
            string editPath = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Enter the full path of the file, where all words are listed");
            string wordsPath = Console.ReadLine();

            StreamReader editReader = new StreamReader(editPath);
            StreamReader wordsReader = new StreamReader(wordsPath);
            List<string> words = new List<string>();
            List<string> result = new List<string>();

            
                using (wordsReader)
                {
                    string line = wordsReader.ReadLine();

                    while (line != null)
                    {
                        words.Add(line);
                        line = wordsReader.ReadLine();
                    }
                }

                using (editReader)
                {
                    string line = editReader.ReadLine();

                    while (line != null)
                    {
                        foreach (string s in words)
                        {
                            string regularExpression = "\\b" + s + "\\b";
                            line = Regex.Replace(line, regularExpression, "");
                        }
                        result.Add(Regex.Replace(line, @"(\s){2,}", " "));
                        line = editReader.ReadLine();
                    }
                }

                StreamWriter writer = new StreamWriter(editPath, false, Encoding.GetEncoding("windows-1251"));

                using (writer)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        writer.WriteLine(result[i]);
                    }
                }
            }
                

            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("\nERROR!!!\n{0}:\n{1}\n", ex.GetType().Name, ex.Message);
            }

        }
    }
}
