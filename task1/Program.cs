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
            int[,] matrix1 = new int[n, n];
            int[,] matrix2 = new int[n, n];

            /*
             * Enter matrix #1
             */
            Console.WriteLine("Enter matrix #1:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix1[i, j] = Int32.Parse(Console.ReadLine());
                }
            }

            /*
             * Enter matrix #2
             */
            Console.WriteLine("Enter matrix #2:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix2[i, j] = Int32.Parse(Console.ReadLine());
                }
            }

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
        }

        /*
         * Print matrix in console
         */
        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j].ToString() + '\t');
                }

                Console.WriteLine();
            }
        }

        /*
         * Sum two matrices and return result
         */
        private static int[,] SumMatrices(int[,] matrix1, int[,] matrix2)
        {
            int matrixSize = matrix1.GetLength(0);
            int[,] matrixSum = new int[matrixSize, matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrixSum[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return matrixSum;
        }
    }
}
