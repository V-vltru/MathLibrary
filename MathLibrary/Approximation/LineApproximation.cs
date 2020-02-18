namespace Approximation
{
    using System;

    public class LineApproximation: Approximation
    {
        public double A { get; set; }

        public double B { get; set; }

        public LineApproximation(Point[] points)
            :base(points)
        {
        }

        public LineApproximation()
            :base()
        {
        }

        public void Calculate()
        {
            this.A = this.CalculateA();
            this.B = this.CalculateB(this.A, base.FunctionTable.Length);
        }

        private double Fa1(int length)
        {
            double result = 0;

            for (int i = 0; i < length; i++)
            {
                result += base.FunctionTable[i].X * base.FunctionTable[i].Y;
            }

            return result * length;
        }

        private double Fa2(int length)
        {
            double xSum = 0, ySum = 0;

            for (int i = 0; i < length; i++)
            {
                xSum += base.FunctionTable[i].X;
                ySum += base.FunctionTable[i].Y;
            }

            return xSum * ySum;
        }

        private double Fa3(int length)
        {
            double result = 0;

            for (int i = 0; i < length; i++)
            {
                result += System.Math.Pow(base.FunctionTable[i].X, 2);
            }

            return length * result;
        }

        private double Fa4(int length)
        {
            double result = 0;

            for (int i = 0; i < length; i++)
            {
                result += base.FunctionTable[i].X;
            }

            return System.Math.Pow(result, 2);
        }

        private double CalculateA()
        {
            int length = base.FunctionTable.Length;
            double result;

            try
            {
                checked
                {
                    result = (Fa1(length) - Fa2(length)) / (Fa3(length) - Fa4(length));
                }
            }
            catch(OverflowException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }

            return result;
        }

        private double CalculateB(double a, int length)
        {
            double xSum = 0, ySum = 0;
            for (int i = 0; i < length; i++)
            {
                xSum += base.FunctionTable[i].X;
                ySum += base.FunctionTable[i].Y;
            }

            return (ySum - a * xSum) / length;
        }

        public Func<double, double> GetLine()
        {
            return ((x) => { return this.A * (x - base.DX) + this.B + base.DY; });
        }
    }
}
