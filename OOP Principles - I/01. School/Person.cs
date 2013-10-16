using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    //basic class for all human objects
    //although it is the same as NonPerson class they are both separeted if any other extra functionalties need to be addded
    public class Person
    {
        private string name;
        private string comment;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }
    }

}
