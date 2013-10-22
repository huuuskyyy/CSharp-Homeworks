using System;
using System.Collections;

namespace Human
{
    //the base class for both students and workers

    public abstract class Human : IPerson
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
    }
}
