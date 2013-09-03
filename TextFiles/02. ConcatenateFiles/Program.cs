//Write a program that concatenates two text files into another text file

using System;
using System.IO;
using System.Text;

    class ConcatenateFiles
    {
        static void Main()
        {
            Console.WriteLine("Enter the full path of the first text file");
            string pathFirst = Console.ReadLine();
            Console.WriteLine("Enter the full path of the second text file");
            string pathSecond = Console.ReadLine();

            StreamReader firstFile = new StreamReader(pathFirst);
            StreamReader secondFile = new StreamReader(pathSecond);
            StreamWriter newFile = new StreamWriter("newFile.txt", false, Encoding.GetEncoding("windows-1251"));

            using (firstFile)
            {
                string first = firstFile.ReadLine();

                using (secondFile)
                {
                    string second = secondFile.ReadLine();

                    using (newFile)
                    {
                        while (first != null)
                        {
                            newFile.WriteLine(first);
                            first = firstFile.ReadLine();

                        }
                        while (second != null)
                        {
                            newFile.WriteLine(second);
                            second = secondFile.ReadLine();

                        }

                    }
                }
            }
            
        }
    }
