//Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers.
//Use variable number of arguments

using System;

class SimpleProgram
{
    static int Minimum(params int[] input)
    {
        int min = Int32.MaxValue;

        foreach (int i in input)
        {
            if (i < min)
            {
                min = i;
            }
        }

        return min;
    }

    static int Maximum(params int[] input)
    {
        int min = Int32.MinValue;

        foreach (int i in input)
        {
            if (i > min)
            {
                min = i;
            }
        }

        return min;
    }

    static double Avarage(params int[] input)
    {
        double avarage = 0;

        foreach (int i in input)
        {
            avarage += i;
        }

        avarage = avarage / input.Length;
        return avarage;
    }

    static int Sum(params int[] input)
    {
        int totalSum = 0;

        foreach (int i in input)
        {
            totalSum += i;
        }
        return totalSum;
    }

    static int Product(params int[] input)
    {
        int totalProduct = 1;

        foreach (int i in input)
        {
            totalProduct *= i;
        }
        return totalProduct;
    }


    static void Main()
    {
        Console.WriteLine("Minimum element is " + Minimum(4, 8, -5, -12, 0, 1));
        Console.WriteLine("Maximum element is " + Maximum(0, 4, 1, -11, 8, -4, 2));
        Console.WriteLine("Avarage is " + Avarage(4, 9, 0, 4));
        Console.WriteLine("Sum is " + Sum(5, 4, 3));
        Console.WriteLine("Product is " + Product(5, 11, 9, 4, 3));
    }
}
