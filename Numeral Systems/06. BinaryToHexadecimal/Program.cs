//Write a program to convert binary numbers to hexadecimal numbers (directly)

using System;
using System.Collections.Generic;

class ConverToHexadecimal
{
    static void Main()
    {
        string str = "100101";
        char[] arr = str.ToCharArray();
        List<char> charList = new List<char>();
        foreach (char c in arr)
        {
            charList.Add(c);
        }

        while (charList.Count % 4 != 0)
        {
            charList.Add('0');
        }

        string temp = "";

        string result = "";

        for (int i = 0; i < charList.Count / 4; i++)
        {
            for (int j = i * 4; j < j + 4; j++)
            {
                temp += charList[i];
            }
            switch (temp)
            {
                case "0000": result += "0"; break;
                case "0001": result += "1"; break;
                case "0010": result += "2"; break;
                case "0011": result += "3"; break;
                case "0100": result += "4"; break;
                case "0101": result += "5"; break;
                case "0110": result += "6"; break;
                case "0111": result += "7"; break;
                case "1000": result += "8"; break;
                case "1001": result += "9"; break;
                case "1010": result += "A"; break;
                case "1011": result += "B"; break;
                case "1100": result += "C"; break;
                case "1101": result += "D"; break;
                case "1110": result += "E"; break;
                case "1111": result += "F"; break;
                default: result += ""; break;
            }
            temp = "";
        }

        Console.WriteLine(result);
    }

}
