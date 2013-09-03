//Write a program that reads a list of words from a file words.txt and finds how many times each of the words is contained in another file test.txt. 
//The result should be written in the file result.txt and the words should be sorted by the number of their occurrences in descending order.
//Handle all possible exceptions in your methods

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace CountListedWords
{
    class Program
    {
        static void Main()
        {
            try
            {
                StreamReader editReader = new StreamReader("text.txt");
                StreamReader wordsReader = new StreamReader("words.txt");
                StreamWriter writer = new StreamWriter("result.txt", false, Encoding.GetEncoding("windows-1251"));
                List<string> words = new List<string>();
                List<int> occurences = new List<int>();
               
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
                    string file = editReader.ReadToEnd();
                    string[] fullText = file.Split(new Char [] {',' , '\n', ' ', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string s in words)
                        {
                           int counter = 0;

                            for (int i = 0; i < fullText.Length; i++)
		                    {
			                    if (fullText[i]==s)
                                {
                                    counter++;
                                }
			                }
                            
                            occurences.Add(counter);             
                        }

                        using (writer)
                        {
                            List<string> final = new List<string>();

                            for (int i = 0; i < words.Count; i++)
                            {
                                final.Add(occurences[i]+ " - "+(words[i]));
                            }

                            final.Sort();
                            final.Reverse();

                            foreach (string s in final)
                            {
                                writer.WriteLine(s);
                            }
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
