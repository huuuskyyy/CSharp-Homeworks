using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generate_subsets
{
    class Program
    {
        static void Main()
        {
            int arraySize = 3;
            string[] array = new string[arraySize];
            string[] set = new string[] { "hi", "a", "b" };

            GenerateSubsets(0, array, set, 0);
        }

        private static void GenerateSubsets(int index, string[] array, string[] set, int start)
        {
           if(index >= array.Length)
           {
               Console.WriteLine(string.Join(" ", array));
           }
           else
           {
               for (int i = start; i < set.Length; i++)
               {
                   array[index] = set[i];
                   GenerateSubsets(index + 1, array, set, start);
               }
           }
        }
    }
}
