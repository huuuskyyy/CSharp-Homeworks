//Write a program that extracts from a given text all palindromes
using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string text = "This is an example with some ABBA dates. The program will lamal recognize this date 30.11.978 and will not recognize this 32.01.2011. One more exe valid date is 01.03.2010 and invalid 03.13.2010";
        char[] symbols = new char[] { ' ', '.', ',', '-', ':', ';', '"', '\'', '(', ')', '?', '!' };
        string[] textToArray = text.Split(symbols);

        foreach (string s in textToArray)
        {
            bool isEqual = true;
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (Char.IsLetter(s[i]))
                {
                    if (s[i] != s[s.Length - i - 1])
                    {
                        isEqual = false;
                        break;
                    }
                }
                else
                {
                    isEqual = false;
                }
            }

            if (isEqual)
            {
                Console.Write(s+" ");
            }
        }
        Console.WriteLine();
    }
}
