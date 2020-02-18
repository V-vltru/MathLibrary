namespace Interpolation
{
    using System;

    /// <summary>
    /// Points for building table function.
    /// </summary>
    public class Point: IComparable<Point>
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point()
        {
        }

        /// <summary>
        /// Gets or sets X-coordinate.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets Y-coordinate.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Method is used to compare two points in order to sort the list of points.
        /// </summary>
        /// <param name="other">Second point.</param>
        /// <returns>Comparer as int.</returns>
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
