﻿using System;

namespace Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age)
            : base(name, age)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = "Female";
        }

        public Kitten(string name)
            : this(name, 0)
        {
            this.Name = name;
            this.Sex = "Female";
        }

        public override void Sound()
        {
            Console.WriteLine("Myauuuuuuu");
        }
    }
}
