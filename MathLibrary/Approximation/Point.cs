namespace Approximation
{
    using System;

    public class Point : IComparable<Point>
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point()
        {
        }

        public double X { get; set; }

        public double Y { get; set; }

        public int CompareTo(Point other)
        {
            if (other == null)
            {
                return 1;
            }

            return this.X.CompareTo(other.X);
        }
    }
}
