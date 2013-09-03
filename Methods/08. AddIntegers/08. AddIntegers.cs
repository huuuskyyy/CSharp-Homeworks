//Write a method that adds two positive integer numbers represented as arrays of digits 
//(each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
//Each of the numbers that will be added could have up to 10 000 digits.

using System;
using System.Numerics;

class SumNumbers
{
    static BigInteger[] SumNumber(BigInteger[] one, BigInteger[] two)
    {
        BigInteger remain = 0;
        int resultLength = 0;

        if (one.Length > two.Length)
        {
            resultLength = one.Length;
            BigInteger[] result = new BigInteger[resultLength];
            for (int i = 0, j = one.Length - 1; i < two.Length; i++, j--)
            {
                result[j] = ((one[i] + two[i]) % 10) + remain;
                remain = (one[i] + two[i]) / 10;
            }
            for (int i = one.Length - two.Length - 1, j = two.Length; i > -1; i--, j++)
            {
                result[i] = one[j] + remain;
                remain = 0;
            }

            return result;
        }
        else if (one.Length < two.Length)
        {
            resultLength = two.Length;
            BigInteger[] result = new BigInteger[resultLength];
            for (int i = 0, j = two.Length - 1; i < one.Length; i++, j--)
            {
                result[j] = ((one[i] + two[i]) % 10) + remain;
                remain = (one[i] + two[i]) / 10;
            }
            for (int i = two.Length - one.Length - 1, j = one.Length; i > -1; i--, j++)
            {
                result[i] = two[j] + remain;
                remain = 0;
            }
            return result;
        }
        else
        {
            resultLength = two.Length;
            BigInteger[] result = new BigInteger[resultLength];
            for (int i = 0, j = one.Length - 1; i < one.Length; i++, j--)
            {
                result[j] = ((one[i] + two[i]) % 10) + remain;
                remain = (one[i] + two[i]) / 10;
            }
            return result;
        }
    }

    static void Main()
    {
        Console.WriteLine("How many digits will contain the first number ?");
        int lengthOne = int.Parse(Console.ReadLine());
        BigInteger[] numberOne = new BigInteger[lengthOne];
        Console.WriteLine("Enter the digits of the number");
        for (int i = lengthOne - 1; i > -1; i--)
        {
            numberOne[i] = BigInteger.Parse(Console.ReadLine());
        }

        Console.WriteLine("How many digits will contain the second number ?");
        int lengthTwo = int.Parse(Console.ReadLine());
        BigInteger[] numberTwo = new BigInteger[lengthTwo];
        Console.WriteLine("Enter the digits of the number");
        for (int i = lengthTwo - 1; i > -1; i--)
        {
            numberTwo[i] = BigInteger.Parse(Console.ReadLine());
        }

        BigInteger[] sum = SumNumber(numberOne, numberTwo);

        Console.WriteLine();
        foreach (BigInteger i in sum)
        {
            Console.Write(i);
        }
    }
}
