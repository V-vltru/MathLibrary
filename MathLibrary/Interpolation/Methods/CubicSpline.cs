namespace Interpolation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CubicSpline : Interpolation
    {
        private List<SplineTuple> Splines { get; set; }

        public CubicSpline(Point[] points)
            :base(points)
        {
            this.BuildSpline(points);
        }

        private void BuildSpline(Point[] points)
        {
            this.Splines = new List<SplineTuple>();
            for (int i = 0; i < points.Length; i++)
            {
                this.Splines.Add(new SplineTuple(points[i]));
            }

            this.Splines[0].C = 0;

            double[] alpha = new double[this.Splines.Count - 1];
            double[] beta = new double[this.Splines.Count - 1];
            double A = 0, B = 0, C = 0, F = 0, h_i = 0, z = 0;

            for (int i = 1; i < this.Splines.Count - 2; i++)
            {
                h_i = points[i].X - points[i - 1].X;
                double h_i1 = points[i + 1].X - points[i].X;
                A = h_i;
                C = 2 * (h_i + h_i1);
                B = h_i1;
                F = 6 * ((points[i + 1].Y - points[i].Y) / h_i1 - (points[i].Y - points[i - 1].Y) / h_i);
                z = A * alpha[i - 1] + C;

                alpha[i] = -B / z;
                beta[i] = (F - A * beta[i - 1]) / z;
            }

            this.Splines[this.Splines.Count - 1].C = (F - A * beta[this.Splines.Count - 2]) / (C + A * alpha[this.Splines.Count - 2]);

            for (int i = this.Splines.Count - 2; i > 0; i--)
            {
                this.Splines[i].C = alpha[i] * this.Splines[i + 1].C + beta[i];
            }

            for (int i = this.Splines.Count - 1; i > 0; i--)
            {
                h_i = points[i].X - points[i - 1].X;
                this.Splines[i].D = (this.Splines[i].C - this.Splines[i - 1].C) / h_i;
                this.Splines[i].B = h_i * (2 * this.Splines[i].C + this.Splines[i - 1].C) / 6 + (points[i].Y - points[i - 1].Y) / h_i;
            }
        }

        public override double GetInterpolatedValue(double x)
        {
            Point variableInList = (from g in base.FunctionTable
                                    where g.X == x
                                    select g).FirstOrDefault();

            if (variableInList != null)
            {
                return variableInList.Y;
            }

            SplineTuple s;

            if (this.Splines == null)
            {
                throw new Exception("Spline hasn't been set.");
            }

            if (x <= this.Splines[0].X)
            {
                s = this.Splines[0];
            }
            else if (x >= this.Splines[this.Splines.Count - 1].X)
            {
                s = this.Splines[this.Splines.Count - 1];
            }
            else
            {
                int i = 0;
                int j = this.Splines.Count - 1;
                while (i + 1 < j)
                {
                    int k = i + (j - i) / 2;

                    if (x <= this.Splines[k].X)
                    {
                        j = k;
                    }
                    else
                    {
                        i = k;
                    }
                }

                s = this.Splines[j - 1];
            }

            double dx = x - s.X;
            return s.A + (s.B + (s.C / 2 + s.D * dx / 6) * dx) * dx;
        }
    }

    internal class SplineTuple
    {
        public double A { get; set; }

        public double B { get; set; }

        public double C { get; set; }

        public double D { get; set; }

        public double X { get; set; }

        public SplineTuple(double x, double a)
        {
            this.X = x;
            this.A = a;
        }

        public SplineTuple(Point point)
        {
            this.X = point.X;
            this.A = point.Y;
        }
    }
}
