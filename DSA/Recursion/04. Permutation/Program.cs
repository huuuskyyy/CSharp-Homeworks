using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutation
{
    class Program
    {
        static void Main()
        {
            int limit = 3;
            int[] array = new int[limit];

            Loop(0, array);

        }

        public static void Loop(int index, int[] array)
        {
            if (index >= array.Length)
            {
                Console.WriteLine(string.Join(" ", array));
            }
            else
            {
                for (int i = 1; i <= array.Length; i++)
                {
                    bool isExist = false;

                    for (int j = 0; j < array.Length; j++)
                    {
                        if(array[j] == i)
                        {
                            isExist = true;
                            break;
                        }
                    }
                    if (!isExist)
                    {
                        array[index] = i;
                        Loop(index + 1, array);

                        if(index+1 != array.Length)
                        {
                            array[index + 1] = 0;
                        }
                    }
                }
            }
        }
    }
}
