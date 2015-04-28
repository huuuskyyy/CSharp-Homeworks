using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

public class Program
{
    static void Main()
    {
        int totalObelisks = int.Parse(Console.ReadLine());
        List<ulong> distances = new List<ulong>();

        for (int i = 0; i < totalObelisks; i++)
        {
            string obeliskCoordinate = Console.ReadLine();

            if (String.IsNullOrEmpty(obeliskCoordinate))
            {
                i--;
                continue;
            }

            string[] coordinates = obeliskCoordinate.Split(' ');
            int x = int.Parse(coordinates[0]);
            int y = int.Parse(coordinates[1]);

            if (x < 0)
            {
                x *= -1;
            }

            if (y < 0)
            {
                y *= -1;
            }

            int totalDistance = x + y;
            distances.Add((ulong)totalDistance);
        }

        ulong totalRope = 0;

        for (int i = 1; i <= totalObelisks; i++)
        {
           ulong combinationPerNumber = CalculateCombinationsPerNumber(i, totalObelisks);

           foreach (var obeliskDistance in distances)
           {
               totalRope += combinationPerNumber * obeliskDistance;
           }
        }

        Console.WriteLine(totalRope);
    }

    private static ulong CalculateCombinationsPerNumber(int combinations, int totalNumbers)
    {
        BigInteger totalCombinations = (Factorial(totalNumbers) / (Factorial(combinations) * Factorial(totalNumbers - combinations)));
        ulong combinationsPerNumber = (ulong) ((totalCombinations * combinations) / totalNumbers);
        //Console.WriteLine("Total combinations = " + totalCombinations + " ||| Combinations length " + combinations+" ||| "+totalNumbers);
        return combinationsPerNumber;
    }

    private static BigInteger Factorial(int number)
    {
        BigInteger factorial = 1;

        for (int i = 1; i <= number; i++)
        {
            factorial *= i;
        }

        return factorial;
    }
}
