//Write a method GetMax() with two parameters that returns the bigger of two integers.
//Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

using System;

class BiggestInt
{
    static int GetMax(int first, int second)
    {
        int max = first;
        if (first < second)
        {
            max = second;
        }

        return max;
    }
    static void Main()
    {
        Console.WriteLine("Enter 3 integers");

        int first = int.Parse(Console.ReadLine());
        int second = int.Parse(Console.ReadLine());
        int third = int.Parse(Console.ReadLine());
        int biggest;

        biggest = GetMax(first, second);
        biggest = GetMax(biggest, third);

        Console.WriteLine(biggest);
    }
}
