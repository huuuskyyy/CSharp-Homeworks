//Write a method that checks if the element at given position in given array of integers 
//is bigger than its two neighbors (when such exist).

using System;

class CompareNeighbours
{
    static void CompareAdjacent(int[] array, int search)
    {
        bool isBiggerLeft = true;
        bool isBiggerRight = true;
        if (search > 0 && search < array.Length - 1)
        {
            isBiggerLeft = array[search] > array[search - 1];
            isBiggerRight = array[search] > array[search + 1];
        }
        else
        {
            Console.WriteLine("The element at this position has only one neighbour!");
            return;
        }
        if (isBiggerLeft && isBiggerRight)
        {
            Console.WriteLine("The element is bigger than its neighbours");
        }
        else
        {
            Console.WriteLine("The element at this position is not bigger than all his neighbours");
        }
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

        Console.WriteLine("Enter the position of the number you want to compare with its neighbours");
        int position = int.Parse(Console.ReadLine());
        CompareAdjacent(array, position);
    }
}
