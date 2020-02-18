namespace Graph
{
    class Point
    {
        public float CurrentPathValue { get; set; }

        public string Name { get; set; }

        public bool IsChecked { get; set; }

        public Point PreviousPathPoint { get; set; }

        public Point(string pointName)
        {
            this.Name = pointName;
            this.CurrentPathValue = float.MaxValue;
        }
    }
}
