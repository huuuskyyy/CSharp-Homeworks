//Write a program that reads two dates in the format: day.month.year and calculates the number of days between them
using System;
using System.Globalization;

class DaysBetweenDates
{
    static void Main()
    {
        string firstDate = "01.04.2013";
        string secondDate = "01.06.2013";

        DateTime firstParsed = DateTime.ParseExact(firstDate, "d.MM.yyyy", CultureInfo.InvariantCulture);
        DateTime secondParsed = DateTime.ParseExact(secondDate, "d.MM.yyyy", CultureInfo.InvariantCulture);
        int difference = (int)((firstParsed - secondParsed).TotalDays);

        if (difference < 0)
        {
            difference *= -1;
        }

        Console.WriteLine(difference + " days");
    }
}
