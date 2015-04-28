using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimum_edit_distance
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstString = "developer";
            string secondString = "enveloped";
            
           decimal cost = CalculateCost(firstString, secondString);
           Console.WriteLine(cost);
        }

        private static decimal CalculateCost(string firstString, string secondString)
        {
            int firstStringLength = firstString.Length;
            int secondStringLength = secondString.Length;
            decimal deleteCost = 0.9m;
            decimal insertCost = 0.8m;
            decimal replaceCost = 1m;

            decimal[,] matrix = new decimal[firstStringLength + 1, secondStringLength + 1];

            if(firstStringLength == 0)
            {
                return secondStringLength;
            }

            if (secondStringLength == 0)
            {
                return firstStringLength;
            }

            for (int i = 0; i <= firstStringLength; i++)
            {
                matrix[i, 0] = i*deleteCost;
            }

            for (int j = 0; j <= secondStringLength;j++)
            {
                matrix[0, j] = j*insertCost;
            }

            for (int i = 1; i <= firstStringLength; i++)
            {
                for (int j = 1; j <= secondStringLength; j++)
                {
                    decimal cost = (secondString[j - 1] == firstString[i - 1]) ? 0 : replaceCost;

                    matrix[i, j] = Math.Min(Math.Min(matrix[i - 1, j] + deleteCost, matrix[i, j - 1] + insertCost), matrix[i - 1, j - 1] + cost);
                }
            }

            Console.Write("      ");
            foreach (var letter in secondString)
            {
                Console.Write(letter + "  ");
            }

            Console.WriteLine();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                if (i > 0)
                {
                    Console.Write(firstString[i - 1] + " ");
                }
                else
                {
                    Console.Write("  ");
                }

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,3}", matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
            return matrix[firstStringLength,secondStringLength];
        }
    }
}
