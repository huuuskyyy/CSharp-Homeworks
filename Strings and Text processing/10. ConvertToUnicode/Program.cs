//Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings
using System;

class ConvertToUnicodeChars
{
    static void Main()
    {
        string initial = "Hi!";

        foreach (char c in initial)
        {
            Console.Write("\\u{0:X4}", (int)c);
        }

        Console.WriteLine();

    }
}
