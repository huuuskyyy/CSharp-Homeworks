using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    //the code here is pretty straight forward and straight explanatory
    //discipline class inherits NonPerson class, so discipline has name and comment although there are not fields and properties for this
    public class Discipline : NonPerson
    {
        private int lecturesCount;
        private int exercisesCount;

        public Discipline(string name, int lecturesCount, int exercisesCount, string comment)
        {
            this.Name = name;
            this.lecturesCount = lecturesCount;
            this.exercisesCount = exercisesCount;
            this.Comment = comment;
        }

        public Discipline(string name, int lecturesCount, int exercisesCount)
            : this(name, lecturesCount, exercisesCount, null)
        {
            this.Name = name;
            this.lecturesCount = lecturesCount;
            this.exercisesCount = exercisesCount;

        }

        public int LecturesCount
        {
            get { return this.lecturesCount; }
            set { this.lecturesCount = value; }
        }

        public int ExercisesCount
        {
            get { return this.exercisesCount; }
            set { this.exercisesCount = value; }
        }
    }

}
