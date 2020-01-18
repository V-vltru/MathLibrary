namespace Interpolation
{
    public class Line : Interpolation
    {
        public Line(Point[] points):
            base(points)
        {
        }

        /// <summary>
        /// Method is used to get the parameters of line equation.
        /// </summary>
        /// <param name="prevPoint">Previous point.</param>
        /// <param name="nextPoint">Next point.</param>
        /// <param name="a">First line parameter.</param>
        /// <param name="b">Second line parameter.</param>
        private void GetLineParameters(Point prevPoint, Point nextPoint, out double a, out double b)
        {
            a = (nextPoint.Y - prevPoint.Y) / (nextPoint.X - prevPoint.X);
            b = prevPoint.Y - a * prevPoint.X;
        }

        public override double GetInterpolatedValue(double argument)
        {
            double a = double.MinValue, b = double.MinValue;
            if (argument < base.FunctionTable[0].X)
            {
                this.GetLineParameters(base.FunctionTable[0], base.FunctionTable[1], out a, out b);
            }
            else if (argument > base.FunctionTable[base.FunctionTable.Length - 1].X)
            {
                this.GetLineParameters(
                    base.FunctionTable[base.FunctionTable.Length - 2],
                    base.FunctionTable[base.FunctionTable.Length - 1],
                    out a,
                    out b);
            }
            else
            {
                for (int i = 1; i < base.FunctionTable.Length; i++)
                {
                    if (argument == this.FunctionTable[i].X)
                    {
                        return this.FunctionTable[i].Y;
                    }
                    else if (argument < this.FunctionTable[i].X)
                    {
                        this.GetLineParameters(this.FunctionTable[i - 1], this.FunctionTable[i], out a, out b);
                        break;
                    }
                }
            }

            return a * argument + b;
        }
    }
}
