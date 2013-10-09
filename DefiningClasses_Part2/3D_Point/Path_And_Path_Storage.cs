using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace _3D_Point
{
    //this class stores a sequence of 3d points as path
    //the class inherits IEnumerator and IEnumerable, so an object from this class can display its content using foreach loop
    public class Path : IEnumerator, IEnumerable
    {
        //this list will contains different 3d points and will form the path object
        private List<Point3D> path = new List<Point3D>();

        //we position in order to use foreach
        private int position = 0;

        //this will hold the length of the path(how many points the path countains)
        private int length;

        //path constructor
        public Path()
        {

        }

        //the returns all points as separate elements
        //can be used for printing each point from the path
        public List<Point3D> Elements
        {
            get { return this.path; }
        }

        //add points to the path
        public void Add(Point3D point)
        {
            this.path.Add(point);
        }

        //length of the path
        public int Length 
        {
            get { return this.length; }
            set { this.length = path.Count+1; }
        }

        //all this code until the end of the class is needed, so the class can work with foreach loop
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        //goes to the next element 
        public bool MoveNext() 
        {
            position++;
            return (position < path.Count+1);
        }

        //when there are no more elements the starting position is reset to 0
        //so when foreach loop is called again the counting will start from 0 position
        public void Reset() 
        { position = 0; }

        //returns the current element at this position
        public object Current 
        {
            get { return path[position]; }
        }
    }

    //this class saves and loads path to/from a text file
    public static class PathStorage
    {

        static PathStorage()
        {
        }

        //method for saving the path
        //it has predifined file location
        //user must enter path's name when calling the method
        public static void Save(Path path)
        {
            StreamWriter writer = new StreamWriter(@"../../PathSaves.txt");

            //writting the path to file
            //each elemet is separated by space
            using (writer)
            {
                foreach (var point in path.Elements)
                {
                    writer.Write(" ");
                    writer.Write(point);
                }
            }
        }

        //method for loading already saved path
        public static Path Load()
        {
            //we need to create new path, because the method returns a Path
            Path tempPoints = new Path();
            StreamReader reader = new StreamReader(@"../../PathSaves.txt");

            //loading the path
            using (reader)
            {
                //read a line and separates all its elements into an array
                string line = reader.ReadLine();

                string[] numbers = line.Trim().Split();

               //this int will be used when trying to parse an element from the array
                int temp;

                //the counter will help us to know, if we have to write x,y or z, when find a digits from the elements
                int counter = 0;

                //3d point that will store current x,y,z before being written in the path
                Point3D tempPoint = new Point3D();

                foreach (string s in numbers)
                {
                    //counter>2 means that tempPoint has all x,y,z coordinates found
                    //tempPoint and counter must be reseted and start again with a new 3d point with its x coordinate
                      if(counter>2)
                        {
                            counter = 0;
                            tempPoints.Add(tempPoint);
                            tempPoint = new Point3D();
                        }

                    //check if s is int or not
                    //if it's digit write it as x,y or z depending on counter
                    //if not just continue with the next element s
                    if (Int32.TryParse(s, out temp))
                    {
                        if (counter == 0)
                        {
                            tempPoint.X = temp;
                            counter++;
                        }
                        else if (counter == 1)
                        {
                            tempPoint.Y = temp;
                            counter++;
                        }
                        else if (counter == 2)
                        {
                            tempPoint.Z = temp;
                            counter++;
                        }
                      
                    }
                }

                //when foreach loop finishes with all elements in the array we must check,
                //if there's a 3d point, which is not written to the path
                if (counter > 2)
                {
                    counter = 0;
                    tempPoints.Add(tempPoint);
                    tempPoint = new Point3D();
                }

                
            }
            return tempPoints;
        }
    }

}
