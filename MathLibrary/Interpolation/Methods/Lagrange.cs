namespace Interpolation
{
    using System.Collections.Generic;
    using System.Linq;

    public class Lagrange : Interpolation
    {
        public int MaxPointInArea { get; set; } = 20;

        public Lagrange(IEnumerable<Point> functionTable)
            : base(functionTable)
        {
        }

        public Lagrange()
        {
        }

        public override double GetInterpolatedValue(double argument)
        {
            Point variableInList = (from g in base.FunctionTable
                                   where g.X == argument
                                   select g).FirstOrDefault();

            if (variableInList != null)
            {
                return variableInList.Y;
            }

            List<Point> pointsAround = this.GetPointsAround(argument, this.MaxPointInArea);

            object obj = new object();
            double result = 0;

            for (int i = 0; i < pointsAround.Count; i++)
            {
                checked
                {
                    result += pointsAround[i].Y * this.GetPolynomial(i, argument, pointsAround);
                }
            }

            return result;
        }

        private double GetPolynomial(int variabeIdx, double X, List<Point> pointsAround)
        {
            double totalPolynomial = 1;

            for (int i = 0; i < pointsAround.Count; i++)
            {
                if (i != variabeIdx)
                {
                    checked
                    {
                        totalPolynomial *= (X - pointsAround[i].X) / (pointsAround[variabeIdx].X - pointsAround[i].X);
                    }
                }
            }

            return totalPolynomial;
        }
    }
}
