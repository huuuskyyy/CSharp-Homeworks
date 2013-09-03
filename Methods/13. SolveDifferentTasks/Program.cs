//Write a program that can solve these tasks: Reverses the digits of a number
//Calculates the average of a sequence of integers, Solves a linear equation a * x + b = 0
//Create appropriate methods. Provide a simple text-based menu for the user to choose which task to solve.
//Validate the input data: The decimal number should be non-negative/The sequence should not be empty
//a should not be equal to 0

using System;
using System.Collections.Generic;

class SimpleProgram
{
    static List<int> Reverse(int number)
    {
        List<int> reverseNum = new List<int>();
        int digit = 0;

        while (number > 0)
        {
            digit = number % 10;
            reverseNum.Add(digit);
            number = number / 10;
        }

        return reverseNum;
    }

    static decimal Avarage(decimal[] input)
    {
        decimal totalSum = 0;

        foreach (decimal d in input)
        {
            totalSum += d;
        }

        decimal avarageInSequence = (decimal)(totalSum / input.Length);
        return avarageInSequence;
    }

    static decimal Solve(decimal first, decimal second)
    {
        decimal equationResult = -second / first;
        return equationResult;
    }

    static void Main()
    {
        Console.WriteLine("What do you want to do :\n-press 1 for reversing digits of a number\n-press 2 for calculating the avarage\n-press 3 for solving linear equation");
        int userChoice = int.Parse(Console.ReadLine());
        int num = -1;
        decimal a = 0;

        if (userChoice == 1)
        {
            while (num < 0)
            {
                Console.WriteLine("Enter a positive number ");
                num = int.Parse(Console.ReadLine());
            }

            List<int> reversed = Reverse(num);

            Console.WriteLine("The reversed number is ");
            foreach (int i in reversed)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }

        else if (userChoice == 2)
        {
            Console.WriteLine("Enter the length of sequence");
            int length = int.Parse(Console.ReadLine());
            decimal[] array = new decimal[length];

            Console.WriteLine("Enter the sequence's elements");
            for (int i = 1; i < length + 1; i++)
            {
                Console.Write("Enter {0} element", i);
                array[i - 1] = decimal.Parse(Console.ReadLine());
            }

            decimal avarageResult = Avarage(array);
            Console.WriteLine("The avarage is " + avarageResult);
        }

        else if (userChoice == 3)
        {
            Console.WriteLine("Enter a and b for the equation a*x + b = 0");
            while (a == 0)
            {
                Console.Write("Enter a coefficient(positive) - ");
                a = decimal.Parse(Console.ReadLine());
            }
            Console.Write("Enter b coefficient - ");
            decimal b = decimal.Parse(Console.ReadLine());

            decimal equationSolved = Solve(a, b);

            Console.WriteLine("The result is " + equationSolved);
        }
    }
}
