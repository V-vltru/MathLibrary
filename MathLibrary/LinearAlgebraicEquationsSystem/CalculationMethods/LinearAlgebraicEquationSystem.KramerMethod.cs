using System;
using System.Collections.Generic;
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
    }
}
