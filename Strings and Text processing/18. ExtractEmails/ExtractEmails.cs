//Write a program for extracting all email addresses from given text. All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.
using System;
using System.Text.RegularExpressions;

class FindEmails
{
    static void Main()
    {
        string text = "This is an example with some email. The program will recognize this email example@example.com and will not this one example2@example..com. One more valid email is example-3@example.com and invalid example@.example.com";
        Regex regexFindEmail = new Regex(@"[\w+-]+[@]\w+[.]\w+");

        MatchCollection emails = regexFindEmail.Matches(text);

        foreach (var match in emails)
        {
            Console.WriteLine("{0}", match);
        }


    }
}
