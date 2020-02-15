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
            Console.Write("Enter n(size of matrix): ");
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
             * Matrix sum
             */
            int[,] matrixSum = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrixSum[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            /*
             * Write matrix sum
             */
            Console.WriteLine("Matrix sum:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrixSum[i, j].ToString() + '\t');
                }

                Console.WriteLine();
            }
        }

        /**
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
    }
}
