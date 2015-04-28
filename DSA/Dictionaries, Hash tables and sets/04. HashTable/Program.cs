using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashTable
{
    class Program
    {
        static void Main()
        {
            HashTable<string, int> testTable = new HashTable<string, int>();

            testTable.Add("stoicho", 14);
            testTable.Add("peicho", 6);
            testTable.Add("koicho", 4);
            testTable.Add("koicho", 114);
            testTable.Add("koicho", 41);
            testTable.Add("nacho", 4111);
            testTable.Add("bochko", 341);
            testTable.Add("zuza", 341);
            testTable.Add("ko", 341);

            foreach (var key in testTable.Keys())
            {
                Console.WriteLine(key);

            }

            var third = testTable[2];

            Console.WriteLine("====================");

            foreach (var pair in third)
            {
                Console.WriteLine(pair.Key + " " + pair.Value);
            }

            Console.WriteLine("====================");
            // Console.WriteLine(testTable.Keys()[3]);

            //Console.WriteLine("Capacity " + testTable.Capacity + " Count " + testTable.Count);
            //testTable.Remove("koicho");
            //Console.WriteLine(testTable.Find("koicho"));
            //testTable.Clear();
            // Console.WriteLine(testTable.Find("peicho")); 
        }
    }
}
