//Write a program that reads a string from the console and lists all different words in the string along with information how many times each word is found
using System;
using System.Collections.Generic;
using System.Linq;

//when I tested the program the first 2 results were cut, by the console. they are in the result list, but are not displayed because are moved up when writting on the console
//unfortunatel I didn't find out how to fix this and that's why I made all results on the same screen and colored them for better reading
class Program
{
    static void Main()
    {
        string text = "Write a program that reads a string from the console and lists all different words in the string along with information how many times each word is found.";
        text = text.ToLower().Trim();
        char[] symbols = new char[] { ' ', '.', ',', '-', ':', ';', '"', '\'', '(', ')', '?', '!' };
        string[] words = text.Split(symbols, StringSplitOptions.RemoveEmptyEntries); 
       
        string[] wordsNoDup = words.Distinct().ToArray();
        List<int> count = new List<int>();
        int counter = 0;

        foreach (string s in wordsNoDup)
        {
            foreach (string c in words)
            {
                if (s == c)
                {
                    counter++;
                }
            }
            count.Add(counter);
            counter = 0;
        }



        for (int i = 0; i < wordsNoDup.Length; i++)
        {
            if (i % 2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\"{0}\" - {1} times", wordsNoDup[i], count[i]);

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   \"{0}\" - {1} times", wordsNoDup[i], count[i]);
            }
        }
        Console.WriteLine();

    }
}
