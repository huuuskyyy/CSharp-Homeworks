using System;

namespace Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age)
            : base(name, age)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = "Male";
        }

        public Tomcat(string name)
            : this(name, 0)
        {
            this.Name = name;
            this.Sex = "Male";
        }

        public override void Sound()
        {
            Console.WriteLine("Muhahahaha");
        }
    }
}
