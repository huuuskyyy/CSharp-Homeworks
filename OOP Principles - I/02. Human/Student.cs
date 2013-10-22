using System;
using System.Collections.Generic;
using System.Linq;

namespace Human
{
    class Student : Human
    {
        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        public Student(string firstName, string lastName)
            : this(firstName, lastName, 0d)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public double Grade { get; private set; }

        //this method will generate list of count number students with random names and grades
        public static List<Student> CreateList(int count)
        {

            List<Student> studentsArray = new List<Student>();
            //two predifined arrats with first and last names from which the random generator will pick values
            string[] firstNames = new string[] { "Ivan", "Georgi", "Stoyan", "Pavel", "Asen", "Nikolai", "Lyubomir", "Atanas", "Petar", "Martin", "Vasil" };
            string[] lastNames = new string[] { "Ivanov", "Georgiev", "Stoyanov", "Pavlov", "Asenov", "Nikolaev", "Lyubomirov", "Atanasov", "Petrov", "Martinov", "Vasilev" };
            Random generator = new Random();

            for (int i = 0; i < count; i++)
            {
                string nameFirst = firstNames[generator.Next(0, firstNames.Length)];
                string nameLast = lastNames[generator.Next(0, lastNames.Length)];

                //a formula I found on the interent for returning double numbers within certain range
                //in our case between 2 and 6
                double grade = Math.Round((generator.NextDouble() * 4 + 2), 2);
                Student temp = new Student(nameFirst, nameLast, grade);

                studentsArray.Add(temp);
            }

            return studentsArray;
        }

        //this method will sort students from a list by thier grades in ascending order using LINQ
        public static void SortGrade(List<Student> students)
        {
            var sorted =
                from student in students
                orderby student.Grade
                select student;

            int counter = 0;

            // //override the given list with the new results
            foreach (var item in sorted)
            {
                students[counter] = item;
                counter++;
            }
        }

        public override string ToString()
        {
            string temp = this.FirstName + " " + this.LastName + " Grade: " + this.Grade;
            return temp;
        }
    }
}
