namespace LinearAlgebraicEquationsSystem
{
    using System.Collections.Generic;

    public partial class LinearAlgebraicEquationSystem
    {
        private LAEAnswer CalculateMatrixMethod(out List<LAEVariable> lAEVariables, List<IntermediateResult> intermediateResults = null)
        {
            bool systemCompatible = this.CheckLinearAlgebraicEquationSystemCompatibility();
            if (!systemCompatible)
            {
                lAEVariables = null;
                return LAEAnswer.NoSolutions;
            }

            MatrixT<double> inversedMatrix = MatrixT<double>.GetInverseMatrix(this.Matrix);
            if (intermediateResults != null)
            {
                intermediateResults.Add(new IntermediateResult("Inversed matrix: ", inversedMatrix, this.RightPartEquations.ToArray()));
            }
            
            MatrixT<double> resultMatrix = inversedMatrix * new MatrixT<double>(this.RightPartEquations.ToArray());
            if(intermediateResults != null)
            {
                intermediateResults.Add(new IntermediateResult("Result matrix: ", resultMatrix, null));
            }

            lAEVariables = LAEVariable.FillLAEVariablesWithMatrix(resultMatrix, this.Variables);

            return LAEAnswer.OneSolution;
        }

        private LAEAnswer CalculateMatrixMethodAsync(out List<LAEVariable> lAEVariables, List<IntermediateResult> intermediateResults = null)
        {
            bool systemCompatible = this.CheckLinearAlgebraicEquationSystemCompatibility();
            if (!systemCompatible)
            {
                lAEVariables = null;
                return LAEAnswer.NoSolutions;
            }

            MatrixT<double> inversedMatrix = MatrixT<double>.GetInverseMatrix(this.Matrix);
            if (intermediateResults != null)
            {
                intermediateResults.Add(new IntermediateResult("Inversed matrix: ", inversedMatrix, this.RightPartEquations.ToArray()));
            }

            MatrixT<double>.Paral = true;
            MatrixT<double> resultMatrix = inversedMatrix * new MatrixT<double>(this.RightPartEquations.ToArray());
            if (intermediateResults != null)
            {
                intermediateResults.Add(new IntermediateResult("Result matrix: ", resultMatrix, null));
            }

            lAEVariables = LAEVariable.FillLAEVariablesWithMatrix(resultMatrix, this.Variables);

            return LAEAnswer.OneSolution;
        }
    }
}
