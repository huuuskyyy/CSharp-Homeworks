//Write a program to convert binary numbers to their decimal representation

using System;

class ConvertToDecimal
{
    static void Main()
    {
        string str = Console.ReadLine();
        char[] arr = str.ToCharArray();
        Array.Reverse(arr);
        double number = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == '1')
            {
                number += Math.Pow(2, i);
            }
        }

        Console.WriteLine(number);

    }
}
