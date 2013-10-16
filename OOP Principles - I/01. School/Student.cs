using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Student : Person
    {
        //unique class number
        private string ucn;

        public Student(string name, string ucn, string comment)
        {
            this.Comment = comment;
            this.Name = name;
            this.ucn = ucn;
        }

        public Student(string name, string ucn)
            : this(name, ucn, null)
        {
            this.Name = name;
            this.ucn = ucn;
        }

        public Student(string name)
            : this(name, null, null)
        {
            this.Name = name;
        }

        public string Ucn
        {
            get { return this.ucn; }
            set { this.ucn = value; }
        }

        //this method creates list of count number students with random details
    public static List<Student> CreateArray(int count)
    {
        
        List<Student> studentsArray = new List<Student>();
        string[] firstNames = new string[] {"Ivan", "Georgi", "Stoyan", "Pavel", "Asen", "Nikolai", "Lyubomir", "Atanas", "Petar", "Martin","Vasil"}; 
        string[] lastNames = new string[]{"Ivanov", "Georgiev" ,"Stoyanov", "Pavlov", "Asenov", "Nikolaev", "Lyubomirov", "Atanasov", "Petrov", "Martinov", "Vasilev"};
        Random namesGenerator = new Random();
        
        for(int i = 0; i < count; i++)
        {
            string name = firstNames[namesGenerator.Next(0,firstNames.Length)];
            name+=" ";
            name += lastNames[namesGenerator.Next(0, lastNames.Length)];
            string ucn = namesGenerator.Next(10000, 1000000).ToString();
            Student temp = new Student(name, ucn);
            
            studentsArray.Add(temp);
        }
        
        return studentsArray;
    }

        //display all the info from given list of students
    public static void DisplayStudents(List<Student> arr)
     {
        Console.WriteLine("The list of students :\n");

        foreach (var student in arr)
        {
            Console.Write(student.Name);

            if (student.Ucn != null)
            {
                Console.Write(" Unique student number: " + student.Ucn + "\n");
            }
            if (student.Comment != null)
            {
                Console.WriteLine(student.Comment + "\n");
            }
        }
     }

    }

}
