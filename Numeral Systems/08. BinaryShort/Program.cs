//Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short)

using System;

class SimpleProgram
{
    static void Main()
    {
        short input = short.Parse(Console.ReadLine());
        string result = "";

        for (int i = 15; i > -1; i--)
        {
            int mask = 1 << i;
            int nAndMask = input & mask;
            int bit = nAndMask >> i;

            if (bit == 1)
            {
                result += "1";
            }
            else
            {
                result += "0";
            }
        }

        Console.WriteLine(result);
        Console.WriteLine(result.Length);

    }
}
