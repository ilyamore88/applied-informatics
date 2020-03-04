namespace task3
{
    public struct Step
    {
        public int From { get; }
        public int To { get; }

        public Step(int from, int to)
        {
            this.From = from;
            this.To = to;
        }
    }
}
