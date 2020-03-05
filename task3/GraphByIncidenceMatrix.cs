using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace task3
{
    public class GraphByIncidenceMatrix : Graph
    {
        /*
         * Variable with read adjacency matrix
         */
        private int[][] incidenceMatrix;

        /*
         * Constructor for graph object
         */
        public GraphByIncidenceMatrix(string inputFileName)
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
                 * Get count of vortexes and edges from file
                 */
                string lineWithVortexAndEdgeCount = inputFile.ReadLine();
                int vortexCount = Int32.Parse(lineWithVortexAndEdgeCount.Split(" ")[0]);
                int edgeCount = Int32.Parse(lineWithVortexAndEdgeCount.Split(" ")[1]);
                incidenceMatrix = new int[vortexCount][];

                /*
                 * Read lines with information of incidences
                 */
                for (int i = 0; i < vortexCount; i++)
                {
                    string inputLine = inputFile.ReadLine();

                    /*
                     * Throw exception if line is null
                     */
                    string[] splittedInputLine = (inputLine != null) ? inputLine.Split(" ") : throw new IOException();
                    if (splittedInputLine.Length != edgeCount) throw new IOException();
                    incidenceMatrix[i] = splittedInputLine.Select(vortexInfo => Int32.Parse(vortexInfo)).ToArray();
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
            return incidenceMatrix.GetLength(0);
        }

        /*
         * Return count of edges in graph
         */
        public int EdgeCount()
        {
            return incidenceMatrix[0].GetLength(0);
        }

        /*
         * Return array of vortex neighbours
         */
        public override int[] GetVortexNeighbours(int vortex)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < EdgeCount(); i++)
            {
                if (incidenceMatrix[vortex][i] == 1)
                {
                    for (int j = 0; j < VortexCount(); j++)
                    {
                        if (j != vortex && incidenceMatrix[j][i] == -1)
                        {
                            result.Add(j);
                        }
                    }
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
                            "Incidence matrix for graph:\n";
            for (int i = 0; i < VortexCount(); i++)
            {
                for (int j = 0; j < EdgeCount(); j++)
                {
                    result += $"{incidenceMatrix[i][j]}\t";
                }

                result += "\n";
            }

            return result;
        }
    }
}
