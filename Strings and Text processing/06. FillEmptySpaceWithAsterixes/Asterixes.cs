//Write a program that reads from the console a string of maximum 20 characters. 
//If the length of the string is less than 20, the rest of the characters should be filled with '*'. Print the result string into the console
using System;
using System.Text;

class Asterixes
{
    static void Main()
    {
        string input = "Example";
        StringBuilder text = new StringBuilder();
        foreach (char c in input)
        {
            text.Append(c);
        }

        while (text.Length < 20)
        {
            text.Append('*');
        }

        Console.WriteLine(text);

    }
}
