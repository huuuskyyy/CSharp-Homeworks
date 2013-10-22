using System;

namespace Animals
{
    public class Frog : Animal
    {
        public Frog(string name, int age, string sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public Frog(string name, int age)
            : this(name, age, null)
        {
            this.Name = name;
            this.Age = age;
        }

        public Frog(string name)
            : this(name, 0, null)
        {
            this.Name = name;
        }

        public override void Sound()
        {
            Console.WriteLine("Kva-kva");
        }
    }
}
