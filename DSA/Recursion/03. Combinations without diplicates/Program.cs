using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinations_without_duplicates
{
    class Program
    {
        static void Main()
        {
            int limit = 6;
            int arraySize = 2;
            int[] array = new int[arraySize];
            int start = 1;
            int count = 1;

            Loop(0, array, limit, start,ref count);

        }

        public static void Loop(int index, int[] array, int limit, int start,ref int count)
        {
            if (index >= array.Length)
            {
                Console.WriteLine(count+" === "+string.Join(" ", array));
                count++;
            }
            else
            {
                for (int i = start; i <= limit; i++)
                {
                    array[index] = i;
                    start++;
                    Loop(index + 1, array, limit, start,ref count);
                }
            }
        }
    }
}
