//A dictionary is stored as a sequence of text lines containing words and their explanations. 
//Write a program that enters a word and translates it by using the dictionary
using System;

class Dictionary
{
    static void Main()
    {

        string[] dictionary = new string[3] { ".NET - platform for applications from Microsoft",
                                            "CLR - managed execution environment for .NET",
                                            "NAMESPACE - hierarchical organization of classes"
                                          };

        string word = "clr";
        bool isFound = false;

        foreach (string s in dictionary)
        {
            int position = s.IndexOf(word.ToUpper());
            if (position == 0)
            {
                Console.WriteLine(s+"\n");
                isFound = true;
            }
        }

        if (!isFound)
        {
            Console.WriteLine("Word not found");
        }

    }
}
