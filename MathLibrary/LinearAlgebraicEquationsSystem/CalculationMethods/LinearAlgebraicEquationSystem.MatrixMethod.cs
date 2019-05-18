namespace LinearAlgebraicEquationsSystem
{
    using System.Collections.Generic;

    public partial class LinearAlgebraicEquationSystem
    {
        public List<LAEVariable> CalculateMatrixMethod()
        {
            MatrixT<double> inversedMatrix = MatrixT<double>.GetInverseMatrix(this.Matrix);
            
            MatrixT<double> resultMatrix = inversedMatrix * new MatrixT<double>(this.RightPartEquations.ToArray());
            List<LAEVariable> result = LAEVariable.FillLAEVariablesWithMatrix(resultMatrix, this.Variables);

            return result;
        }

        public List<LAEVariable> CalculateMatrixMethodAsync()
        {
            MatrixT<double> inversedMatrix = MatrixT<double>.GetInverseMatrix(this.Matrix);

            MatrixT<double>.Paral = true;
            MatrixT<double> resultMatrix = inversedMatrix * new MatrixT<double>(this.RightPartEquations.ToArray());
            List<LAEVariable> result = LAEVariable.FillLAEVariablesWithMatrix(resultMatrix, this.Variables);
            return result;
        }
    }
}
