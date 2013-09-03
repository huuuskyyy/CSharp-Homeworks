//Write a program to convert decimal numbers to their hexadecimal representation

using System;
using System.Text;

class ConvertToHexadecimal
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        StringBuilder binary = new StringBuilder();
        int remain = 0;

        while (num > 0)
        {
            remain = num % 16;
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

            num = num / 16;
        }

        for (int i = 0; i < binary.Length; i++)
        {
            Console.Write(binary[i]);
        }

        Console.WriteLine();
    }

}
