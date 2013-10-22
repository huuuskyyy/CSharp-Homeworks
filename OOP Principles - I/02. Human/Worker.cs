using System;
using System.Collections.Generic;
using System.Linq;

namespace Human
{
    class Worker : Human
    {
        public double WeeklySalary { get; private set; }
        public double WorkHoursPerDay { get; private set; }

        public Worker(string firstName, string lastName, double weeklySalary, double workHoursPerDay)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.WeeklySalary = weeklySalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public Worker(string firstName, string lastName, double weeklySalary)
            : this(firstName, lastName, weeklySalary, 0d)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.WeeklySalary = weeklySalary;
        }

        public Worker(string firstName, string lastName)
            : this(firstName, lastName, 0d, 0d)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public double MoneyPerHourEarnt
        {
            get { return this.MoneyPerHour(); }

        }

        public double MoneyPerHour()
        {
            if (WeeklySalary == 0 || WorkHoursPerDay == 0)
            {
                throw new ArgumentException("Error in calculation! Weekly salary or work hours per day cannot be equal to zero !");
            }
            return Math.Round((this.WeeklySalary / (this.WorkHoursPerDay * 5)), 2);
        }

        //create list of count number workers with random details like in the student class
        public static List<Worker> CreateList(int count)
        {

            List<Worker> workersArray = new List<Worker>();
            string[] firstNames = new string[] { "Ivan", "Georgi", "Stoyan", "Pavel", "Asen", "Nikolai", "Lyubomir", "Atanas", "Petar", "Martin", "Vasil" };
            string[] lastNames = new string[] { "Ivanov", "Georgiev", "Stoyanov", "Pavlov", "Asenov", "Nikolaev", "Lyubomirov", "Atanasov", "Petrov", "Martinov", "Vasilev" };
            Random generator = new Random();

            for (int i = 0; i < count; i++)
            {
                string nameFirst = firstNames[generator.Next(0, firstNames.Length)];
                string nameLast = lastNames[generator.Next(0, lastNames.Length)];
                double weeklySalary = generator.Next(100, 500);
                double hoursPerDay = generator.Next(6,13);
                Worker temp = new Worker(nameFirst, nameLast, weeklySalary, hoursPerDay);


                workersArray.Add(temp);
            }

            return workersArray;
        }

        //sort a list of workers by earnt money per hour in descenind order using LINQ
        public static void SortMoneyPerHour(List<Worker> workers)
        {
            var sorted =
                from worker in workers
                orderby worker.MoneyPerHourEarnt descending
                select worker;

            int counter = 0;

            //override the given list with the new results
            foreach (var item in sorted)
            {
                workers[counter] = item;
                counter++;
            }
        }

        public override string ToString()
        {
            string temp = this.FirstName + " " + this.LastName + " Money earnt per hour: " + this.MoneyPerHourEarnt;
            return temp;
        }
    }
 }

