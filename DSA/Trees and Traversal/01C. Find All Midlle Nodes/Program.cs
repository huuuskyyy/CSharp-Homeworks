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
        Dictionary<int, string> leavesPositions = new Dictionary<int, string>();

        for (int i = 0; i < nodes.GetLength(0); i++)
        {
            int firstKey = nodes[i, 0];
            int secondKey = nodes[i, 1];

            if (!leavesPositions.ContainsKey(firstKey))
            {
                leavesPositions.Add(firstKey, "first");
            }
            else
            {
                if (leavesPositions[firstKey] != "first")
                {
                    leavesPositions[firstKey] = "middle";
                }
            }

            if (!leavesPositions.ContainsKey(secondKey))
            {
                leavesPositions.Add(secondKey, "second");
            }
            else
            {
                leavesPositions[secondKey] = "middle";
            }
        }

        var groupNodes = leavesPositions.Where(x => x.Value == "middle");

        foreach (var item in groupNodes)
        {
            Console.Write(item.Key + " ");
        }

        Console.WriteLine();
    }
}
