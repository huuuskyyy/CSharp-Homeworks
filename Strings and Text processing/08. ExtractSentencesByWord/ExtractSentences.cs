//Write a program that extracts from a given text all sentences containing given word
using System;
using System.Text;

class ExtractSentences
{
    static void Main()
    {
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days. ";

        StringBuilder sentence = new StringBuilder();

        foreach (char c in text)
        {
            sentence.Append(c);

            if (c == '.')
            {
                string str = sentence.ToString();
                if (str.IndexOf(" in ") != -1 || str.IndexOf("In ") != -1 || str.IndexOf(" in.") != -1)
                {
                    Console.WriteLine(sentence.ToString());
                }
                sentence.Clear();
            }
        }
    }
}
