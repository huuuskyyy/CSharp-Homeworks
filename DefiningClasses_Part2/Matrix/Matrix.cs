using System;
using System.Text;

namespace Matrixes
{
    public class Matrix
    {
        private int rows;
        private int columns;
        private dynamic[,] matrix;

        //matrix constructor
        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.matrix = new dynamic[rows, columns];
        }

        //indexers for accessing an element on a given row and column
        public int this[int x, int y]
        {
            get
            {
                return matrix[x, y];
            }
            set
            {
                matrix[x, y] = value;
            }
        }

        public int Rows
        {
            get
            {
                return rows;
            }
            set
            {
                rows = value;
            }
        }

        public int Columns
        {
            get
            {
                return columns;
            }
            set
            {
                columns = value;
            }
        }

        //+ operator in order to sum matrixes
        //matrixes must have equals number of rows and columns
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
            {
                throw new Exception("The size of the matrices is different");
            }

            Matrix result = new Matrix(a.Rows, a.Columns);

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }

        //- operator for substracting matrixes
        //matrixes must have equal number of rows and columns
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
            {
                throw new Exception("The size of the matrices is different");
            }

            Matrix result = new Matrix(a.Rows, a.Columns);

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }
            return result;
        }

        //multiplying matrixes
        //columns of matrix1 must be equal to rows of matrix2
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Columns != b.Rows)
            {
                throw new Exception("The number of columns of the first matrix must equal the number of rows of the second matrix ");
            }

            Matrix result = new Matrix(a.Rows, b.Columns);

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Columns; j++)
                {
                    for (int k = 0; k < b.Rows; k++)
                    {
                        result[j, i] += (a[j, k] * b[k, i]);
                    }
                }
            }
            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this[0, 0]);
            for (int j = 1; j < this.Columns; j++)
            {
                result.AppendFormat(" {0}", this[0, j].ToString());
            }
            for (int i = 1; i < this.Rows; i++)
            {
                result.AppendFormat("\n{0}", this[i, 0].ToString());
                for (int j = 1; j < this.Columns; j++)
                {
                    result.AppendFormat(" {0}", this[i, j].ToString());
                }
            }
            return result.ToString();
        }

    }

}
