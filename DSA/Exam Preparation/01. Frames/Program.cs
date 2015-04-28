using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frames
{
    class Program
    {
        static void Main()
        {
            int limit = 3;
            string[] array = new string[limit];
            int[] positions = new int[limit];
            Frame[] frames = new Frame[] { new Frame(2, 2), new Frame(2, 3), new Frame(2, 3) };

            for (int i = 0; i < frames.Length; i++)
            {
                array[i] = frames[i].ToString();
            }
           // HashSet<Frame> used = new HashSet<Frame>();
            int start = 0;
            Loop(frames.Length, frames, start);

            for (int i = frames.Length-1; i >= 0; i--)
            {
                if(frames[i].Width != frames[i].Height)
                {
                    int temp = frames[i].Width;
                    frames[i].Width = frames[i].Height;
                    frames[i].Height = temp;
                    Loop(frames.Length, frames, start);
                }
            }
            

        }

        private static void Loop(int index, Frame[] array, int start)
        {
            //Console.WriteLine(string.Join(" ", array));

            foreach (var frame in array)
            {
                Console.Write(frame.ToString()+" ");
            }

            Console.WriteLine();

            Frame tmp = null;

            if (start < index)
            {
                for (int i = index - 2; i >= start; i--)
                {
                    for (int j = i + 1; j < index; j++)
                    {
                        if (array[i].CompareTo(array[j]) != 0)
                        {
                            // swap array[i] <--> array[j]
                            tmp = array[i];
                            array[i] = array[j];
                            array[j] = tmp;

                            Loop(index, array, i + 1);
                        }
                    }

                    tmp = array[i];
                    for (int k = i; k < index - 1; )
                    {
                        array[k] = array[++k];
                        array[index - 1] = tmp;
                    }
                }

            }
        }

        //public static void Loop(int index, string[] array, Frame[] frames, int[] positions, HashSet<Frame> used)
        //{
        //    if (index >= array.Length)
        //    {
        //        Console.WriteLine(string.Join(" ", array));
        //    }
        //    else
        //    {
        //        for (int i = 1; i <= array.Length; i++)
        //        {
        //            bool isExist = false;

        //            for (int j = 0; j < array.Length; j++)
        //            {
        //                if (positions[j] == i)
        //                {
        //                    isExist = true;
        //                    break;
        //                }
        //            }
        //            if (!isExist)
        //            {
        //                if(used.Contains(frames[i-1]))
        //                {
        //                    return;
        //                }

        //                positions[index] = i;
        //                array[index] = frames[i-1].ToString();
        //                used.Add(frames[i - 1]);
        //                Loop(index + 1, array, frames, positions,used);

        //                if (index + 1 != array.Length)
        //                {
        //                    positions[index + 1] = 0;
        //                    array[index + 1] = frames[0].ToString();
        //                }
        //            }
        //        }
        //    }
        //}

        //private static void Loop(int index, int[] array, int start, Frame[] frames, string[] result)
        //{
        //    Console.WriteLine(string.Join(" ", result));

        //    Frame tmp = null;

        //    if (start < index)
        //    {
        //        for (int i = index - 2; i >= start; i--)
        //        {
        //            for (int j = i + 1; j < index; j++)
        //            {
        //                if (frames[i] != frames[j])
        //                {
        //                    // swap array[i] <--> array[j]
        //                    tmp = frames[i];
        //                    frames[i] = frames[j];
        //                    frames[j] = tmp;
        //                    result[i] = frames[i].ToString();
        //                    result[j] = frames[j].ToString();

        //                    Loop(index, array, i + 1, frames, result);
        //                }
        //            }

        //            tmp = frames[i];
        //            for (int k = i; k < index - 1; )
        //            {
        //                frames[k] = frames[++k];
        //                frames[index - 1] = tmp;
        //                result[k] = frames[k].ToString();
        //                result[index - 1] = frames[index - 1].ToString();
        //            }
        //        }

        //    }
        //}
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
                return "("+this.height + " " + this.width+")";
            }

            public int CompareTo(object obj)
            {
                //obj = obj as Frame;

                if(this.Height.CompareTo((obj as Frame).Height) > 0)
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
