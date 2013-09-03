//Write a method that returns the index of the first element in array that is bigger than its neighbors
//or -1, if there’s no such element.

using System;

class CompareNeighbours
{
    static int CompareAdjacent(int[] array)
    {
        int count = array.Length;

        for (int i = 1; i < count - 1; i++)
        {
            if (array[i] > array[i - 1] && array[i] > array[i + 1])
            {
                return i;
            }

        }

        return -1;
    }
    static void Main()
    {
        Console.WriteLine("Enter array's length");
        int length = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter array's elements");
        int[] array = new int[length];

        for (int i = 0; i < length; i++)
        {
            Console.Write("Enter array[{0}] ", i);
            array[i] = int.Parse(Console.ReadLine());
            Console.WriteLine();

        }

        int result = CompareAdjacent(array);
        Console.WriteLine(result);
    }
}
