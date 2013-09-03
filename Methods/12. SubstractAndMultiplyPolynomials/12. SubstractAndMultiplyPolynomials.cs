//Extend the program (from taks 11) to support also subtraction and multiplication of polynomials

using System;
using System.Numerics;


class SubstractAndMultiplyPolynomials
{
    static BigInteger[] SumPol(BigInteger[] one, BigInteger[] two)
    {

        int resultLength = 0;

        if (one.Length > two.Length)
        {
            resultLength = one.Length;
            BigInteger[] result = new BigInteger[resultLength];
            for (int i = 0, j = one.Length - 1; i < two.Length; i++, j--)
            {
                result[i] = one[i] + two[i];

            }
            for (int j = two.Length; j < result.Length; j++)
            {
                result[j] = one[j];

            }
            return result;
        }
        else if (one.Length < two.Length)
        {
            resultLength = two.Length;
            BigInteger[] result = new BigInteger[resultLength];
            for (int i = 0, j = two.Length - 1; i < one.Length; i++, j--)
            {
                result[i] = one[i] + two[i];

            }
            for (int j = one.Length; j < result.Length; j++)
            {
                result[j] = two[j];

            }
            return result;
        }
        else
        {
            resultLength = two.Length;
            BigInteger[] result = new BigInteger[resultLength];
            for (int i = 0, j = one.Length - 1; i < one.Length; i++, j--)
            {
                result[i] = one[i] + two[i];

            }
            return result;
        }

    }

    static BigInteger[] SubstractPol(BigInteger[] one, BigInteger[] two)
    {

        int resultLength = 0;

        if (one.Length > two.Length)
        {
            resultLength = one.Length;
            BigInteger[] result = new BigInteger[resultLength];
            for (int i = 0, j = one.Length - 1; i < two.Length; i++, j--)
            {
                result[i] = one[i] - two[i];

            }
            for (int j = two.Length; j < result.Length; j++)
            {
                result[j] = one[j];

            }
            return result;
        }
        else if (one.Length < two.Length)
        {
            resultLength = two.Length;
            BigInteger[] result = new BigInteger[resultLength];
            for (int i = 0, j = two.Length - 1; i < one.Length; i++, j--)
            {
                result[i] = one[i] - two[i];

            }
            for (int j = one.Length; j < result.Length; j++)
            {
                result[j] = two[j];

            }
            return result;
        }
        else
        {
            resultLength = two.Length;
            BigInteger[] result = new BigInteger[resultLength];
            for (int i = 0, j = one.Length - 1; i < one.Length; i++, j--)
            {
                result[i] = one[i] - two[i];

            }
            return result;
        }

    }

    static BigInteger[] MultiPol(BigInteger[] one, BigInteger[] two)
    {
        BigInteger[] multiPol = new BigInteger[one.Length + two.Length - 1];

        for (int i = 0; i < one.Length; i++)
        {
            for (int j = 0; j < two.Length; j++)
            {
                multiPol[i + j] += one[i] * two[j];

            }
        }
        return multiPol;
    }

    static void PrintPol(BigInteger[] array)
    {

        for (int i = array.Length - 1; i > -1; i--)
        {
            if (array[i] != 0 && i != 0)
            {
                if (i != 1 && array[i - 1] > 0)
                {
                    Console.Write("{0}x^{1}+", array[i], i);
                }
                else if (i == 1)
                {
                    if (array[0] > 0)
                    {
                        Console.Write("{0}x+", array[i]);
                    }
                    else
                    {
                        Console.Write("{0}x", array[i]);
                    }
                }
                else
                {
                    Console.Write("{0}x^{1}", array[i], i);
                }

            }
            else if (i == 0)
            {
                if (array[i] != 0)
                {
                    Console.Write("{0}", array[i], i);
                }
            }
        }

        Console.WriteLine();
    }

    static void Main()
    {
        Console.WriteLine("How many members will be in the first polynomial ?");
        int lengthOne = int.Parse(Console.ReadLine());
        BigInteger[] polOne = new BigInteger[lengthOne];
        Console.WriteLine("Enter the coefficients of the polynomial members");
        for (int i = lengthOne - 1; i > -1; i--)
        {
            polOne[i] = BigInteger.Parse(Console.ReadLine());
        }

        Console.WriteLine("How many members will be in the second polynomial ?");
        int lengthTwo = int.Parse(Console.ReadLine());
        BigInteger[] polTwo = new BigInteger[lengthTwo];
        Console.WriteLine("Enter the coefficients of the polynomial members");
        for (int i = lengthTwo - 1; i > -1; i--)
        {
            polTwo[i] = BigInteger.Parse(Console.ReadLine());
        }

        Console.WriteLine("The polynomials are :");
        PrintPol(polOne);
        PrintPol(polTwo);

        BigInteger[] polResult = MultiPol(polOne, polTwo);

        Console.WriteLine("Polynomials are multiplied and the result polynomial is:");
        PrintPol(polResult);

        BigInteger[] polResult2 = SubstractPol(polOne, polTwo);

        Console.WriteLine("Polynomials are substracted and the result polynomial is:");
        PrintPol(polResult2);


    }
}
