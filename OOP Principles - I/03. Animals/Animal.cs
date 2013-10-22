using System;

namespace Animals
{
    //the base class, which all animals will inherit
    public abstract class Animal : ISound
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }

        public abstract void Sound();
    }

}
