using System;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphByAdjacencyMatrix graph = new GraphByAdjacencyMatrix("adjacencyMatrix.txt");
            Console.WriteLine(graph);

            /*
             * Depth first search for graph by adjacency matrix
             */
            int[] depthFirstSearchResult = DepthFirstSearch.BypassPath(graph, 1);
            Console.WriteLine("Result of DFS:");
            Console.WriteLine(string.Join(" -> ", depthFirstSearchResult));
        }
    }
}
