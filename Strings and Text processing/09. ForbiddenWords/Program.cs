//We are given a string containing a list of forbidden words and a text containing some of these words.
//Write a program that replaces the forbidden words with asterisks
using System;
using System.Collections.Generic;
using System.Text;

class ForbiddenWords
{
    static void Main()
    {
        StringBuilder text = new StringBuilder("Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR");
        List<string> forbiddenWords = new List<string>();
        forbiddenWords.Add("PHP");
        forbiddenWords.Add("CLR");
        forbiddenWords.Add("Microsoft");

        foreach (string s in forbiddenWords)
        {
            StringBuilder temp = new StringBuilder();

            foreach (char c in s)
            {
                temp.Append('*');
            }

            text.Replace(s, temp.ToString());
        }

        Console.WriteLine(text.ToString());
    }
}
