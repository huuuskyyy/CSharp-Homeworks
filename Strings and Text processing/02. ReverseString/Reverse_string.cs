//Write a program that reads a string, reverses it and prints the result at the console.
using System;
using System.Text;

class Reverse_String
{
    static void Main()
    {
        string str = "Hasta la vista, baby";
        ReverseString(str);
    }

    static void ReverseString(string input)
    {

        char[] charArray = input.ToCharArray();
        StringBuilder result = new StringBuilder();

        for (int i = charArray.Length - 1; i > -1; i--)
        {
            result.Append(charArray[i]);
        }

        Console.WriteLine(result);
    }
}
