//Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order
using System;

class Program
{
    static void Main()
    {
        string words = "dog cat owl lion tiger snake dolphin donkey";
        string[] wordsToArray = words.Split(' ');
        Array.Sort(wordsToArray);

        foreach (string s in wordsToArray)
        {
            Console.Write(s + " ");
        }
        Console.WriteLine();
    }
}
