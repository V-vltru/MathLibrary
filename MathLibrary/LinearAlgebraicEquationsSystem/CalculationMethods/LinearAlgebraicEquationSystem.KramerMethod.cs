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
        private LAEAnswer CalculateKramerMethod(out List<LAEVariable> lAEVariables)
        {
            bool systemCompatible = this.CheckLinearAlgebraicEquationSystemCompatibility();
            if (!systemCompatible)
            {
                lAEVariables = null;
                return LAEAnswer.NoSolutions;
            }

            double matrixDeterminant = MatrixT<double>.GetMatrixDeterminant(this.Matrix);
            List<LAEVariable> result = new List<LAEVariable>();

            for (int i = 0; i < this.Matrix.Columns; i++)
            {
                MatrixT<double> currentMatrix = MatrixT<double>.SubstituteMatrixColumn(this.Matrix, i, this.RightPartEquations);
                double currentDeterminant = MatrixT<double>.GetMatrixDeterminant(currentMatrix);

                result.Add(new LAEVariable(this.Variables[i].Name, currentDeterminant / matrixDeterminant));
            }

            lAEVariables = result;
            return LAEAnswer.OneSolution;
        }

        private LAEAnswer CalculateKramerMethodAsync(out List<LAEVariable> lAEVariables)
        {
            bool systemCompatible = this.CheckLinearAlgebraicEquationSystemCompatibility();
            if (!systemCompatible)
            {
                lAEVariables = null;
                return LAEAnswer.NoSolutions;
            }

            double matrixDeterminant = MatrixT<double>.GetMatrixDeterminant(this.Matrix);
            ConcurrentBag<LAEVariable> result = new ConcurrentBag<LAEVariable>();

            Parallel.For(0, this.Matrix.Columns, (i) => 
            {
                MatrixT<double> currentMatrix = MatrixT<double>.SubstituteMatrixColumn(this.Matrix, i, this.RightPartEquations);
                double currentDeterminant = MatrixT<double>.GetMatrixDeterminant(currentMatrix);

                result.Add(new LAEVariable(this.Variables[i].Name, currentDeterminant / matrixDeterminant));
            });

            lAEVariables = result.Cast<LAEVariable>().ToList();
            return LAEAnswer.OneSolution;
        }
    }
}
