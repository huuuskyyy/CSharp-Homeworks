//Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
using System;

class CheckSubstring
{
    static void Main()
    {
        string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string word = "in";
        int index = text.ToLower().IndexOf(word);
        int counter = 0;

        while (index != -1)
        {
            counter++;
            index = text.ToLower().IndexOf(word, index + 1);
        }

        Console.WriteLine(counter);
    }
}
