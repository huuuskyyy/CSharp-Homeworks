using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    static void Main()
    {
        //string firstString = "AGGCTATCACCTGACCTCCAGGCCGATGCCC";
        //string secondString = "TAGCTATCACGACCGCGGTCGATTTGCCCGAC";
        string firstString = "intention";
        string secondString = "execution";
        int firstStringLength = firstString.Length;
        int secondStringLength = secondString.Length;

        int[,] matrix = new int[firstStringLength + 1, secondStringLength + 1];


        for (int i = 1; i <= firstStringLength; i++)
        {
            for (int j = 1; j <= secondStringLength; j++)
            {
                if (firstString[i - 1] == secondString[j - 1])
                {
                    matrix[i, j] = matrix[i - 1, j - 1] + 1;
                }
                else
                {
                    matrix[i, j] = Math.Max(matrix[i, j - 1], matrix[i - 1, j]);
                }

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

        int currentX = matrix.GetLength(0) - 1;
        int currentY = matrix.GetLength(1) - 1;
        List<char> match = new List<char>();

        while (true)
        {
            if (!(currentX > 0) || !(currentY > 0))
            {
                //Console.WriteLine("Break "+currentX+" "+currentY);
                break;
            }

            int currentCell = matrix[currentX, currentY];
            int cellToCompare = matrix[currentX - 1, currentY];

            if (currentCell == cellToCompare)
            {
                currentX--;
                //Console.WriteLine(currentX+" "+currentY);
                continue;
            }

            //match.Insert(0,firstString[currentX-1].ToString());
            //Console.Write(firstString[currentX-1]);
            match.Add(firstString[currentX - 1]);
            currentX--;
            currentY--;
        }

        match.Reverse();
        Console.WriteLine();
        Console.WriteLine(string.Join(" ", match.ToArray()));

    }

}

