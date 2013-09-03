//Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. Display them in the standard date format for Canada
using System;
using System.Globalization;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string text = "This is an example with some dates. The program will recognize this date 30.11.978 and will not recognize this 32.01.2011. One more valid date is 01.03.2010 and invalid 03.13.2010";
        Regex regexFindDate = new Regex(@"((([0][1-9])|[1-2][0-9])|([3][0-1]))\.(([0][1-9])|([1][0-2]))\.[0-9]{1,4}");

        MatchCollection dates = regexFindDate.Matches(text);
        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");

        foreach (var match in dates)
        {
            Console.WriteLine(match);
        }


    }
}
