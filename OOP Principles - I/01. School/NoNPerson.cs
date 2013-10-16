using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    //our basic class for all non human objects
    //it will give name and comment to all non human classes
    public class NonPerson
    {
        private string comment;
        private string name;

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
