//Define abstract class Human with first name and last name. Define new class Student which is derived from Human and has new field – grade.
//Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay and method MoneyPerHour() that returns
//money earned by hour by the worker. Define the proper constructors and properties for this hierarchy. Initialize a list of 10 students
//and sort them by grade in ascending order (use LINQ or OrderBy() extension method). Initialize a list of 10 workers and sort them
//by money per hour in descending order. Merge the lists and sort them by first name and last name.

using System;
using System.Collections.Generic;

namespace Human
{
    //this is the class where I tested my code
    class Program
    {
        static void Main()
        {
            //create 10 workers and 10 students
            List<Worker> exampleWorkers = Worker.CreateList(10);
            List<Student> exampleStudents = Student.CreateList(10);

            //sort them by grade and money earnt per hour
            Student.SortGrade(exampleStudents);
            Worker.SortMoneyPerHour(exampleWorkers);

            foreach (Student student in exampleStudents)
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine();

            foreach (Worker worker in exampleWorkers)
            {
                Console.WriteLine(worker.ToString());
            }
        }
    }

}
