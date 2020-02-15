using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Enter size of matrix
             */
            Console.Write("Enter n (size of matrix): ");
            int n = Int32.Parse(Console.ReadLine());

            /*
             * Enter matrices
             */
            Console.WriteLine("Enter matrix #1:");
            double[,] matrix1 = InputMatrix(n);
            Console.WriteLine("Enter matrix #2:");
            double[,] matrix2 = InputMatrix(n);

            /*
             * Clear console
             */
            Console.Clear();

            /*
             * Write matrix #1 to console
             */
            Console.WriteLine("Matrix #1:");
            PrintMatrix(matrix1);

            /*
             * Write matrix #2 to console
             */
            Console.WriteLine("Matrix #2:");
            PrintMatrix(matrix2);

            /*
             * Sum matrices and print result
             */
            Console.WriteLine("Matrix sum:");
            PrintMatrix(SumMatrices(matrix1, matrix2));

            /*
             * Multiply matrices and print result
             */
            Console.WriteLine("Matrix multiply:");
            PrintMatrix(MultiplyMatrices(matrix1, matrix2));
        }

        /*
         * Read elements from console and return matrix
         */
        private static double[,] InputMatrix(int n)
        {
            double[,] matrix = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = Double.Parse(Console.ReadLine());
                }
            }

            return matrix;
        }

        /*
         * Print matrix in console
         */
        private static void PrintMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }

                Console.WriteLine();
            }
        }

        /*
         * Sum two matrices and return result
         */
        private static double[,] SumMatrices(double[,] matrix1, double[,] matrix2)
        {
            int matrixSize = matrix1.GetLength(0);
            double[,] result = new double[matrixSize, matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return result;
        }

        /*
         * Multiply two matrices and return result
         */
        private static double[,] MultiplyMatrices(double[,] matrix1, double[,] matrix2)
        {
            int n = matrix1.GetLength(0);
            double[,] result = new double[n, n];
            /*
             * Row of first matrix
             */
            for (int k = 0; k < n; k++)
            {
                /*
                 * Column of second matrix
                 */
                for (int i = 0; i < n; i++)
                {
                    double element = 0;
                    /*
                     * Column of first matrix and row of second matrix
                     */
                    for (int j = 0; j < n; j++)
                    {
                        element += matrix1[k, j] * matrix2[j, i];
                    }

                    result[k, i] = element;
                }
            }
            return result;
        }
    }
}
