using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_number_occurence
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            var sortedDictoionary = array.GroupBy(number => number).ToDictionary(group => group.Key, group => group.Count());

            foreach(var pair in sortedDictoionary)
            {
                Console.WriteLine("Number "+pair.Key+" occurs "+pair.Value+" times");
            }
        }
    }
}
