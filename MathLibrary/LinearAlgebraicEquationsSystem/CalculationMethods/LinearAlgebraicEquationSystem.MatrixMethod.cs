namespace LinearAlgebraicEquationsSystem
{
    using System.Collections.Generic;

    public partial class LinearAlgebraicEquationSystem
    {
        private LAEAnswer CalculateMatrixMethod(out List<LAEVariable> lAEVariables)
        {
            bool systemCompatible = this.CheckLinearAlgebraicEquationSystemCompatibility();
            if (!systemCompatible)
            {
                lAEVariables = null;
                return LAEAnswer.NoSolutions;
            }

            MatrixT<double> inversedMatrix = MatrixT<double>.GetInverseMatrix(this.Matrix);
            
            MatrixT<double> resultMatrix = inversedMatrix * new MatrixT<double>(this.RightPartEquations.ToArray());
            lAEVariables = LAEVariable.FillLAEVariablesWithMatrix(resultMatrix, this.Variables);

            return LAEAnswer.OneSolution;
        }

        private LAEAnswer CalculateMatrixMethodAsync(out List<LAEVariable> lAEVariables)
        {
            bool systemCompatible = this.CheckLinearAlgebraicEquationSystemCompatibility();
            if (!systemCompatible)
            {
                lAEVariables = null;
                return LAEAnswer.NoSolutions;
            }

            MatrixT<double> inversedMatrix = MatrixT<double>.GetInverseMatrix(this.Matrix);

            MatrixT<double>.Paral = true;
            MatrixT<double> resultMatrix = inversedMatrix * new MatrixT<double>(this.RightPartEquations.ToArray());
            lAEVariables = LAEVariable.FillLAEVariablesWithMatrix(resultMatrix, this.Variables);

            return LAEAnswer.OneSolution;
        }
    }
}
