//* Modify your last program (task 14) and try to make it work for any number type, not just integer 
//(e.g. decimal, float, byte, etc.). Use generic method (read in Internet about generic methods in C#).

using System;

class GenericMethod
{

    static T Minimum<T>(params T[] input)
    {
        dynamic min = Int32.MaxValue;

        foreach (dynamic i in input)
        {
            if (i < min)
            {
                min = i;
            }
        }

        return min;
    }

    static T Maximum<T>(params T[] input)
    {
        dynamic min = Int32.MinValue;

        foreach (dynamic i in input)
        {
            if (i > min)
            {
                min = i;
            }
        }

        return min;
    }

    static double Avarage<T>(params T[] input)
    {
        double avarage = 0;

        foreach (dynamic i in input)
        {
            avarage += i;
        }

        avarage = avarage / input.Length;
        return avarage;
    }

    static T Sum<T>(params T[] input)
    {
        dynamic totalSum = 0;

        foreach (dynamic i in input)
        {
            totalSum += i;
        }

        return totalSum;
    }

    static T Product<T>(params T[] input)
    {
        dynamic totalProduct = 1;

        foreach (dynamic i in input)
        {
            totalProduct *= i;
        }

        return totalProduct;
    }

    static void Main()
    {
        Console.WriteLine("Minimum element is " + Minimum(4, 8, -5, -12.8, 0, 1));
        Console.WriteLine("Maximum element is " + Maximum(0f, 4, 1, -11L, 8, -4, 2d));
        Console.WriteLine("Avarage is " + Avarage(4f, 9, 0, 4));
        Console.WriteLine("Sum is " + Sum(5.4, 4, 3));
        Console.WriteLine("Product is " + Product(5.4, 11.4f, 9, 4, 3));
    }
}
