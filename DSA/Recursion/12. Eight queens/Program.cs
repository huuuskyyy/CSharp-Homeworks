using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eight_queens
{
    class Program
    {
        static void Main()
        {
            int size = 8;
            int[,] field = new int[size, size];
            int variationCounter = 0;

            PlaceQueens(field, ref variationCounter, 0);

            Console.WriteLine(variationCounter);
        }

        private static void PlaceQueens(int[,] field, ref int variationCounter, int row)
        {
            for (int col = 0; col < field.GetLength(1); col++)
            {
                bool isAvailable = CheckIsAvailable(row, col, field);
                int count = row;

                if (isAvailable)
                {
                    field[row, col] = 1;
                    count++;

                    if (count == field.GetLength(0))
                    {
                        variationCounter++;
                    }

                    if (row < field.GetLength(0) - 1)
                    {
                        PlaceQueens(field, ref variationCounter, row + 1);
                    }

                    field[row, col] = 0;

                }

            }
        }

        private static bool CheckIsAvailable(int row, int col, int[,] field)
        {

            for (int i = 0; i < field.GetLength(0); i++)
            {
                if (field[row, i] == 1 || field[i, col] == 1)
                {
                    return false;
                }

                int leftRowCell = row - i - 1;
                int rightRowCell = row + i + 1;
                int upColCell = col - i - 1;
                int downColCell = col + i + 1;

                if (leftRowCell >= 0 && upColCell >= 0 && field[leftRowCell, upColCell] == 1)
                {
                    return false;
                }

                if (leftRowCell >= 0 && downColCell < field.GetLength(1) && field[leftRowCell, downColCell] == 1)
                {
                    return false;
                }

                if (rightRowCell < field.GetLength(0) && downColCell < field.GetLength(1) && field[rightRowCell, downColCell] == 1)
                {
                    return false;
                }

                if (rightRowCell < field.GetLength(0) && upColCell >= 0 && field[rightRowCell, upColCell] == 1)
                {
                    return false;
                }

            }
            return true;
        }
    }
}
