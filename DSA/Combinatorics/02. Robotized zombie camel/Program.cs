using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    static void Main()
    {
        int totalObelisks = int.Parse(Console.ReadLine());
        List<int> distances = new List<int>();

        for (int i = 0; i < totalObelisks; i++)
        {
            string obeliskCoordinate = Console.ReadLine();

            if (String.IsNullOrEmpty(obeliskCoordinate))
            {
                i--;
                continue;
            }

            string[] coordinates = obeliskCoordinate.Split(' ');
            int x = int.Parse(coordinates[0]);
            int y = int.Parse(coordinates[1]);

            if (x < 0)
            {
                x *= -1;
            }

            if (y < 0)
            {
                y *= -1;
            }

            int totalDistance = x + y;
            distances.Add(totalDistance);
        }

        ulong totalRope = 0;
        int count = 0;

        for (int i = 1; i <= totalObelisks; i++)
        {
            int[] array = new int[i];
            Combinations(0, totalObelisks, i, 0, distances, ref totalRope, array, ref count);
            count = 0;
        }

        Console.WriteLine(totalRope);
    }

    private static void Combinations(int start, int limit, int numberOfCombinations, int index, List<int> distances, ref ulong rope, int[] array,ref int count)
    {
        if (index >= numberOfCombinations)
        {

            //foreach (var position in array)
            //{
            //    rope += (ulong)distances[position];
            //}
            count++;
            return;
        }
        else
        {
            for (int i = start; i < limit; i++)
            {
                //rope +=(ulong) distances[index];
                array[index] = i;
                start++;
                Combinations(start, limit, numberOfCombinations, index + 1, distances, ref rope, array, ref count);

                if(i == 0)
                {
                    CalculateRope(ref rope, distances, count);
                    return;
                }
            }
        }

    }

    private static void CalculateRope(ref ulong rope, List<int> distances, int count)
    {
        foreach (var distance in distances)
        {
            rope += (ulong) (distance*count);
        }
    }
}
