﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Program
{
    static void Main()
    {
        int totalRabitsAsked = int.Parse(Console.ReadLine());
        Dictionary<int, int> rabits = new Dictionary<int, int>();
        int countTotal = 0;

        for (int i = 0; i < totalRabitsAsked; i++)
        {
            int currentRabitAnswer = int.Parse(Console.ReadLine());

            if (!rabits.ContainsKey(currentRabitAnswer))
            {
                rabits.Add(currentRabitAnswer, 1);
            }
            else
            {
                rabits[currentRabitAnswer]++;
            }
        }

        foreach (var pair in rabits)
        {
            int rabitsCount = pair.Key + 1;
            int rabitsAsked = pair.Value;
            // Console.WriteLine("Count "+rabitsCount+" Asked "+rabitsAsked);

            //Console.WriteLine(rabitsAsked);
            if (rabitsCount >= rabitsAsked)
            {
                countTotal += (rabitsCount);
            }
            else if (rabitsCount == 1)
            {
                countTotal += rabitsAsked;
            }
            else
            {
                int remainder = rabitsAsked % rabitsCount;

                countTotal += (rabitsAsked / rabitsCount) * rabitsCount;

                if (remainder != 0)
                {
                    countTotal += rabitsCount;
                }
                
            }
        }

        Console.WriteLine(countTotal);
    }
}
