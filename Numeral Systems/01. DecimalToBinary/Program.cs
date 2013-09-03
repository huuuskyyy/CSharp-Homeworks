//Write a program to convert decimal numbers to their binary representation

using System;
using System.Numerics;
using System.Collections.Generic;

class ConvertToBinary
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        List<int> binary = new List<int>();

        while (num > 0)
        {
            binary.Insert(0, (num % 2));
            num = num / 2;
        }

        foreach (int i in binary)
        {
            Console.Write(i);
        }

        Console.WriteLine();
    }
}

