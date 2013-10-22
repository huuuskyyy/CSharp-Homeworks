using System;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, string sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public Dog(string name, int age)
            : this(name, age, null)
        {
            this.Name = name;
            this.Age = age;
        }

        public Dog(string name)
            : this(name, 0, null)
        {
            this.Name = name;
        }

        public override void Sound()
        {
            Console.WriteLine("Bau");
        }
    }
}
