using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    //this class is created just for test purposes
   public static class CreateTest
    {
       //a method for creating a new test school with predifined details
       //only the students are random picked ->check CreatArray method in Student class
        public static School New()
        {
            //create two student list with random details
            List<Student> exampleStudents1 = Student.CreateArray(10);
            List<Student> exampleStudents2 = Student.CreateArray(10);

            //create several disciplines with their names, lecture hours and exercies hours
            Discipline chemistry = new Discipline("Chemistry", 3, 3);
            Discipline history = new Discipline("History", 2, 2);
            Discipline mathematics = new Discipline("Mathematics", 4, 4);
            Discipline sport = new Discipline("Sport", 5, 5);

            //create list of disciplines for one of the teachers
            List<Discipline> exampleTeacher1Disciplines = new List<Discipline>();
            exampleTeacher1Disciplines.Add(chemistry);
            exampleTeacher1Disciplines.Add(mathematics);

            //create list of disciplines for the other teacher
            List<Discipline> exampleTeacher2Disciplines = new List<Discipline>();
            exampleTeacher2Disciplines.Add(history);
            exampleTeacher2Disciplines.Add(sport);

            //create two teachers and assign one list of disciplines to each of them
            Teacher exampleTeacher1 = new Teacher("Blagoy Stankov", exampleTeacher1Disciplines);
            Teacher exampleTeacher2 = new Teacher("Todor Trendafilov", exampleTeacher2Disciplines);

            //create a new class and add students and teacher to the class
            Class a12 = new Class("12a");
            a12.AddGroupStudents(exampleStudents1);
            a12.AddTeacher(exampleTeacher1);

            //create another class and add students and teacher to the class
            Class b12 = new Class("12b");
            b12.AddGroupStudents(exampleStudents2);
            b12.AddTeacher(exampleTeacher2);

            //create a new school
            School exampleSchool = new School("SOU Petko Rachov Slaveikov");

            //assign both classes to the school
            exampleSchool.AddClass(a12);
            exampleSchool.AddClass(b12);

            return exampleSchool;
        }

       //this method will display all the school info from a given scholl(without the comments)
        public static void DisplayTest(School temp)
        {

            Console.WriteLine("\nSchool name: " + temp.Name);

            Console.WriteLine("\nClasses:\n");

            foreach(Class classInSchool in temp.Classes)
               {
                   Console.WriteLine(classInSchool.Name);
                   Console.WriteLine();
                   Student.DisplayStudents(classInSchool.Students);
                   Console.WriteLine("\nTeachers : \n");

                   foreach (Teacher teacher in classInSchool.Teachers)
                   {
                       Console.Write(teacher.Name);
                       Console.WriteLine();

                       foreach (Discipline discipline in teacher.Disciplines)
                       {
                           Console.Write("\n"+discipline.Name + " " + discipline.LecturesCount + " hours lectures and " + discipline.ExercisesCount + " hours exercises");
                       }
                       Console.WriteLine();
                   }

                   Console.WriteLine();
               }

        }
    }
}
