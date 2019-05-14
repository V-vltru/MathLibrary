﻿namespace DifferentialEquationSystem
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Expressions.Models;

    public partial class DifferentialEquationSystem
    {
        /// <summary>
        /// Method calculates a differential equation system with Extrapolation Adams One method
        /// </summary>
        /// <param name="variablesAtAllStep">Container where the intermediate parameters are supposed to be saved</param>
        /// <returns>List of result variables</returns>
        private List<DEVariable> AdamsExtrapolationOneSync(List<List<DEVariable>> variablesAtAllStep = null)
        {
            #region Calculation preparation
            List<Variable> allVars;
            List<Variable> currentLeftVariables = new List<Variable>();
            List<Variable> nextLeftVariables = new List<Variable>();

            // Copy this.LeftVariables to the current one and to the nex one
            // To leave this.LeftVariables member unchanged (for further calculations)
            DifferentialEquationSystemHelpers.CopyVariables(this.LeftVariables, currentLeftVariables);
            DifferentialEquationSystemHelpers.CopyVariables(this.LeftVariables, nextLeftVariables);

            // Setting of current time (to leave this.TimeVariable unchanged)
            Variable currentTime = new Variable(this.TimeVariable);

            // If it is required to save intermediate calculations - save the start values
            if (variablesAtAllStep != null)
            {
                // This is the first record for intermediate calculations containier
                // It has to be clear
                variablesAtAllStep.Clear();
                DifferentialEquationSystemHelpers.SaveLeftVariableToStatistics(variablesAtAllStep, this.LeftVariables, currentTime);
            }
            #endregion

            #region First variables
            // Varables at "timestart + tau" is supposed to be calculated with other method
            // It was chosen to use Euler method
            // Generated a new instance for its calculation
            DifferentialEquationSystem differentialEquationSystem = new DifferentialEquationSystem(this.ExpressionSystem, this.LeftVariables, this.Constants,
                this.TimeVariable, this.TimeVariable.Value + this.Tau, this.Tau);           

            // Calculation
            List<Variable> firstLeftVariables;
            differentialEquationSystem.Calculate(CalculationTypeName.Euler, out List<DEVariable> bufer);
            firstLeftVariables = DifferentialEquationSystemHelpers.ConvertDEVariablesToVariables(bufer);

            // Save the second variables calculated with Euler method
            if (variablesAtAllStep != null)
            {
                DifferentialEquationSystemHelpers.SaveLeftVariableToStatistics(variablesAtAllStep, firstLeftVariables, new Variable(currentTime.Name, currentTime.Value + this.Tau));
            }
            #endregion

            allVars = DifferentialEquationSystemHelpers.CollectVariables(currentLeftVariables, this.Constants, currentTime);

            double[,] Q = new double[2, this.ExpressionSystem.Count];
            for (int i = 0; i < this.ExpressionSystem.Count; i++)
            {
                Q[0, i] = this.Tau * this.ExpressionSystem[i].GetResultValue(allVars);
            }

            currentTime.Value += this.Tau;
            allVars = DifferentialEquationSystemHelpers.CollectVariables(firstLeftVariables, this.Constants, currentTime);

            for (int i = 0; i < this.ExpressionSystem.Count; i++)
            {
                Q[1, i] = this.Tau * this.ExpressionSystem[i].GetResultValue(allVars);
            }

            do
            {
                for (int i = 0; i < nextLeftVariables.Count; i++)
                {
                    nextLeftVariables[i].Value = currentLeftVariables[i].Value + 0.5 * (3 * Q[1, i] - Q[0, i]);
                }

                allVars = DifferentialEquationSystemHelpers.CollectVariables(nextLeftVariables, this.Constants, new Variable(currentTime.Name, currentTime.Value + this.Tau));

                for (int i = 0; i < nextLeftVariables.Count; i++)
                {
                    Q[0, i] = Q[1, i];
                    Q[1, i] = this.Tau * this.ExpressionSystem[i].GetResultValue(allVars);
                }

                if (variablesAtAllStep != null)
                {
                    DifferentialEquationSystemHelpers.SaveLeftVariableToStatistics(variablesAtAllStep, nextLeftVariables, new Variable(currentTime.Name, currentTime.Value + this.Tau));
                }

                DifferentialEquationSystemHelpers.CopyVariables(nextLeftVariables, currentLeftVariables);

                // calculation time incrimentation
                currentTime.Value += this.Tau;
            } while (currentTime.Value < this.TEnd);

            List<DEVariable> result = new List<DEVariable>();
            DifferentialEquationSystemHelpers.CopyVariables(currentLeftVariables, result);
            return result;
        }

        /// <summary>
        /// Method calculates a differential equation system with Extrapolation Adams One method
        /// </summary>
        /// <param name="variablesAtAllStep">Container where the intermediate parameters are supposed to be saved</param>
        /// <returns>List of result variables</returns>
        private List<DEVariable> AdamsExtrapolationOneAsync(List<List<DEVariable>> variablesAtAllStep = null)
        {
            #region Calculation preparation
            List<Variable> allVars;
            List<Variable> currentLeftVariables = new List<Variable>();
            List<Variable> nextLeftVariables = new List<Variable>();

            // Copy this.LeftVariables to the current one and to the nex one
            // To leave this.LeftVariables member unchanged (for further calculations)
            DifferentialEquationSystemHelpers.CopyVariables(this.LeftVariables, currentLeftVariables);
            DifferentialEquationSystemHelpers.CopyVariables(this.LeftVariables, nextLeftVariables);

            // Setting of current time (to leave this.TimeVariable unchanged)
            Variable currentTime = new Variable(this.TimeVariable);

            // If it is required to save intermediate calculations - save the start values
            if (variablesAtAllStep != null)
            {
                // This is the first record for intermediate calculations containier
                // It has to be clear
                variablesAtAllStep.Clear();
                DifferentialEquationSystemHelpers.SaveLeftVariableToStatistics(variablesAtAllStep, this.LeftVariables, currentTime);
            }
            #endregion

            #region First variables
            // Varables at "timestart + tau" is supposed to be calculated with other method
            // It was chosen to use Euler method
            // Generated a new instance for its calculation
            DifferentialEquationSystem differentialEquationSystem = new DifferentialEquationSystem(this.ExpressionSystem, this.LeftVariables, this.Constants,
                this.TimeVariable, this.TimeVariable.Value + this.Tau, this.Tau);

            // Calculation
            List<Variable> firstLeftVariables;
            differentialEquationSystem.Calculate(CalculationTypeName.Euler, out List<DEVariable> bufer);
            firstLeftVariables = DifferentialEquationSystemHelpers.ConvertDEVariablesToVariables(bufer);

            // Save the second variables calculated with Euler method
            if (variablesAtAllStep != null)
            {
                DifferentialEquationSystemHelpers.SaveLeftVariableToStatistics(variablesAtAllStep, firstLeftVariables, new Variable(currentTime.Name, currentTime.Value + this.Tau));
            }
            #endregion

            allVars = DifferentialEquationSystemHelpers.CollectVariables(currentLeftVariables, this.Constants, currentTime);

            double[,] Q = new double[2, this.ExpressionSystem.Count];
            Parallel.For(0, this.ExpressionSystem.Count, (i) => 
            {
                Q[0, i] = this.Tau * this.ExpressionSystem[i].GetResultValue(allVars);
            });

            currentTime.Value += this.Tau;
            allVars = DifferentialEquationSystemHelpers.CollectVariables(firstLeftVariables, this.Constants, currentTime);

            Parallel.For(0, this.ExpressionSystem.Count, (i) => 
            {
                Q[1, i] = this.Tau * this.ExpressionSystem[i].GetResultValue(allVars);
            });

            do
            {
                Parallel.For(0, nextLeftVariables.Count, (i) => 
                {
                    nextLeftVariables[i].Value = currentLeftVariables[i].Value + 0.5 * (3 * Q[1, i] - Q[0, i]);
                });

                allVars = DifferentialEquationSystemHelpers.CollectVariables(nextLeftVariables, this.Constants, new Variable(currentTime.Name, currentTime.Value + this.Tau));

                Parallel.For(0, nextLeftVariables.Count, (i) => 
                {
                    Q[0, i] = Q[1, i];
                    Q[1, i] = this.Tau * this.ExpressionSystem[i].GetResultValue(allVars);
                });                

                if (variablesAtAllStep != null)
                {
                    DifferentialEquationSystemHelpers.SaveLeftVariableToStatistics(variablesAtAllStep, nextLeftVariables, new Variable(currentTime.Name, currentTime.Value + this.Tau));
                }

                DifferentialEquationSystemHelpers.CopyVariables(nextLeftVariables, currentLeftVariables);

                // calculation time incrimentation
                currentTime.Value += this.Tau;
            } while (currentTime.Value < this.TEnd);

            List<DEVariable> result = new List<DEVariable>();
            DifferentialEquationSystemHelpers.CopyVariables(currentLeftVariables, result);
            return result;
        }
    }
}
