//Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods.
//Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface). 
//Kittens and tomcats are cats. All animals are described by age, name and sex. Kittens can be only female and tomcats can be only male. 
//Each animal produces a specific sound. Create arrays of different kinds of animals and calculate 
//the average age of each kind of animal using a static method (you may use LINQ).


using System;
using System.Collections.Generic;

namespace Animals
{
    class Program
    {
        static void Main()
        {
            //list of all kinds of animals, which will be group and sorted
            List<ISound> animals = new List<ISound>()
            { 
                new Cat("Choko", 10), new Frog("Milko", 1, "Male"),
                 new Kitten("Bochka", 2), new Kitten("Chochka", 3), 
                new Frog("Boko", 4), new Cat("Stoyan", 19, "Male"),
                new Dog("Sharo", 22), new Dog("Balkan", 18, "Male"),
                new Tomcat("Tom", 11), new Tomcat("Garfield", 25)
            };

            Calculate.AverageAge(animals);
        }
    }
}
