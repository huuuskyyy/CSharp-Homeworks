using System;


namespace Version
{
    ////ensure that this attribute can be applied to structures, classes, interfaces, enumerations and methods
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Enum |
                AttributeTargets.Interface | AttributeTargets.Method, AllowMultiple = false)]

    //the class must inherir System:Attribute in order to be recognized as an attribute
    public class VersionAttribute : System.Attribute
    {
        private int major;
        private int minor;

        //version constructor with two ints 
        public VersionAttribute(int major, int minor)
        {
            this.major = major;
            this.minor = minor;
        }

        public int Major
        {
            get { return this.major; }
            set { this.major = value; }
        }
        public int Minor
        {
            get { return this.minor; }
            set { this.minor = value; }
        }

        public override string ToString()
        {
            return this.Major + "." + this.Minor;
        }
    }

}
