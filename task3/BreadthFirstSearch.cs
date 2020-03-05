using System.Collections.Generic;
using System.Linq;

namespace task3
{
    public class BreadthFirstSearch
    {
        /*
         * Graph for search
         */
        private static Graph graphForSearch;

        private static Queue<int> queue;

        private static int[] colors;

        /*
         * Return array of vortexes in the bypass path
         */
        public static int[] BypassPath(Graph graph, int source, int destination)
        {
            graphForSearch = graph;
            colors = new int[graph.VortexCount()];
            queue = new Queue<int>();
            Step[] result = Search(source, destination).ToArray();
            Stack<int> shortestWay = new Stack<int>();
            shortestWay.Push(result.Last().To);
            Step currentStep = result.Last();
            while (currentStep.From != source)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i].To == currentStep.From)
                    {
                        shortestWay.Push(result[i].To);
                        currentStep = result[i];
                        break;
                    }
                }
            }
            shortestWay.Push(currentStep.From);
            return shortestWay.ToArray();
        }

        /*
         * Recursive function for depth first search
         */
        private static List<Step> Search(int source, int destination)
        {
            List<Step> result = new List<Step>();
            colors[source] = 1;
            if (source == destination)
            {
                result.Add(new Step(source, destination));
                return result;
            }

            int[] neighbourVortexes = graphForSearch.GetVortexNeighbours(source);
            foreach (int neighbourVortex in neighbourVortexes)
            {
                if (colors[neighbourVortex] == 0)
                {
                    Step step = new Step(source, neighbourVortex);
                    result.Add(step);
                    if (neighbourVortex == destination)
                    {
                        return result;
                    }

                    queue.Enqueue(neighbourVortex);
                    colors[neighbourVortex] = 1;
                }
            }

            if (queue.Count != 0)
            {
                result.AddRange(Search(queue.Dequeue(), destination));
            }

            colors[source] = 2;

            return result;
        }
    }
}
