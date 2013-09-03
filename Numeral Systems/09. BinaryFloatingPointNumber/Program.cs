//* Write a program that shows the internal binary representation of given 32-bit signed floating-point number
//in IEEE 754 format (the C# type float). Example: -27,25  sign = 1, exponent = 10000011,
//mantissa = 10110100000000000000000

using System;

class BinFloatingPoint
{
    static void Main()
    {
        float input = -27.25f;

        Console.WriteLine("The sign is " + Sign(input));
        Console.WriteLine("The exponent is " + Exponent(input));
        Console.WriteLine("The mantissa is " + Mantissa(input));
    }

    static string Sign(float num)
    {
        string leadingSign = "";
        if (num < 0)
        {
            leadingSign = "1";
        }
        else
        {
            leadingSign = "0";
        }

        return leadingSign;
    }

    static string Exponent(float num)
    {
        if (num < 0)
        {
            num *= -1;
        }

        int counter = 0;
        while (true)
        {
            if (num < Math.Pow(2, counter))
            {
                break;
            }
            counter++;
        }

        int exp = (counter - 1) + 127;

        string binaryExp = Convert.ToString(exp, 2);
        return binaryExp;
    }

    static string Mantissa(float numb)
    {
        if (numb < 0)
        {
            numb *= -1;
        }

        int counter = 0;

        while (true)
        {
            if (numb < Math.Pow(2, counter))
            {
                break;
            }
            counter++;
        }

        string result = "";

        double mantissa = (double)numb / Math.Pow(2, counter - 1);
        mantissa = mantissa - 1;

        for (counter = 1; counter < 24; counter++)
        {
            double multiple = Math.Pow(2, -counter);
            if (mantissa - multiple >= 0)
            {
                result += "1";
                mantissa = mantissa - multiple;
            }
            else
            {
                result += "0";
            }
        }
        return result;
    }

}
