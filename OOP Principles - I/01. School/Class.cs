using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    //the class object
    //inherits NonPerson class which has name and comment
    public class Class : NonPerson
    {
        //a class will hold list of students and teachers
        private List<Student> students = new List<Student>();
        private List<Teacher> teachers = new List<Teacher>();

        //constructors
        public Class(string name, string comment)
        {
            this.Name = name;
            this.Comment = comment;
        }

        public Class(string name)
            : this(name, null)
        {
            this.Name = name;
        }

        //this will return the list of the students
        public List<Student> Students
        {
            get { return this.students; }
        }

        //add single student to a class
        public void AddStudent(Student student)
        {
            this.students.Add(student);
        }

        //add a list of students to the class
        public void AddGroupStudents(List<Student> temp)
        {
            foreach (var i in temp)
            {
                students.Add(i);
            }
        }

        //gives us all teachers in the class
        public List<Teacher> Teachers
        {
            get { return this.teachers; }
        }

        //add a single teacher
        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }

        //add list of teachers to the class
        public void AddGroupTeachers(List<Teacher> temp)
        {
            foreach (var i in temp)
            {
                teachers.Add(i);
            }
        }
    }

}
