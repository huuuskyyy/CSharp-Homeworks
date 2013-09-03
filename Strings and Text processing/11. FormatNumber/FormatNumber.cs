//Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation.
//Format the output aligned right in 15 symbols
using System;

class FormatNumber
{
    static void Main()
    {
        int number = 15;

        Console.WriteLine(" Decimal {0,15}", number);
        Console.WriteLine(" Hexadecimal {0,15:X}", number);
        Console.WriteLine(" Percentage {0,15:P}", number);
        Console.WriteLine(" Scientific notation {0,15:E}", number);

    }
}
