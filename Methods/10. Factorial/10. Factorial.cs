//Write a program to calculate n! for each n in the range [1..100]. 

using System;
using System.Numerics;


class FindFactorial
{
    static BigInteger Factorial(int limit)
    {
        BigInteger factorial = 1;

        for (int i = 1; i < limit + 1; i++)
        {
            factorial *= i;
        }

        return factorial;
    }

    static void Main()
    {
        int n = 100;

        for (int i = 1; i < n + 1; i++)
        {
            BigInteger result = Factorial(i);
            Console.WriteLine(result);
        }
    }
}
