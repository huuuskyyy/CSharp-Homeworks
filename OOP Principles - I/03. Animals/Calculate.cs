using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public static class Calculate
    {
        //calculate the avarage age of each animal group and print it on the screen
        public static void AverageAge(List<ISound> list)
        {
            //first sort the animals into groups by their kind
            //and then calculate the average age
            var temp =
                from animals in list
                group animals by animals.GetType().Name into groups
                select new
                {
                    AnimalKind = groups.Key,
                    AverageAge = groups.Average(animals => animals.Age)
                };

            Console.WriteLine();

            foreach (var item in temp)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
    }

}
