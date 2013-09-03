//Write a program to check if in a given expression the brackets are put correctly
using System;

class Check_Brackets
{
    static void Main()
    {
        string exampleOne = "(4+5)*9-(4/2(7-8))";
        string exampleTwo = "(6-7))*((4+1)";
        CheckBrackets(exampleOne);
        CheckBrackets(exampleTwo);
    }

    static void CheckBrackets(string input)
    {
        bool isBracketPlacedCorrect = false;
        int openBracket = 0;
        int closedBracket = 0;

        foreach (char c in input)
        {

            if (c == '(')
            {
                if (!isBracketPlacedCorrect)
                {
                    isBracketPlacedCorrect = true;
                }

                openBracket++;
            }
            if (c == ')')
            {
                if (isBracketPlacedCorrect)
                {
                    isBracketPlacedCorrect = false;
                }

                closedBracket++;
            }
            if (closedBracket > openBracket)
            {
                break;
            }
        }

        if (closedBracket != openBracket || isBracketPlacedCorrect)
        {
            Console.WriteLine("Incorrect brackets");
        }
        else
        {
            Console.WriteLine("Brackets are correct");
        }
    }
}
