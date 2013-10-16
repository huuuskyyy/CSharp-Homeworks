using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Teacher : Person
    {
        private List<Discipline> disciplines = new List<Discipline>();

        public Teacher(string name, List<Discipline> disciplines, string comment)
        {
            this.Name = name;
            this.disciplines = disciplines;
            this.Comment = comment;
        }

        public Teacher(string name, List<Discipline> disciplines)
            : this(name, disciplines, null)
        {
            this.Name = name;
            this.disciplines = disciplines;
        }

        public Teacher(string name)
            : this(name, null, null)
        {
            this.Name = name;
        }

        public List<Discipline> Disciplines
        {
            get { return this.disciplines; }
   
        }

        public void AddDiscipline(Discipline discipline)
        {
            this.disciplines.Add(discipline);
        }
    }

}
