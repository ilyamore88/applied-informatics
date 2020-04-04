using System;

namespace task5
{
    public class Gauss
    {
        /*
         * Subtract row #n
         * Return new matrix
         */
        private static void SubtractRow(ref double[][] matrix, int n)
        {
            double m = matrix[n][n];
            for (int i = n + 1; i < matrix.Length; i++)
            {
                double t = matrix[i][n] / m;
                for (int j = n; j < matrix[0].Length; j++)
                {
                    matrix[i][j] = matrix[i][j] - matrix[n][j] * t;
                    if (matrix[i][j] < 0.0001 && matrix[i][j] > 0.0001) matrix[i][j] = 0;
                }
            }
        }

        /*
         * Get Lead in column #n
         */
        static void SelectLeading(ref double[][] matrix, int n)
        {
            int indexOfRowWithMax = n;
            for (int i = n + 1; i < matrix.Length; i++)
            {
                if (Math.Abs(matrix[indexOfRowWithMax][n]) < Math.Abs(matrix[i][n]))
                {
                    indexOfRowWithMax = i;
                }
            }

            if (indexOfRowWithMax != n)
            {
                for (int i = n; i < matrix[0].Length; i++)
                {
                    matrix[n][i] += matrix[indexOfRowWithMax][i] - (matrix[indexOfRowWithMax][i] = matrix[n][i]);
                }
            }
        }

        /*
         * Get matrix in triangular view
         * Return false if can't find solution
         */
        private static bool TriangleMatrix(ref double[][] matrix)
        {
            for (int i = 1; i < matrix.Length; i++)
            {
                SelectLeading(ref matrix, i - 1);
                if (Math.Abs(matrix[i - 1][i - 1]) > 0.0001)
                {
                    SubtractRow(ref matrix, i - 1);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /*
         * Return solution for matrix by Gauss method
         */
        public static double[] Solve(double[][] matrix)
        {
            if (!TriangleMatrix(ref matrix)) return null;
            double[] resolve = new double[matrix.Length];
            int countOfVariables = matrix[0].Length - 1;
            for (int i = resolve.Length - 1; i >= 0; i--)
            {
                double sum = 0;
                for (int j = i + 1; j < countOfVariables; j++)
                {
                    sum += resolve[j] * matrix[i][j];
                }

                resolve[i] = (matrix[i][countOfVariables] - sum) / matrix[i][i];
            }

            return resolve;
        }
    }
}
