namespace LinearAlgebraicEquationsSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Expressions;
    using Expressions.Models;

    public partial class LinearAlgebraicEquationSystem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinearAlgebraicEquationSystem" /> class.
        /// </summary>
        /// <param name="leftPartEquations">Left part of linear algebraic equations.</param>
        /// <param name="rightPartEquations">Right part of linear algebraic equations.</param>
        /// <param name="variables">Variables of linear algebraic equations.</param>
        /// <param name="constants">Other constant parameters of linear algebraic equations.</param>
        public LinearAlgebraicEquationSystem(List<string> leftPartEquations, List<double> rightPartEquations, 
            List<LAEVariable> variables, List<LAEVariable> constants)
        {
            if (rightPartEquations != null && rightPartEquations.Count > 0)
            {
                this.RightPartEquations = rightPartEquations;
            }
            else
            {
                throw new ArgumentException("Right parts list is null or empty!");
            }

            List<Variable> allVariables = new List<Variable>();

            if (variables != null && variables.Count > 0)
            {
                this.Variables = LAEVariable.ConvertLAEVariablesToVariables(variables);
                allVariables.AddRange(this.Variables);
            }
            else
            {
                throw new ArgumentException("Variables list is null or empty!");
            }

            if (constants != null && constants.Count > 0)
            {
                this.Constants = LAEVariable.ConvertLAEVariablesToVariables(constants);
                allVariables.AddRange(this.Constants);
            }
           
            this.LeftPartEquations = new List<Expression>();
            foreach(string leftPart in leftPartEquations)
            {
                this.LeftPartEquations.Add(new Expression(leftPart, allVariables));
            }

            this.Matrix = LinearAlgebraicEquationSystem.SetMatrix(this.LeftPartEquations, this.Variables, this.Constants);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LinearAlgebraicEquationSystem" /> class.
        /// </summary>
        public LinearAlgebraicEquationSystem()
        {
        }

        /// <summary>
        /// Gets or sets the left parts of equations.
        /// </summary>
        public List<Expression> LeftPartEquations { get; set; }

        /// <summary>
        /// Gets or sets the right parts of equations.
        /// </summary>
        public List<double> RightPartEquations { get; set; }

        /// <summary>
        /// Gets or sets equations system variables.
        /// </summary>
        public List<Variable> Variables { get; set; }

        /// <summary>
        /// Gets or sets equations system constants.
        /// </summary>
        public List<Variable> Constants { get; set; }

        /// <summary>
        /// Gets or sets the matrix of the linear algebraicequation system.
        /// </summary>
        public MatrixT<double> Matrix { get; set; }

        /// <summary>
        /// Main method which provide calculations.
        /// </summary>
        /// <param name="lAEVariables">Output parameters where results will be saved.</param>
        /// <param name="calculationMethod">Calculation method.</param>
        /// <returns>How many solutions were foud.</returns>
        public LAEAnswer Calculate(out List<LAEVariable> lAEVariables, LAEMethod calculationMethod, List<IntermediateResult> intermediateResults = null)
        {
            CalculateDelegate func;
            switch (calculationMethod)
            {
                case LAEMethod.Gauss: func = this.CalculateGaussMethod; break;
                case LAEMethod.GaussAsync: func = this.CalculateGaussMethod; break;
                case LAEMethod.Kramer: func = this.CalculateKramerMethod; break;
                case LAEMethod.KramerAsync: func = this.CalculateKramerMethodAsync; break;
                case LAEMethod.Matrix: func = this.CalculateMatrixMethod; break;
                case LAEMethod.MatrixAsync: func = this.CalculateMatrixMethodAsync; break;

                default: throw new ArgumentException($"Could not identify an appropriate calculation method for {calculationMethod.ToString()} parameter.");
            }

            LAEAnswer result = func(out lAEVariables, intermediateResults);

            return result;
        }

        private delegate LAEAnswer CalculateDelegate(out List<LAEVariable> lAEVariables, List<IntermediateResult> intermediateResults = null);

        /// <summary>
        /// Method is used to chek if the input variables a correct and can be a solution for the system.
        /// </summary>
        /// <param name="allVariables">Input variables to check.</param>
        /// <returns>The the flag which represents if the proposed solution is correct.</returns>
        public bool CheckLinearAlgebraicEquationSystemResult(List<LAEVariable> allVariables)
        {
            for(int i = 0; i < this.LeftPartEquations.Count; i++)
            {
                if(this.LeftPartEquations[i].GetResultValue(allVariables.Cast<Variable>().ToList()) != this.RightPartEquations[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Method is used to check the compatibility of linear algebraic equation system.
        /// </summary>
        /// <returns>The flag which represents if this system is compatibile</returns>
        public bool CheckLinearAlgebraicEquationSystemCompatibility()
        {
            int matrixRank = MatrixT<double>.GetRang(this.Matrix);

            MatrixT<double> extendedMatrix = MatrixT<double>.ExtendMatrix(this.Matrix, this.RightPartEquations.ToArray());
            int extendedMatrixRank = MatrixT<double>.GetRang(extendedMatrix);

            if (matrixRank == extendedMatrixRank)
            {
                return true;
            }

            return false;
        }

        #region Helpers

        /// <summary>
        /// Method is used to set matrix of linear alebraic equation system.
        /// </summary>
        /// <param name="leftEquationsParts">parts of the left equations system.</param>
        /// <param name="variables">LAE system variables.</param>
        /// <param name="constants">LAE system constants.</param>
        /// <returns>matrix of the relevant linear alebraic equation system.</returns>
        private static MatrixT<double> SetMatrix(List<Expression> leftEquationsParts, List<Variable> variables, List<Variable> constants)
        {
            MatrixT<double> result = new MatrixT<double>(leftEquationsParts.Count, variables.Count);

            for (int i = 0; i < leftEquationsParts.Count; i++)
            {
                for (int j = 0; j < variables.Count; j++)
                {
                    List<Variable> currentVariables = variables;

                    LinearAlgebraicEquationSystem.SetVariablesWithValues(currentVariables, 0);
                    currentVariables[j].Value = 1.0;

                    if (constants != null && constants.Count > 0)
                    {
                        currentVariables.AddRange(constants);
                    }

                    result[i, j] = leftEquationsParts[i].GetResultValue(currentVariables);
                }
            }

            return result;
        }

        /// <summary>
        /// Method is used to set variable collection with one value.
        /// </summary>
        /// <param name="variables">Variables to set value.</param>
        /// <param name="value">Value to set.</param>
        private static void SetVariablesWithValues(List<Variable> variables, double value)
        {
            foreach(Variable variable in variables)
            {
                variable.Value = value;
            }
        }

        #endregion
    }
}
