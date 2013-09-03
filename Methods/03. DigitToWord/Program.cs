//Write a method that returns the last digit of given integer as an English word. 
//Examples: 512  "two", 1024  "four", 12309  "nine".


using System;

class ConvertDigitToWord
{
    static string DigitToWord(int input)
    {
        input = input % 10;
        string output = "";

        switch (input)
        {
            case 1: output = "one"; break;
            case 2: output = "two"; break;
            case 3: output = "three"; break;
            case 4: output = "four"; break;
            case 5: output = "five"; break;
            case 6: output = "six"; break;
            case 7: output = "seven"; break;
            case 8: output = "eight"; break;
            case 9: output = "nine"; break;
            case 0: output = "zero"; break;
        }
        return output;
    }
    static void Main()
    {
        Console.WriteLine("Enter a number");
        int number = int.Parse(Console.ReadLine());
        string result = "";

        result = DigitToWord(number);

        Console.WriteLine(result);
    }
}
