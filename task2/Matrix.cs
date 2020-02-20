using System;

namespace task2
{
    /*
     * Class implements matrix and methods for working with it
     */
    public class Matrix
    {
        /*
         * Variable with matrix data
         */
        private double[,] matrix;

        /*
         * Constructor for matrix object
         * Create matrix by user input
         */
        public Matrix()
        {
            Console.WriteLine("Enter the matrix:");
            this.MatrixInput();
        }

        /*
         * Constructor for matrix
         * Create matrix by array of double
         */
        public Matrix(double[,] matrix)
        {
            this.matrix = matrix;
        }

        /*
         * Override ToString method for matrix objects
         */
        public override string ToString()
        {
            string result = "\n";
            int rows = this.matrix.GetLength(0);
            int columns = this.matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result += $"{this.matrix[i, j]}\t";
                }

                result += "\n";
            }

            return result;
        }

        private void MatrixInput()
        {
            try
            {
                Console.Write("Count of rows: ");
                int n = Int32.Parse(Console.ReadLine());
                Console.Write("Count of columns: ");
                int m = Int32.Parse(Console.ReadLine());
                this.matrix = new double[n, m];
                Console.WriteLine("Enter matrix elements: ");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        this.matrix[i, j] = Double.Parse(Console.ReadLine());
                    }
                }
            }
            catch (FormatException e)
            {
                ErrorHandler.WriteErrorInConsole(e, "Parse error. Maybe, you write NaN element.");
            }
        }
    }
}
