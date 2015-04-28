using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_paths_in_a_matrix
{
    class Program
    {
        static void Main()
        {
            char[,] matrix = new char[7,7]
                {
                {' ', 'x', ' ', 'x', ' ', ' ', ' '},
                {' ', 'x', ' ', 'x', ' ', 'x', ' '},
                {'s', ' ', ' ', ' ', ' ', 'x', 'e'},
                {' ', ' ', ' ', 'x', ' ', ' ', ' '},
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

            List<string> paths = new List<string>();

            FindPaths(startRow, startCol, endRow, endCol, matrix, ref paths, path, oldPaths);

            Console.WriteLine("All possible paths count "+paths.Count());

        }

        private static void FindPaths(int row, int col, int endRow, int endCol, char[,] matrix, ref List<string> paths, string path, HashSet<string> visited)
        {
            if (row - 1 >= 0 && matrix[row - 1, col] == ' ' && !visited.Contains("(" + (row - 1) + "," + col + ")"))
            {
                string newPath = path;
                string currentPath = "(" + (row - 1) + "," + col + ")";
                newPath += " " + currentPath;
                HashSet<string> visitedPaths = new HashSet<string>();
                visitedPaths.UnionWith(visited);
                visitedPaths.Add(currentPath);

                FindPaths(row - 1, col, endRow, endCol, matrix, ref paths, newPath, visitedPaths);
            }
            else if (row - 1 >= 0 && matrix[row - 1, col] == 'e')
            {
                path += "(" + endRow + "," + endCol + ")";
                paths.Add(path);
            }

            if (row + 1 < matrix.GetLength(0) && matrix[row + 1, col] == ' ' && !visited.Contains("(" + (row + 1) + "," + col + ")"))
            {
                string newPath = path;
                string currentPath = "(" + (row + 1) + "," + col + ")";
                newPath += " " + currentPath;
                HashSet<string> visitedPaths = new HashSet<string>();
                visitedPaths.UnionWith(visited);
                visitedPaths.Add(currentPath);

                FindPaths(row + 1, col, endRow, endCol, matrix, ref paths, newPath, visitedPaths);
            }
            else if (row + 1 < matrix.GetLength(0) && matrix[row + 1, col] == 'e')
            {
                path += "(" + endRow + "," + endCol + ")";
                paths.Add(path);
            }

            if (col -1 >= 0 && matrix[row, col - 1] == ' ' && !visited.Contains("(" + row + "," + (col-1) + ")"))
            {
                string newPath = path;
                string currentPath = "(" + row + "," + (col-1) + ")";
                newPath += " " + currentPath;
                HashSet<string> visitedPaths = new HashSet<string>();
                visitedPaths.UnionWith(visited);
                visitedPaths.Add(currentPath);

                FindPaths(row, col-1, endRow, endCol, matrix, ref paths, newPath, visitedPaths);
            }
            else if(col -1 >= 0 && matrix[row, col - 1] == 'e')
            {
                path += "(" + endRow + "," + endCol + ")";
                paths.Add(path);
            }

            if (col + 1 < matrix.GetLength(1) && matrix[row, col + 1] == ' ' && !visited.Contains("(" + row + "," + (col + 1) + ")"))
            {
                string newPath = path;
                string currentPath = "(" + row + "," + (col + 1) + ")";
                newPath += " " + currentPath;
                HashSet<string> visitedPaths = new HashSet<string>();
                visitedPaths.UnionWith(visited);
                visitedPaths.Add(currentPath);

                FindPaths(row, col + 1, endRow, endCol, matrix, ref paths, newPath, visitedPaths);
            }
            else if(col + 1 < matrix.GetLength(1) && matrix[row, col + 1] == 'e')
            {
                path += "(" + endRow + "," + endCol + ")";
                paths.Add(path);
            }
        }
    }
}
