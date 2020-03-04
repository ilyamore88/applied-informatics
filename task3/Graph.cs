namespace task3
{
    public abstract class Graph
    {
        /*
         * Return count of vortexes
         */
        public abstract int VortexCount();

        /*
         * Return array of vortex neighbours
         */
        public abstract int[] GetVortexNeighbours(int vortex);
    }
}
