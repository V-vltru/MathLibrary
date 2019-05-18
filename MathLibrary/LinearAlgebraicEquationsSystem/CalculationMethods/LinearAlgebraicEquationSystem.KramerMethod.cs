using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebraicEquationsSystem
{
    public partial class LinearAlgebraicEquationSystem
    {
        public List<LAEVariable> CalculateKramerMethod()
        {
            double matrixDeterminant = MatrixT<double>.GetMatrixDeterminant(this.Matrix);
            List<LAEVariable> result = new List<LAEVariable>();

            for (int i = 0; i < this.Matrix.Columns; i++)
            {
                MatrixT<double> currentMatrix = MatrixT<double>.SubstituteMatrixColumn(this.Matrix, i, this.RightPartEquations);
                double currentDeterminant = MatrixT<double>.GetMatrixDeterminant(currentMatrix);

                result.Add(new LAEVariable(this.Variables[i].Name, currentDeterminant / matrixDeterminant));
            }

            return result;
        }

        public List<LAEVariable> CalculateKramerMethodAsync()
        {
            double matrixDeterminant = MatrixT<double>.GetMatrixDeterminant(this.Matrix);
            ConcurrentBag<LAEVariable> result = new ConcurrentBag<LAEVariable>();

            Parallel.For(0, this.Matrix.Columns, (i) => 
            {
                MatrixT<double> currentMatrix = MatrixT<double>.SubstituteMatrixColumn(this.Matrix, i, this.RightPartEquations);
                double currentDeterminant = MatrixT<double>.GetMatrixDeterminant(currentMatrix);

                result.Add(new LAEVariable(this.Variables[i].Name, currentDeterminant / matrixDeterminant));
            });

            return result.Cast<LAEVariable>().ToList();
        }
    }
}
