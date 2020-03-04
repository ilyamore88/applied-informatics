using System.Collections.Generic;

namespace task3
{
    /*
     * Class implements depth first search
     */
    public class DepthFirstSearch
    {
        /*
         * Graph for search
         */
        private static Graph graphForSearch;

        /*
         * Information about visited vortexes
         */
        private static bool[] isVisited;

        /*
         * Return array of vortexes in the bypass path
         */
        public static int[] BypassPath(Graph graph, int vortex)
        {
            graphForSearch = graph;
            isVisited = new bool[graph.VortexCount()];
            return Search(vortex).ToArray();
        }

        /*
         * Recursive function for depth first search
         */
        private static List<int> Search(int vortex)
        {
            List<int> result = new List<int>();
            result.Add(vortex);
            isVisited[vortex] = true;
            int[] neighbourVortexes = graphForSearch.GetVortexNeighbours(vortex);
            foreach (int neighbour in neighbourVortexes)
            {
                if (!isVisited[neighbour])
                {
                    result.AddRange(Search(neighbour));
                }
            }

            return result;
        }
    }
}
