using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HashTable;

namespace HashSet
{
    class Program
    {
        static void Main()
        {
            HashSet<string> testTable = new HashSet<string>();

            testTable.Add("stoicho");
            testTable.Add("peicho");
            testTable.Add("koicho");
            testTable.Add("koicho");
            testTable.Add("koicho");
            testTable.Add("nacho");
            testTable.Add("bochko");
            testTable.Add("zuza");
            testTable.Add("ko");

            //foreach (var key in testTable)
            //{
            //    Console.WriteLine(key);

            //}

            HashSet<string> testTable2 = new HashSet<string>();
            testTable2.Add("gosho");
             testTable2.Add("stoicho");
            testTable2.Add("peicho");
            testTable2.Add("koicho");
             testTable2.Add("asen");
            testTable2.Add("peicho");
            testTable2.Add("toshkata");

            //testTable.Union(testTable2);

            var testTable3 = testTable.Intersect(testTable2);

            foreach (var key in testTable3)
            {
                Console.WriteLine(key);

            }

        }
    }
}
