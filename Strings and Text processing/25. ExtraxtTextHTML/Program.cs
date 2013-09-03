//Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags
using System;
using System.Text;

class FindTextInHTML
{
    static void Main(string[] args)
    {
        string text = "<html><head><title>News</title></head><body><p><a href=\"http://academy.telerik.com\">TelerikAcademy</a>aims to provide free real-world practicaltraining for young people who want to turn intoskillful .NET software engineers.</p></body></html>";
        StringBuilder result = new StringBuilder();
        int index = text.IndexOf('>');

        while (index != text.Length - 1)
        {

            if (text[index + 1] != '<')
            {
                while (text[index + 1] != '<')
                {
                    result.Append(text[index + 1]);
                    index++;
                }
            }
            result.Append(" ");

            index = text.IndexOf('>', index + 1);
        }

        Console.WriteLine(result.ToString());
    }
}
