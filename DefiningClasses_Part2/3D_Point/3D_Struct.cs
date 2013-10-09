using System;

namespace _3D_Point
{
    public struct Point3D
    {
        //default point's coordinates
        private static readonly Point3D startPoint = new Point3D(0, 0, 0);

        //point's coordinates that we will use
        private int x;
        private int y;
        private int z;

        //x coordinate property
        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        //y coordinate property
        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        //z coordinate property
        public int Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        //3d point constructor that must have 3 arguments
        public Point3D(int x, int y, int z)
            : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        //property that gives use the default 3d point coordinates (0,0,0)
        public static Point3D StartPoint
        {
            get { return startPoint; }
        }

        //ToString method which helps to display the 3d point on the console
        public override string ToString()
        {
            return String.Format("X = {0}  Y = {1}  Z = {2} ", this.X, this.Y, this.Z);
        }
    }

}
