//Write a program that reads a date and time given in the format: day.month.year hour:minute:second and prints the date and time after 6 hours and 30 minutes
//(in the same format) along with the day of week in Bulgarian
using System;
using System.Globalization;

class AddHours
{
    static void Main()
    {
        Console.WriteLine("Enter a date in the format day.month.year hour:minutes:second. Example 01.01.2001 10:10:10");
        string str = Console.ReadLine();
        DateTime date = DateTime.Parse(str);
        date = date.AddHours(6.5);
        Console.OutputEncoding = System.Text.Encoding.Unicode;

        Console.WriteLine(" The time after 6 hours and 30 minutes added to the entered date will be {0} {1}", date.ToString("dddd", new CultureInfo("bg-BG")), date);

    }
}
