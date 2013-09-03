//Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different.
//Assume the files have equal number of lines

using System;
using System.IO;
using System.Text;

    class CompareTextFiles
    {
        static void Main()
        {
            Console.WriteLine("Enter the first file's path you want to compare");
            string firstPath = Console.ReadLine();
            StreamReader first = new StreamReader(firstPath);

            Console.WriteLine("Enter the second's file path");
            string secondPath = Console.ReadLine();
            StreamReader second = new StreamReader(secondPath);

            int matchCounter = 0;
            int differenceCounter = 0;


            using (first)
            {
                string firstTextLine = first.ReadLine();

                using (second)
                {
                    string secondTextLine = second.ReadLine();

                    while (secondTextLine != null)
                    {
                        if (firstTextLine == secondTextLine)
                        {
                            matchCounter++;
                        }
                        else
                        {
                            differenceCounter++;
                        }

                        firstTextLine = first.ReadLine();
                        secondTextLine = second.ReadLine();
                    }

                }
            }

            Console.WriteLine();
            Console.WriteLine("Matching lines: " + matchCounter);
            Console.WriteLine("Different linse: " + differenceCounter);

        }
    }

