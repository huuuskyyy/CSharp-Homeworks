using System;

namespace Animals
{
    public interface ISound
    {
        string Name { get; set; }
        int Age { get; set; }
        string Sex { get; set; }

        void Sound();
    }
}
