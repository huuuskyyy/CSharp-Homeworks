using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frames
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = 3;
            string[] array = new string[limit];
            int[] positions = new int[limit];
            Frame[] frames = new Frame[] { new Frame(2, 2), new Frame(2, 3), new Frame(2, 3) };

            //for (int i = 0; i < frames.Length; i++)
            //{
            //    array[i] = frames[i].ToString();
            //}

            Dictionary<int, bool> used = new Dictionary<int, bool>();
            //int start = 0;
            int position = 0;

            Loop(frames, position, used, array);
            
          
        }

        private static void Loop(Frame[] frames, int position, Dictionary<int, bool> used, string[] array)
        {
           if(position == frames.Length)
           {
               Console.WriteLine(string.Join(" ", array));
               return;
           }

           int addedPosition = 0;

           for (int i = 0; i < frames.Length; i++)
           {
               Console.WriteLine(" Position "+position+" || i index => "+i);
               if(!used.ContainsKey(i))
               {
                   Console.WriteLine("Doesn't contain key " + i);
                   array[position] = frames[i].ToString();
                   used.Add(i, true);
                   addedPosition = i;
                   Loop(frames, position++, used, array);
                   i--;
               }
               else
               {
                   Console.WriteLine("Contains key " + i);
                   if(position == i)
                   {
                       Frame currentFrame = frames[i];

                       if(currentFrame.Height != currentFrame.Width)
                       {
                           array[position] = "(" + currentFrame.Width + " " + currentFrame.Height + ")";
                           Loop(frames, position++, used, array);
                       }
                   }
               }
           }

           used.Remove(addedPosition);
        }


        public class Frame : IComparable
        {
            private int height;
            private int width;

            public Frame(int height, int width)
            {
                this.height = height;
                this.width = width;
            }

            public int Height
            {
                get
                {
                    return this.height;
                }
                set
                {
                    this.height = value;
                }
            }

            public int Width
            {
                get
                {
                    return this.width;
                }
                set
                {
                    this.width = value;
                }
            }

            public override string ToString()
            {
                return "(" + this.height + " " + this.width + ")";
            }

            public int CompareTo(object obj)
            {
                //obj = obj as Frame;

                if (this.Height.CompareTo((obj as Frame).Height) > 0)
                {
                    //Console.WriteLine("Return 1: First frame => height " + this.height + " width " + this.width + " Second frame => height " + (obj as Frame).Height + " width " + (obj as Frame).Width);
                    return 1;
                }
                else if (this.Height.CompareTo((obj as Frame).Height) < 0)
                {
                    //Console.WriteLine("Return -1: First frame => height " + this.height + " width " + this.width + " Second frame => height " + (obj as Frame).Height + " width " + (obj as Frame).Width);
                    return -1;
                }
                else
                {
                    //Console.WriteLine("Return {0}: First frame => height " + this.height + " width " + this.width + " Second frame => height " + (obj as Frame).Height + " width " + (obj as Frame).Width, this.Width.CompareTo((obj as Frame).Width));
                    return this.Width.CompareTo((obj as Frame).Width);
                }
            }
        }
    }
}
