using System;

namespace _3D_Point
{
   public static class Calculate
    {
        //just one method in this class for distance calculation between two 3d points. Euclidean distance algorithm is use
        public static double Distance(Point3D point1, Point3D point2)
        {
            double result = (double)Math.Sqrt(((point1.X - point2.X) * (point1.X - point2.X) + (point1.Y - point2.Y) * (point1.Y - point2.Y) + (point1.Z - point2.Z) * (point1.Z - point2.Z)));
            return result;
        }
    }

}
