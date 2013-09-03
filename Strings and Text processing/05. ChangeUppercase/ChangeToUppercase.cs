//You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. 
//The tags cannot be nested
using System;
using System.Text;

class Uppercase
{
    static void Main()
    {
        string initial = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        StringBuilder text = new StringBuilder();
        foreach (char c in initial)
        {
            text.Append(c);
        }
        string start = "<upcase>";
        string end = "</upcase>";
        int index = initial.IndexOf(start);

        int startPos = index;
        int endPos = 0;

        while (startPos != -1)
        {
            StringBuilder temp = new StringBuilder();
            endPos = initial.IndexOf(end, startPos);
            temp.Append(initial, startPos, endPos - startPos);
            StringBuilder lowercase = new StringBuilder();
            for (int i = 0; i < temp.Length; i++)
            {
                lowercase.Append(temp[i]);
            }

            for (int i = 0; i < temp.Length; i++)
            {
                char ch = '\0';
                ch = Char.ToUpper(temp[i]);
                temp.Replace(temp[i], ch, i, 1);
            }

            text.Replace(lowercase.ToString(), temp.ToString(), startPos, endPos - startPos);

            startPos = initial.IndexOf(start, endPos);

        }
        text.Replace(start.ToUpper(), "", 0, text.Length);
        text.Replace(end, "", 0, text.Length);
        Console.WriteLine(text);
    }
}
