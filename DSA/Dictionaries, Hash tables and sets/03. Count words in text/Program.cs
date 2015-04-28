using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_words_in_text
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("@../../text.txt");
            string text;
            char[] separators = {' ', '.', '!', '?', ',', '-', '\r', '\n' };

            using(reader)
            {
                text = reader.ReadToEnd();
                string[] wordsInText = text.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                var countedWords = wordsInText.GroupBy(words => words).ToDictionary(word => word.Key, word => word.Count()).OrderByDescending(occurence => occurence.Value);

                foreach (var item in countedWords)
                {
                    Console.WriteLine(item.Key+" => "+item.Value);
                }
            }

            
        }
    }
}
