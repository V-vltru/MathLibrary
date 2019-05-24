using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebraicEquationsSystem
{
    public partial class LinearAlgebraicEquationSystem
    {
        private LAEAnswer CalculateGaussMethod(out List<LAEVariable> results)
        {
            results = null;

            MatrixT<double> currentMatrix = new MatrixT<double>(this.Matrix.Rows, this.Matrix.Columns);
            MatrixT<double>.CopyMatrixItems(this.Matrix, currentMatrix);

            double[] rightPart = new double[this.RightPartEquations.Count];
            for (int i = 0; i < this.RightPartEquations.Count; i++)
            {
                rightPart[i] = this.RightPartEquations[i];
            }

            double[] answer = new double[this.Variables.Count];

            if (currentMatrix.Rows != currentMatrix.Columns)
            {
                results = null;
                return LAEAnswer.NoSolutions;
            }

            for (int i = 0; i < currentMatrix.Rows - 1; i++)
            {
                SortRows(currentMatrix, ref rightPart, i);

                for (int j = i + 1; j < currentMatrix.Rows; j++)
                {
                    if (currentMatrix[i, i] != 0)
                    {
                        double multElement = currentMatrix[j, i] / currentMatrix[i, i];

                        for (int k = i; k < currentMatrix.Columns; k++)
                        {
                            currentMatrix[j, k] -= currentMatrix[i, k] * multElement;
                        }

                        rightPart[j] -= rightPart[i] * multElement;
                    }
                }
            }

            for (int i = currentMatrix.Rows - 1; i >= 0; i--)
            {
                answer[i] = rightPart[i];

                for (int j = currentMatrix.Rows - 1; j > i; j--)
                {
                    answer[i] -= currentMatrix[i, j] * answer[j];
                }

                if (currentMatrix[i, i] == 0)
                {
                    if (rightPart[i] == 0)
                    {
                        return LAEAnswer.ManySolutions;
                    }
                    else
                    {
                        return LAEAnswer.NoSolutions;
                    }
                }

                answer[i] /= currentMatrix[i, i];
            }

            results = new List<LAEVariable>();
            for (int i = 0; i < this.Variables.Count; i++)
            {
                results.Add(new LAEVariable(this.Variables[i].Name, answer[i]));
            }

            return LAEAnswer.OneSolution;
        }

        private void SortRows(MatrixT<double> matrix, ref double[] rightPart, int sortIndex)
        {
            double maxElement = matrix[sortIndex, sortIndex];
            int maxElementIndex = sortIndex;

            for (int i = sortIndex + 1; i < this.Matrix.Rows; i++)
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

                for (int i=0; i < this.Matrix.Columns; i++)
                {
                    temp = matrix[maxElementIndex, i];
                    matrix[maxElementIndex, i] = matrix[sortIndex, i];
                    matrix[sortIndex, i] = temp;
                }
            }
        }
    }        
}
