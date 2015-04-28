using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generate_combinations
{
    class Program
    {
        static void Main()
        {
            int limit = 3;
            int arraySize = 3;
            int[] array = new int[arraySize];
            int start = 1;

            Loop(0, array, limit, start);

        }

        public static void Loop(int index, int[] array, int limit, int start)
        {
            if (index >= array.Length)
            {
                Console.WriteLine(string.Join(" ", array));
            }
            else
            {
                for (int i = start; i <= limit; i++)
                {
                    array[index] = i;
                    Loop(index + 1, array, limit, start);
                    start++;
                }
            }
        }
    }
}
