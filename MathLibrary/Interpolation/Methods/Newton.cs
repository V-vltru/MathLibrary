namespace Interpolation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Newton : Interpolation
    {
        public const int MaxDotsInArea = 12;

        public Newton(Point[] points)
            :base(points)
        {
        }

        private double[,] SetDeltaArray(double x, List<Point> pointsAround)
        {
            double[,] result = new double[pointsAround.Count, pointsAround.Count];

            for (int j = 0; j < pointsAround.Count; j++)
            {
                result[0, j] = pointsAround[j].Y;
            }

            for (int i = 1; i < pointsAround.Count; i++)
            {
                for (int j = 0; j < pointsAround.Count - i; j++)
                {
                    result[i, j] = result[i - 1, j + 1] - result[i - 1, j];
                }
            }

            return result;
        }

        private long GetFactorial(int value)
        {
            checked
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Unable to calculate a factorial for negative value: {value}");
                }

                if (value == 0 || value == 1)
                {
                    return 1;
                }

                long result = 1;
                for (int i = 2; i <= value; i++)
                {
                    try
                    {
                        checked
                        {
                            result *= i;
                        }
                    }
                    catch(OverflowException)
                    {
                        result = long.MaxValue;
                        break;
                    }
                }

                return result;
            }
        }

        private double GetPolinomial(int polinomialNumber, double x, List<Point> pointsAround, double[,] delta, double step)
        {
            double currentDelta = delta[polinomialNumber, 0];
            double factorial = this.GetFactorial(polinomialNumber);
            double divider = 0;
            try
            {
                checked
                {
                    divider = factorial * Math.Pow(step, polinomialNumber);
                }
            }
            catch(OverflowException)
            {
                divider = double.MaxValue;
            }

            double multiplier = 1;
            for (int i = 0; i < polinomialNumber; i++)
            {
                try
                {
                    checked
                    {
                        multiplier *= (x - pointsAround[i].X);
                    }
                }
                catch(OverflowException)
                {
                    if (multiplier > 0 && (x - pointsAround[i].X) > 0 ||
                        multiplier < 0 && (x - pointsAround[i].X) < 0)
                    {
                        multiplier = double.MaxValue;
                    }
                    else
                    {
                        multiplier = double.MinValue;
                    }
                }                
            }

            double a = 0;
            try
            {
                checked
                {
                    a = currentDelta / divider;
                }
            }
            catch(OverflowException)
            {
                if (currentDelta > 0 && divider > 0 ||
                    currentDelta < 0 && divider < 0)
                {
                    a = double.MaxValue;
                }
                else
                {
                    a = double.MinValue;
                }
            }

            double result = 0;

            try
            {
                checked
                {
                    result = multiplier * a;
                }
            }
            catch(OverflowException)
            {
                if (multiplier > 0 && a > 0 ||
                    multiplier < 0 && a < 0)
                {
                    result = double.MaxValue;
                }
                else
                {
                    result = double.MinValue;
                }
            }

            return result;
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

            List<Point> pointsAround = base.GetPointsAround(argument, Newton.MaxDotsInArea);
            double[,] delta = this.SetDeltaArray(argument, pointsAround);

            // this.SetDeltaArray(argument, pointsAround);
            double step = base.GetStep(pointsAround); //base.FunctionTable[1].X - base.FunctionTable[0].X;//base.GetStep(this.PointsAround);
            double result = 0;
            for (int i = 0; i < pointsAround.Count; i++)
            {
                if (i == 0)
                {
                    result += delta[0, 0];
                }
                else
                {
                    result += this.GetPolinomial(i, argument, pointsAround, delta, step);
                }
            }

            return result;
        }
    }
}
