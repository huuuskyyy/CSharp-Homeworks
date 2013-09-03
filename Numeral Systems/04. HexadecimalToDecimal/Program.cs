//Write a program to convert hexadecimal numbers to their decimal representation

using System;

class ConvertToDecimal
{
    static void Main()
    {
        string hexaNum = Console.ReadLine();
        char[] arr = hexaNum.ToCharArray();
        Array.Reverse(arr);
        double number = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            switch (arr[i])
            {
                case '1': number += Math.Pow(16, i); break;
                case '2': number += (2 * (Math.Pow(16, i))); break;
                case '3': number += (3 * (Math.Pow(16, i))); break;
                case '4': number += (4 * (Math.Pow(16, i))); break;
                case '5': number += (5 * (Math.Pow(16, i))); break;
                case '6': number += (6 * (Math.Pow(16, i))); break;
                case '7': number += (7 * (Math.Pow(16, i))); break;
                case '8': number += (8 * (Math.Pow(16, i))); break;
                case '9': number += (9 * (Math.Pow(16, i))); break;
                case 'A': number += (10 * (Math.Pow(16, i))); break;
                case 'B': number += (11 * (Math.Pow(16, i))); break;
                case 'C': number += (12 * (Math.Pow(16, i))); break;
                case 'D': number += (13 * (Math.Pow(16, i))); break;
                case 'E': number += (14 * (Math.Pow(16, i))); break;
                case 'F': number += (15 * (Math.Pow(16, i))); break;
            }
        }

        Console.WriteLine(number);

    }

}
