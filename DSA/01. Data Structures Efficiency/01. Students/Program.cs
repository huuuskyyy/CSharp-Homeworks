using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Students
{
    class Program
    {
        static void Main()
        {
            string path = "@../../students.txt";
            StreamReader reader = new StreamReader(path);
            SortedDictionary<string, OrderedBag<string>> courses = new SortedDictionary<string, OrderedBag<string>>();

            using(reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] info = line.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                    string course = info[2];
                    string studentName = info[1] + " " + info[0];

                    if (courses.ContainsKey(course))
                    {
                        courses[course].Add(studentName);
                    }
                    else
                    {
                        courses.Add(course, new OrderedBag<string>());
                        courses[course].Add(studentName);
                    }

                    line = reader.ReadLine();
                }
            }

            foreach(var course in courses)
            {
                Console.Write(course.Key + ": ");

                foreach(var student in course.Value)
                {
                    Console.Write(student + ", ");
                }

                Console.WriteLine();
            }
        }
    }
}
