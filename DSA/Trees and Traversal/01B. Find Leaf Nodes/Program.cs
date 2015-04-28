using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

class Program
{
    static void Main()
    {
        int[,] nodes = new int[,] { { 2, 4 }, { 3, 2 }, { 5, 0 }, { 3, 5 }, { 5, 6 }, { 5, 1 } };
        Dictionary<int, bool> leavesPositions = new Dictionary<int, bool>();

        for (int i = 0; i < nodes.GetLength(0); i++)
        {
            int firstKey = nodes[i, 0];
            int secondKey = nodes[i, 1];

            if (!leavesPositions.ContainsKey(firstKey))
            {
                leavesPositions.Add(firstKey, false);
            }
            else
            {
                leavesPositions[firstKey] = false;
            }

            if (!leavesPositions.ContainsKey(secondKey))
            {
                leavesPositions.Add(secondKey, true);
            }
        }

        var groupNodes = leavesPositions.Where(x => x.Value == true);

        foreach (var item in groupNodes)
        {
            Console.Write(item.Key + " ");
        }

        Console.WriteLine();
    }
}
