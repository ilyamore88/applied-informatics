using System;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Adjacency matrix
             */
            GraphByAdjacencyMatrix graphByAdjacencyMatrix = new GraphByAdjacencyMatrix("adjacencyMatrix.txt");
            Console.WriteLine(graphByAdjacencyMatrix);

            /*
             * Depth first search for graph by adjacency matrix
             */
            int[] depthFirstSearchResult0 = DepthFirstSearch.BypassPath(graphByAdjacencyMatrix, 1);
            Console.WriteLine("Result of DFS:");
            Console.WriteLine(string.Join(" -> ", depthFirstSearchResult0));

            /*
             * Breadth first search for graph by adjacency matrix
             */
            int[] breadthFirstSearch0 = BreadthFirstSearch.BypassPath(graphByAdjacencyMatrix, 0, 2);
            Console.WriteLine("Result of BFS:");
            if (breadthFirstSearch0.Length == 0)
            {
                Console.WriteLine("BFS is impossible!");
            }
            else
            {
                Console.WriteLine(string.Join(" -> ", breadthFirstSearch0));
            }

            /*
             * Incidence matrix
             */
            GraphByIncidenceMatrix graphByIncidenceMatrix = new GraphByIncidenceMatrix("incidenceMatrix.txt");
            Console.WriteLine(graphByIncidenceMatrix);

            /*
             * Depth first search for graph by adjacency matrix
             */
            int[] depthFirstSearchResult = DepthFirstSearch.BypassPath(graphByIncidenceMatrix, 1);
            Console.WriteLine("Result of DFS:");
            Console.WriteLine(string.Join(" -> ", depthFirstSearchResult));

            /*
             * Breadth first search for graph by adjacency matrix
             */
            int[] breadthFirstSearch = BreadthFirstSearch.BypassPath(graphByIncidenceMatrix, 0, 3);
            Console.WriteLine("Result of BFS:");
            if (breadthFirstSearch.Length == 0)
            {
                Console.WriteLine("BFS is impossible!");
            }
            else
            {
                Console.WriteLine(string.Join(" -> ", breadthFirstSearch));
            }
        }
    }
}
