using System;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphByAdjacencyMatrix graph = new GraphByAdjacencyMatrix("adjacencyMatrix.txt");
            Console.WriteLine(graph);
        }
    }
}
