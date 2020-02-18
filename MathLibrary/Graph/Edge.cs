namespace Graph
{
    class Edge
    {
        public Point FirstPoint { get; private set; }

        public Point SecondPoint { get; private set; }

        public float Weight { get; private set; }

        public Edge(Point first, Point second, float weight)
        {
            this.FirstPoint = first;
            this.SecondPoint = second;
            this.Weight = weight;
        }
    }
}
