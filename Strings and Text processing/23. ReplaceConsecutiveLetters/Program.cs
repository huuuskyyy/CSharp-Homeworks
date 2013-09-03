//Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one
using System;
using System.Text;

class Program
{
    static void Main()
    {
        string text = "bbbbbbaaaaaaaatttttTTmmMmmmmaaaaNNNNnn".ToLower().Trim();
        StringBuilder builder = new StringBuilder();
        builder.Append(text[0]);

        foreach (char c in text)
        {

            if (c != builder[builder.Length - 1])
            {
                builder.Append(c);
            }
        }

        Console.WriteLine(builder.ToString());

    }
}
 