using System;
using System.Collections.Generic;
using _3D_Point;
using Matrixes;
using Generic_Lists;
using Version;

//you can test the code here
//I prepared some test, but you can always change them and write your own, if you want to try some other functionalties

    [Version(2, 5)]
    class Program
    {
        
        static void Main()
        {

             Console.WriteLine();

             Point3D p1 = new Point3D(4,5,6);
             Point3D p2 = new Point3D(6,7,8);
             Console.Write("Distance between points: ");
             double temp = Calculate.Distance(p1, p2);
             Console.Write(temp);
             Console.WriteLine();

             Console.WriteLine();

             Path path = new Path();
             path.Add(p1);
             path.Add(p2);

             foreach (var item in path.Elements)
             {
                 Console.WriteLine(item);
             }

             PathStorage.Save(path);
             Path pathLoadExample = PathStorage.Load();

             Console.WriteLine();

             foreach (var item in pathLoadExample.Elements)
             {
                 Console.WriteLine("Loaded path: " + item.ToString());
             }



             GenericList<string> myList = new GenericList<string>(2);
             myList.Add("hop");
             myList.Add("trop");
             myList.Add("bau");

             Console.WriteLine();

             Console.WriteLine(myList.ToString());

             Console.WriteLine();

             string tempStr = myList.Min();
             Console.WriteLine("Minimum element -" + tempStr);

             Console.WriteLine();

             Object version = new Program();
             Console.Write("Version: ");
             Console.WriteLine(version.GetType().GetCustomAttributes(typeof(VersionAttribute), false)[0].ToString());

             Console.WriteLine();

        //     Matrix myMatrix = new Matrix(2, 3);
        //Matrix yourMatrix = new Matrix(3, 2);
        //Matrix result;

        //for (int i = 0; i < myMatrix.Rows; i++)
        //{
        //    for (int j = 0; j < myMatrix.Columns; j++)
        //    {
        //        myMatrix[i, j] = int.Parse(Console.ReadLine());
        //    }

        //}

        //for (int i = 0; i < yourMatrix.Rows; i++)
        //{
        //    for (int j = 0; j < yourMatrix.Columns; j++)
        //    {
        //        yourMatrix[i, j] = int.Parse(Console.ReadLine());
        //    }

        //}

        //Console.WriteLine();

        //result = myMatrix*yourMatrix;

        //for (int i = 0; i < yourMatrix.Rows; i++)
        //{
        //    for (int j = 0; j < yourMatrix.Columns; j++)
        //    {
        //        Console.Write(yourMatrix[i, j]);
        //    }
        //    Console.WriteLine();

        //}

        //for (int i = 0; i < result.Rows; i++)
        //{
        //    for (int j = 0; j < result.Columns; j++)
        //    {
        //        Console.Write(result[i, j]);
        //    }
        //    Console.WriteLine();

        //}

        //string matrix = myMatrix.ToString();

        //Console.WriteLine(myMatrix.Rows);

        //Console.WriteLine(matrix);

        //Console.WriteLine(myMatrix[1,1]);
    }


 }
    

