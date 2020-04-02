using System;
using System.IO;
using System.Linq;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            double[][] matrix = ReadMatrixFromFile("input.txt");
        }

        /*
         * Read matrix from file
         * First line - count of variables in matrix
         */
        private static double[][] ReadMatrixFromFile(string filename)
        {
            try
            {
                StreamReader inputFile = new StreamReader(filename);

                /*
                 * Get count of variables from file
                 */
                int variableCount = Int32.Parse(inputFile.ReadLine());
                double[][] matrix = new double[variableCount][];

                /*
                 * Read lines with information of incidences
                 */
                for (int i = 0; i < variableCount; i++)
                {
                    string inputLine = inputFile.ReadLine();

                    /*
                     * Throw exception if line is null
                     */
                    string[] splittedInputLine = (inputLine != null) ? inputLine.Split(" ") : throw new IOException();
                    if (splittedInputLine.Length != variableCount + 1) throw new IOException();
                    matrix[i] = splittedInputLine.Select(vortexInfo => Double.Parse(vortexInfo)).ToArray();
                }

                inputFile.Close();
                return matrix;
            }
            catch (Exception e)
            {
                ErrorHandler.WriteErrorInConsole(e, e.Message);
            }

            return new double[0][];
        }
    }
}
