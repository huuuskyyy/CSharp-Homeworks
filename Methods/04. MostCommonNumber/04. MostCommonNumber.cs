//Write a method that counts how many times given number appears in given array. 
//Write a test program to check if the method is working correctly

using System;

class CheckNumCount
{
    static int NumCount(int[] array, int search)
    {
        int counter = 0;
        foreach (int i in array)
        {
            if (i == search)
            {
                counter++;
            }
        }

        return counter;
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
        Console.WriteLine("Enter the number you want to check how many times appears in the array");
        int searchNum = int.Parse(Console.ReadLine());

        int result = NumCount(array, searchNum);

        Console.WriteLine(result+" times");
    }
}
