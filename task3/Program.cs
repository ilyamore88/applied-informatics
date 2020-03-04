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

            /*
             * Breadth first search for graph by adjacency matrix
             */
            Step[] breadthFirstSearch = BreadthFirstSearch.BypassPath(graph, 0, 1);
            Console.WriteLine("Result of BFS:");
            if (breadthFirstSearch.Length == 0)
            {
                Console.WriteLine("BFS is impossible!");
            }
            else
            {
                foreach (Step step in breadthFirstSearch)
                {
                    Console.WriteLine($"{step.From} -> {step.To}");
                }
            }
        }
    }
}
