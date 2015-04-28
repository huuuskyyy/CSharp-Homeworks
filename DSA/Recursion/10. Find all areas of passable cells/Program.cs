using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_all_areas_of_passable_cells
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
            string path = "";
            List<string> paths = new List<string>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != 'x' && helpMatrix[row, col] == false)
                    {
                        CheckAdjacentCells(row, col, matrix, helpMatrix, ref path);
                        paths.Add(path);
                        path = "";
                    }
                }
            }

            Console.WriteLine(largestArea);
        }

        private static void CheckAdjacentCells(int row, int col, char[,] matrix, bool[,] helpMatrix, ref string path)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1) && matrix[row, col] != 'x' && helpMatrix[row, col] == false)
            {
                helpMatrix[row, col] = true;
                path += " " + row + "," + col;
                CheckAdjacentCells(row + 1, col, matrix, helpMatrix,ref path);
                CheckAdjacentCells(row - 1, col, matrix, helpMatrix,ref  path);
                CheckAdjacentCells(row, col + 1, matrix, helpMatrix,ref path);
                CheckAdjacentCells(row, col - 1, matrix, helpMatrix,ref path);
            }
        }
    }
}
