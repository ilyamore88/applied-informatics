using System;

namespace task3
{
    public class DijkstraAlgorithm
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
         * Information about distance to vortexes
         */
        private static int[] distance;

        /*
         * Return array of vortexes in the bypass path
         */
        public static int[] BypassPath(Graph graph, int vortex)
        {
            graphForSearch = graph;
            isVisited = new bool[graph.VortexCount()];
            distance = new int[graph.VortexCount()];
            for (int i = 0; i < graphForSearch.VortexCount(); i++)
            {
                distance[i] = Int32.MaxValue;
            }

            return Search(vortex);
        }

        /*
         * Function for dijkstra algorithm
         */
        private static int[] Search(int vortex)
        {
            int index = 0, u = 0;
            distance[vortex] = 0;
            for (int count = 0; count < graphForSearch.VortexCount() - 1; count++)
            {
                int min = Int32.MaxValue;
                for (int i = 0; i < graphForSearch.VortexCount(); i++)
                {
                    if (!isVisited[i] && distance[i] <= min)
                    {
                        min = distance[i];
                        index = i;
                    }
                }

                u = index;
                isVisited[u] = true;
                int[] neighbourVortexes = graphForSearch.GetVortexNeighbours(u);
                foreach (int neighbourVortex in neighbourVortexes)
                {
                    int distanceTemp = graphForSearch.GetDistance(u, neighbourVortex);
                    if (!isVisited[neighbourVortex] &&
                        distance[u] + distanceTemp < distance[neighbourVortex] &&
                        distance[u] != Int32.MaxValue)
                    {
                        distance[neighbourVortex] = distance[u] + distanceTemp;
                    }
                }
            }

            return distance;
        }
    }
}
