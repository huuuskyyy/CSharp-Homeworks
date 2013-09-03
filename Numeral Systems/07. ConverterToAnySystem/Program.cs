//Write a program to convert from any numeral system of given base s to any other 
//numeral system of base d (2 ≤ s, d ≤  16).

using System;
using System.Text;

class SimpleProgram
{
    static void Main()
    {

        Console.WriteLine("Enter the first numerical system base");
        int firstBase = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter a number in this numerical system");
        string str = Console.ReadLine();
        Console.WriteLine("Enter the base of the numerical system you want to convert the number to");
        int secondBase = int.Parse(Console.ReadLine());

        char[] arr = str.ToCharArray();
        Array.Reverse(arr);
        double number = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            switch (arr[i])
            {
                case '1': number += Math.Pow(firstBase, i); break;
                case '2': number += (2 * (Math.Pow(firstBase, i))); break;
                case '3': number += (3 * (Math.Pow(firstBase, i))); break;
                case '4': number += (4 * (Math.Pow(firstBase, i))); break;
                case '5': number += (5 * (Math.Pow(firstBase, i))); break;
                case '6': number += (6 * (Math.Pow(firstBase, i))); break;
                case '7': number += (7 * (Math.Pow(firstBase, i))); break;
                case '8': number += (8 * (Math.Pow(firstBase, i))); break;
                case '9': number += (9 * (Math.Pow(firstBase, i))); break;
                case 'A': number += (10 * (Math.Pow(firstBase, i))); break;
                case 'B': number += (11 * (Math.Pow(firstBase, i))); break;
                case 'C': number += (12 * (Math.Pow(firstBase, i))); break;
                case 'D': number += (13 * (Math.Pow(firstBase, i))); break;
                case 'E': number += (14 * (Math.Pow(firstBase, i))); break;
                case 'F': number += (15 * (Math.Pow(firstBase, i))); break;
            }
        }

        Console.WriteLine(number);

        StringBuilder binary = new StringBuilder();
        int remain = 0;

        while (number > 1)
        {
            remain = (int)(number % secondBase);
            if (remain < 10)
            {
                binary.Insert(0, remain);
            }
            else
            {
                switch (remain)
                {
                    case 10: binary.Insert(0, "A"); break;
                    case 11: binary.Insert(0, "B"); break;
                    case 12: binary.Insert(0, "C"); break;
                    case 13: binary.Insert(0, "D"); break;
                    case 14: binary.Insert(0, "E"); break;
                    case 15: binary.Insert(0, "F"); break;
                }
            }

            number = number / secondBase;
        }

        for (int i = 0; i < binary.Length; i++)
        {
            Console.Write(binary[i]);
        }

    }
}
