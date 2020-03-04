using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace task3
{
    /*
     * Class represents graph that was created by adjacency matrix
     * Adjacency matrix is reading from file
     * At the first line in file you need to write count of vortexes
     * Next you write your adjacency matrix
     * Attention! Your file should be near compiled program
     */
    public class GraphByAdjacencyMatrix : Graph
    {
        /*
         * Variable with read adjacency matrix
         */
        private int[][] adjacencyMatrix;

        /*
         * Constructor for graph object
         */
        public GraphByAdjacencyMatrix(string inputFileName)
        {
            ReadFromFile(inputFileName);
        }

        /*
         * Read adjacency matrix from file
         */
        private void ReadFromFile(string inputFileName)
        {
            try
            {
                StreamReader inputFile = new StreamReader(inputFileName);

                /*
                 * Get count of vortexes from file
                 */
                string lineWithVortexCount = inputFile.ReadLine();
                int vortexCount = Int32.Parse(lineWithVortexCount);
                adjacencyMatrix = new int[vortexCount][];

                /*
                 * Read lines with information of adjacents
                 */
                for (int i = 0; i < vortexCount; i++)
                {
                    string inputLine = inputFile.ReadLine();

                    /*
                     * Throw exception if line is null
                     */
                    string[] splittedInputLine = (inputLine != null) ? inputLine.Split(" ") : throw new IOException();
                    adjacencyMatrix[i] = splittedInputLine.Select(vortexInfo => Int32.Parse(vortexInfo)).ToArray();
                }

                inputFile.Close();
            }
            catch (Exception e)
            {
                ErrorHandler.WriteErrorInConsole(e, e.Message);
            }
        }

        /*
         * Return count of vortexes in graph
         */
        public override int VortexCount()
        {
            return adjacencyMatrix.GetLength(0);
        }

        /*
         * Return array of vortex neighbours
         */
        public override int[] GetVortexNeighbours(int vortex)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < VortexCount(); i++)
            {
                if (adjacencyMatrix[vortex][i] != 0 && vortex != i)
                {
                    result.Add(i);
                }
            }

            return result.ToArray();
        }

        /*
         * Override ToString method for matrix objects
         */
        public override string ToString()
        {
            string result = "\n" +
                            "Adjacency matrix for graph:\n";
            for (int i = 0; i < VortexCount(); i++)
            {
                for (int j = 0; j < VortexCount(); j++)
                {
                    result += $"{adjacencyMatrix[i][j]}\t";
                }

                result += "\n";
            }

            return result;
        }
    }
}
