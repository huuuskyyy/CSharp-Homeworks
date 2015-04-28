using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalEmployees = int.Parse(Console.ReadLine());
            Dictionary<int, long> salaries = new Dictionary<int, long>();
            Dictionary<int, List<int>> links = new Dictionary<int, List<int>>();
            long totalSalaries = 0;

            for (int i = 0; i < totalEmployees; i++)
            {
                string currentLinks = Console.ReadLine().Trim();

                if(String.IsNullOrEmpty(currentLinks))
                {
                    i--;
                    continue;
                }

                int currentId = i;
                salaries.Add(currentId, 0);
                links.Add(currentId, new List<int>());
                
               
                int employerIndex = currentLinks.IndexOf('Y');

                while(employerIndex != -1)
                {
                    links[currentId].Add(employerIndex);
                    employerIndex = currentLinks.IndexOf('Y', employerIndex + 1);
                }
            }

            foreach (var employee in links)
            {
                totalSalaries += GetSalary(employee.Key, links, salaries);
            }

            Console.WriteLine(totalSalaries);

        }

        private static long GetSalary(int id, Dictionary<int, List<int>> links, Dictionary<int, long> salaries)
        {
            if(salaries[id] == 0)
            {
                if (links[id].Count == 0)
                {
                    salaries[id] = 1;
                }
                else
                {
                    foreach (var employee in links[id])
                    {
                        salaries[id] += GetSalary(employee, links, salaries);
                    }
                }
            }

            return salaries[id];
        }
    }
}
