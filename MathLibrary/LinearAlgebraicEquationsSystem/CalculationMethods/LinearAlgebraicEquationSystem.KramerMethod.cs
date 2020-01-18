namespace LinearAlgebraicEquationsSystem
{
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Threading.Tasks;

    public partial class LinearAlgebraicEquationSystem
    {
        private LAEAnswer CalculateKramerMethod(out List<LAEVariable> lAEVariables, List<IntermediateResult> intermediateResults = null)
        {
            bool systemCompatible = this.CheckLinearAlgebraicEquationSystemCompatibility();
            if (!systemCompatible)
            {
                lAEVariables = null;
                return LAEAnswer.NoSolutions;
            }

            double matrixDeterminant = MatrixT<double>.GetMatrixDeterminant(this.Matrix);
            if (intermediateResults != null)
            {
                intermediateResults.Add(new IntermediateResult($"Matrix determinant: {matrixDeterminant}", null, null));
            }

            List<LAEVariable> result = new List<LAEVariable>();

            for (int i = 0; i < this.Matrix.Columns; i++)
            {
                MatrixT<double> currentMatrix = MatrixT<double>.SubstituteMatrixColumn(this.Matrix, i, this.RightPartEquations);
                double currentDeterminant = MatrixT<double>.GetMatrixDeterminant(currentMatrix);

                if (intermediateResults != null)
                {
                    intermediateResults.Add(new IntermediateResult($"Substituted column ({i}) with right part. Determinant: ({currentDeterminant})", currentMatrix, null));
                }

                result.Add(new LAEVariable(this.Variables[i].Name, currentDeterminant / matrixDeterminant));
            }

            lAEVariables = result;
            return LAEAnswer.OneSolution;
        }

        private LAEAnswer CalculateKramerMethodAsync(out List<LAEVariable> lAEVariables, List<IntermediateResult> intermediateResults = null)
        {
            ConcurrentBag<IntermediateResult> intermediateConcurrentResults = null;
            if (intermediateResults != null)
            {
                intermediateConcurrentResults = new ConcurrentBag<IntermediateResult>();
            }

            bool systemCompatible = this.CheckLinearAlgebraicEquationSystemCompatibility();
            if (!systemCompatible)
            {
                lAEVariables = null;
                return LAEAnswer.NoSolutions;
            }

            double matrixDeterminant = MatrixT<double>.GetMatrixDeterminant(this.Matrix);            
            ConcurrentBag<LAEVariable> result = new ConcurrentBag<LAEVariable>();
            if (intermediateResults != null)
            {
                intermediateConcurrentResults.Add(new IntermediateResult($"Matrix determinant: {matrixDeterminant}", null, null));
            }

            Parallel.For(0, this.Matrix.Columns, (i) => 
            {
                MatrixT<double> currentMatrix = MatrixT<double>.SubstituteMatrixColumn(this.Matrix, i, this.RightPartEquations);
                double currentDeterminant = MatrixT<double>.GetMatrixDeterminant(currentMatrix);

                if (intermediateResults != null)
                {
                    intermediateConcurrentResults.Add(new IntermediateResult($"Substituted column ({i}) with right part. Determinant: ({currentDeterminant})", currentMatrix, null));
                }
                
                result.Add(new LAEVariable(this.Variables[i].Name, currentDeterminant / matrixDeterminant));
            });

            lAEVariables = result.Cast<LAEVariable>().ToList();

            if (intermediateResults != null)
            {
                intermediateResults.AddRange(intermediateConcurrentResults);
            }

            return LAEAnswer.OneSolution;
        }
    }
}
