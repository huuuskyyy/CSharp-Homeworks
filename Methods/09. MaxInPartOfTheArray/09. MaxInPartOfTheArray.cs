//Write a method that returns the maximal element in a portion of array of integers starting at given index. 
//Using it write another method that sorts an array in ascending / descending order

using System;

class FindMaxAndSort
{
    static int FindMax(int[] arr, int begin, int stop)
    {
        int max = Int32.MinValue;
        int temp = 0;

        for (int i = begin; i <= stop; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
                temp = arr[begin];
                arr[begin] = arr[i];
                arr[i] = temp;
            }
        }

        return max;

    }

    static int[] Sort(int[] input) //sorts in descending order
    {
        int[] output = new int[input.Length];

        for (int i = 0; i < input.Length; i++) //for ascending sort use (for (int i = inputLength-1; i>-1; i--)
        {
            output[i] = FindMax(input, i, input.Length - 1);
        }
        return output;
    }

    static void Main()
   {
      Console.WriteLine("Enter array's length");
       int length = int.Parse(Console.ReadLine());
       Console.WriteLine("Enter array's elements");
       int[] array = new int [length];
       
       for (int i = 0; i<length; i++)
       {
           Console.Write("Enter array[{0}] ",i);
            array[i] = int.Parse(Console.ReadLine());   
       }
       Console.WriteLine("Enter start and end index of the part of the array that you want to check(start and end are included in the search)");
        Console.WriteLine("Start: ");
           int start = int.Parse(Console.ReadLine());
       Console.WriteLine("End: ");
           int end = int.Parse(Console.ReadLine());
       
       int maxInPortion = FindMax(array, start, end);
       Console.WriteLine("Max element from between {0} and {1} positions is {2}", start, end, maxInPortion);
      
       int[] result = Sort(array);
       
       foreach(int i in result)
       {
         Console.Write(i);
       }
   }
}
