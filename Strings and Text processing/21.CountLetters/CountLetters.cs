//Write a program that reads a string from the console and prints all different letters in the string along with information how many times each letter is found
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string text = "Write a program that reads a string from the console and prints all different letters in the string along with information how many times each letter is found".ToLower();
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        List<char> chars = new List<char>();
        List<int> count = new List<int>();
        int counter = 0;

        foreach (char c in alphabet)
        {
            foreach (char v in text)
            {
                if (v == c)
                {
                    counter++;
                }
            }

            if (counter > 0)
            {
                chars.Add(c);
                count.Add(counter);
            }
            counter = 0;
        }


        for (int i = 0; i < chars.Count; i++)
        {
            Console.WriteLine("char '{0}' - {1} times", chars[i], count[i]);
        }

    }
}
