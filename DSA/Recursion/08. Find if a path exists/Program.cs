using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_if_a_path_exists
{
    class Program
    {
        static void Main()
        {
            char[,] matrix = new char[7, 7]
                {
                {' ', 'x', ' ', 'x', ' ', ' ', ' '},
                {' ', 'x', ' ', 'x', ' ', 'x', 'x'},
                {'s', ' ', ' ', ' ', ' ', 'x', 'e'},
                {' ', ' ', ' ', 'x', ' ', 'x', ' '},
                {' ', ' ', ' ', 'x', ' ', 'x', ' '},
                {' ', 'x', ' ', ' ', ' ', 'x', ' '},
                {' ', 'x', ' ', ' ', ' ', ' ', ' '}
                };

            int startRow = 2;
            int startCol = 0;
            int endRow = 2;
            int endCol = 7;
            string path = "(2,0)";
            HashSet<string> oldPaths = new HashSet<string>();
            oldPaths.Add(path);
            bool pathFound = false;

            List<string> paths = new List<string>();

            FindPaths(startRow, startCol, endRow, endCol, matrix, oldPaths, ref pathFound);

            Console.WriteLine("Is there a path - "+pathFound);

        }

        private static void FindPaths(int row, int col, int endRow, int endCol, char[,] matrix, HashSet<string> visited ,ref bool pathFound)
        {
            if(pathFound)
            {
                return;
            }

            if (row - 1 >= 0 && matrix[row - 1, col] == ' ' && !visited.Contains("(" + (row - 1) + "," + col + ")"))
            {
                string currentPath = "(" + (row - 1) + "," + col + ")";
                HashSet<string> visitedPaths = new HashSet<string>();
                visitedPaths.UnionWith(visited);
                visitedPaths.Add(currentPath);

                FindPaths(row - 1, col, endRow, endCol, matrix, visitedPaths, ref pathFound);
            }
            else if (row - 1 >= 0 && matrix[row - 1, col] == 'e')
            {
                pathFound = true;
                return;
            }

            if (row + 1 < matrix.GetLength(0) && matrix[row + 1, col] == ' ' && !visited.Contains("(" + (row + 1) + "," + col + ")"))
            {
                
                string currentPath = "(" + (row + 1) + "," + col + ")";
                HashSet<string> visitedPaths = new HashSet<string>();
                visitedPaths.UnionWith(visited);
                visitedPaths.Add(currentPath);

                FindPaths(row + 1, col, endRow, endCol, matrix, visitedPaths, ref pathFound);
            }
            else if (row + 1 < matrix.GetLength(0) && matrix[row + 1, col] == 'e')
            {
                pathFound = true;
                return;
            }

            if (col - 1 >= 0 && matrix[row, col - 1] == ' ' && !visited.Contains("(" + row + "," + (col - 1) + ")"))
            {
                string currentPath = "(" + row + "," + (col - 1) + ")";
                HashSet<string> visitedPaths = new HashSet<string>();
                visitedPaths.UnionWith(visited);
                visitedPaths.Add(currentPath);

                FindPaths(row, col - 1, endRow, endCol, matrix, visitedPaths, ref pathFound);
            }
            else if (col - 1 >= 0 && matrix[row, col - 1] == 'e')
            {
                pathFound = true;
                return;
            }

            if (col + 1 < matrix.GetLength(1) && matrix[row, col + 1] == ' ' && !visited.Contains("(" + row + "," + (col + 1) + ")"))
            {
                string currentPath = "(" + row + "," + (col + 1) + ")";
                HashSet<string> visitedPaths = new HashSet<string>();
                visitedPaths.UnionWith(visited);
                visitedPaths.Add(currentPath);

                FindPaths(row, col + 1, endRow, endCol, matrix, visitedPaths, ref pathFound);
            }
            else if (col + 1 < matrix.GetLength(1) && matrix[row, col + 1] == 'e')
            {
                pathFound = true;
                return;
            }
        }
    }
}
