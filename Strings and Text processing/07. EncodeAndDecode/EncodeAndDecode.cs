//Write a program that encodes and decodes a string using given encryption key (cipher). The key consists of a sequence of characters. 
//The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key,
//the second – with the second, etc. When the last key character is reached, the next is the first
using System;
using System.Collections.Generic;
using System.Text;

class EncodeAndDecode
{
    static void Main()
    {
        string text = "We are living in an yellow submarine. We don't have anything else. ";
        string key = "This is encryption key";

        string encodedResult = Encode(text, key);
        string decodedResult = Decode(encodedResult, key);

        Console.WriteLine(encodedResult);
        Console.WriteLine(decodedResult);

    }

    static string Encode(string input, string encriptionKey)
    {
        char[] inputToChars = input.ToCharArray();
        char[] encriptionKeyToChars = encriptionKey.ToCharArray();
        List<char> encriptedText = new List<char>();

        for (int i = 0, j = 0; i < inputToChars.Length; i++, j++)
        {
            if (j == encriptionKeyToChars.Length)
            {
                j = 0;
            }
            encriptedText.Add((char)(inputToChars[i] ^ encriptionKeyToChars[j]));
        }

        StringBuilder result = new StringBuilder();

        foreach (char c in encriptedText)
        {
            result.Append(c);
        }

        return result.ToString();
    }

    static string Decode(string input, string encriptionKey)
    {
        string result = Encode(input, encriptionKey);
        return result;
    }
}
