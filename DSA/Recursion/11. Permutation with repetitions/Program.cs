using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutation_with_repetitions
{
    class Program
    {
        static void Main()
        {
            int[] array = new int[] { 1, 2, 2 };
            int[] permutations = new int[array.Length];
            int start = 0;

            Loop(array.Length, array, start);
        }

        private static void Loop(int index, int[] array, int start)
        {
            Console.WriteLine(string.Join(" ", array));

            int tmp = 0;

            if (start < index)
            {
                for (int i = index - 2; i >= start; i--)
                {
                    for (int j = i + 1; j < index; j++)
                    {
                        if (array[i] != array[j])
                        {
                            // swap array[i] <--> array[j]
                            tmp = array[i];
                            array[i] = array[j];
                            array[j] = tmp;

                            Loop(index, array, i + 1);
                        }
                    }

                    tmp = array[i];
                    for (int k = i; k < index - 1; )
                    {
                        array[k] = array[++k];
                        array[index - 1] = tmp;
                    }
                }

            }
        }
    }
}
