namespace Interpolation
{
    using System;
    using System.Collections.Generic;
    using Matrix;

    public class CanonicalPolynomial : Interpolation
    {
        /// <summary>
        /// Gets or sets the maximal points around the input argument.
        /// </summary>
        public int MaxDotsInArea { get; set; } = 10;

        public CanonicalPolynomial(Point[] points)
            :base(points)
        {
        }

        /// <summary>
        /// Used to get the interpolated value for the argument.
        /// </summary>
        /// <param name="argument">Input argument (X).</param>
        /// <returns>The interpolated value for the input argument.</returns>
        public override double GetInterpolatedValue(double argument)
        {
            List<Point> pointsAround = base.GetPointsAround(argument, this.MaxDotsInArea);

            double[] answer = this.GetSolutionByGauss(pointsAround);

            double result = 0;
            for (int i = 0; i < answer.Length; i++)
            {
                result += answer[i] * Math.Pow(argument, i);
            }

            return result;
        }

        /// <summary>
        /// Method is used to calculate a solution for algebraic equation by Gauss method.
        /// </summary>
        /// <param name="pointsAround">points around the argument.</param>
        /// <returns>Array of calculated values.</returns>
        private double[] GetSolutionByGauss(List<Point> pointsAround)
        {
            MatrixT<double> matrix = new MatrixT<double>(pointsAround.Count, pointsAround.Count);
            double[] rightPart = new double[pointsAround.Count];

            for (int i = 0; i < rightPart.Length; i++)
            {
                rightPart[i] = pointsAround[i].Y;
            }

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    matrix[i, j] = Math.Pow(pointsAround[i].X, j);
                }
            }

            double[] answer = new double[pointsAround.Count];
            for (int i = 0; i < matrix.Rows - 1; i++)
            {
                SortRows(matrix, ref rightPart, i);

                for (int j = i + 1; j < matrix.Rows; j++)
                {
                    if (matrix[i, i] != 0)
                    {
                        double multElement = matrix[j, i] / matrix[i, i];

                        for (int k = i; k < matrix.Columns; k++)
                        {
                            matrix[j, k] -= matrix[i, k] * multElement;
                        }

                        rightPart[j] -= rightPart[i] * multElement;
                    }
                }
            }

            for (int i = matrix.Rows - 1; i >= 0; i--)
            {
                answer[i] = rightPart[i];

                for (int j = matrix.Rows - 1; j > i; j--)
                {
                    answer[i] -= matrix[i, j] * answer[j];
                }

                if (matrix[i, i] == 0)
                {
                    throw new Exception("Could not find the solution.");
                }

                answer[i] /= matrix[i, i];
            }

            return answer;
        }

        private void SortRows(MatrixT<double> matrix, ref double[] rightPart, int sortIndex)
        {
            double maxElement = matrix[sortIndex, sortIndex];
            int maxElementIndex = sortIndex;

            for (int i = sortIndex + 1; i < matrix.Rows; i++)
            {
                if (matrix[i, sortIndex] > maxElement)
                {
                    maxElement = matrix[i, sortIndex];
                    maxElementIndex = i;
                }
            }

            if (maxElement > sortIndex)
            {
                double temp;

                temp = rightPart[maxElementIndex];
                rightPart[maxElementIndex] = rightPart[sortIndex];
                rightPart[sortIndex] = temp;

                for (int i = 0; i < matrix.Columns; i++)
                {
                    temp = matrix[maxElementIndex, i];
                    matrix[maxElementIndex, i] = matrix[sortIndex, i];
                    matrix[sortIndex, i] = temp;
                }
            }
        }
    }
}
