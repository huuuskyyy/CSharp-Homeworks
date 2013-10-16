using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    //the code here is pretty self-explanatory
    public class School : NonPerson
    {
        private List<Class> classes = new List<Class>();

        public School(string name, string comment)
        {
            this.Name = name;
            this.Comment = comment;
        }

        public School(string name)
            : this(name, null)
        {
            this.Name = name;
        }

        public List<Class> Classes
        {
            get { return this.classes; }
        }

        public void AddClass(Class temp)
        {
            classes.Add(temp);
        }

        public void AddGroupClasses(List<Class> temp)
        {
            foreach (var item in temp)
            {
                classes.Add(item);
            }
        }
    }

}
