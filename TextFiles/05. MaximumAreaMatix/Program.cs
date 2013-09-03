//Write a program that reads a text file containing a square matrix of numbers and finds in the matrix an area of size 2 x 2 with a maximal sum of its elements.
//The first line in the input file contains the size of matrix N. Each of the next N lines contain N numbers separated by space.
//The output should be a single number in a separate text file

using System;
using System.IO;
using System.Text;

class MaximumArea
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the full path of the text.txt file");
        string path = Console.ReadLine();
        StreamReader reader = new StreamReader(path);

        StreamWriter writer = new StreamWriter("text.txt", false, Encoding.GetEncoding("windows-1251"));
        //int number = 0;

        using (writer)
        {
            using (reader)
            {
                string line = reader.ReadLine();
                int matrixSize = int.Parse(line);
                int[,] matrix = new int[matrixSize, matrixSize];

                for (int i = 0; i < matrixSize; i++)
                {
                    line = reader.ReadLine();
                    string[] helper = line.Split(' ');

                    for (int j = 0; j < matrixSize; j++)
                    {
                        matrix[i, j] = int.Parse(helper[j]);
                    }
                }

                writer.WriteLine(FindBiggestMatrix(matrix));
            }
 
        }
    }

    static int FindBiggestMatrix(int[,] input)
    {
        int sum = 0;
        int maxSum = Int32.MinValue;

        for (int row = 0; row < input.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < input.GetLength(1) - 1; col++)
            {
                sum = input[row, col] + input[row, col + 1] +
                              input[row + 1, col] + input[row + 1, col + 1];

                if (sum > maxSum)
                {
                    maxSum = sum;
                }

                sum = 0;
            }
        }

        return maxSum;
    }
}
