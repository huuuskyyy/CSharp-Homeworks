//Write a method that reverses the digits of given decimal number. Example: 256  652

using System;

class Reverse
{
    static char[] ReverseDecimal(string val)
    {
        char[] arrayChar = val.ToCharArray();
        char[] reverse = new char[arrayChar.Length];

        for (int i = 0; i < arrayChar.Length; i++)
        {
            reverse[arrayChar.Length - i - 1] = arrayChar[i];
        }

        return reverse;
    }
    static void Main()
    {
        Console.WriteLine("Enter a number");
        string number = Console.ReadLine();

        char[] result = ReverseDecimal(number);

        foreach (char c in result)
        {
            Console.Write(c);
        }

        Console.WriteLine();
    }
}
