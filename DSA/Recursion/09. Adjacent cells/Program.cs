using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjacent_cells
{
    class Program
    {
        static void Main()
        {
            char[,] matrix = new char[7, 7]
                {
                {' ', 'x', ' ', 'x', ' ', ' ', ' '},
                {'x', 'x', ' ', 'x', 'x', 'x', 'x'},
                {' ', 'x', ' ', 'x', 'x', 'x', ' '},
                {' ', 'x', 'x', ' ', ' ', 'x', ' '},
                {' ', ' ', ' ', ' ', 'x', 'x', ' '},
                {' ', 'x', 'x', ' ', 'x', 'x', ' '},
                {' ', 'x', ' ', ' ', 'x', ' ', ' '}
                };

            bool[,] helpMatrix = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            int largestArea = 0;


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != 'x' && helpMatrix[row, col] == false)
                    {
                        int countAdjacentCells = 0;
                        CheckAdjacentCells(row, col, matrix, helpMatrix, ref countAdjacentCells, ref largestArea);
                    }
                }
            }

            Console.WriteLine(largestArea);
        }

        private static void CheckAdjacentCells(int row, int col, char[,] matrix, bool[,] helpMatrix, ref int countAdjacentCells, ref int largestArea)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1) && matrix[row, col] != 'x' && helpMatrix[row, col] == false)
            {
                countAdjacentCells++;
                helpMatrix[row, col] = true;
                CheckAdjacentCells(row + 1, col, matrix, helpMatrix, ref countAdjacentCells, ref largestArea);
                CheckAdjacentCells(row - 1, col, matrix, helpMatrix, ref countAdjacentCells, ref largestArea);
                CheckAdjacentCells(row, col + 1, matrix, helpMatrix, ref countAdjacentCells, ref largestArea);
                CheckAdjacentCells(row, col - 1, matrix, helpMatrix, ref countAdjacentCells, ref largestArea);
            }

            if (countAdjacentCells > largestArea)
            {
                largestArea = countAdjacentCells;
            }
        }
    }
}
