using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_odd_occurences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            var sortedDictoionary = array.GroupBy(number => number).ToDictionary(group => group.Key, group => group.Count()).Where(item => item.Value % 2 != 0); ;
            var oddOccurenceWords = sortedDictoionary.Select(item => item.Key).ToArray();

            Console.WriteLine(string.Join(", ",oddOccurenceWords));
            
        }
    }
}
