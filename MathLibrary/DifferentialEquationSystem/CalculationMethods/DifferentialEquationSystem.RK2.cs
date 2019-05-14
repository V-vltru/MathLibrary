﻿namespace DifferentialEquationSystem
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Expressions.Models;

    public partial class DifferentialEquationSystem
    {      
        /// <summary>
        /// Method calculates a differential equation system with RK2 method
        /// </summary>
        /// <param name="variablesAtAllStep">Container where the intermediate parameters are supposed to be saved</param>
        /// <returns>List of result variables</returns>
        private List<DEVariable> RK2Sync(List<List<DEVariable>> variablesAtAllStep)
        {
            // Put left variables, constants and time variable in the one containier
            List<Variable> allVars;
            List<Variable> currentLeftVariables = new List<Variable>();
            List<Variable> halfStepVariables = new List<Variable>();
            List<Variable> nextLeftVariables = new List<Variable>();

            // Copy this.LeftVariables to the current one and to the nex one
            // To leave this.LeftVariables member unchanged (for further calculations)
            DifferentialEquationSystemHelpers.CopyVariables(this.LeftVariables, currentLeftVariables);
            DifferentialEquationSystemHelpers.CopyVariables(this.LeftVariables, halfStepVariables);
            DifferentialEquationSystemHelpers.CopyVariables(this.LeftVariables, nextLeftVariables);

            // Setting of current time (to leave this.TimeVariable unchanged)
            Variable currentTime = new Variable(this.TimeVariable);

            if (variablesAtAllStep != null)
            {
                // This is the first record for intermediate calculations containier
                // It has to be clear
                variablesAtAllStep.Clear();

                // Copying of the initial left variables to the separate list which when is going to "variablesAtAllStep" containier
                DifferentialEquationSystemHelpers.SaveLeftVariableToStatistics(variablesAtAllStep, this.LeftVariables, currentTime);
            }

            do
            {
                allVars = DifferentialEquationSystemHelpers.CollectVariables(currentLeftVariables, this.Constants, currentTime);

                for (int i = 0; i < halfStepVariables.Count; i++)
                {
                    halfStepVariables[i].Value = currentLeftVariables[i].Value + this.Tau / 2 * this.ExpressionSystem[i].GetResultValue(allVars);
                }

                allVars = DifferentialEquationSystemHelpers.CollectVariables(halfStepVariables, this.Constants,
                    new Variable(currentTime.Name, currentTime.Value + this.Tau / 2));

                double[] halfValues = new double[currentLeftVariables.Count];
                for (int i = 0; i < currentLeftVariables.Count; i++)
                {
                    halfValues[i] = this.ExpressionSystem[i].GetResultValue(allVars);
                }

                for (int i = 0; i < currentLeftVariables.Count; i++)
                {
                    nextLeftVariables[i].Value = currentLeftVariables[i].Value + this.Tau * halfValues[i];
                }

                // Saving of all variables at current iteration
                if (variablesAtAllStep != null)
                {
                    DifferentialEquationSystemHelpers.SaveLeftVariableToStatistics(variablesAtAllStep, nextLeftVariables, 
                        new Variable(currentTime.Name, currentTime.Value + this.Tau));
                }

                // Next variables are becoming the current ones for the next iteration
                DifferentialEquationSystemHelpers.CopyVariables(nextLeftVariables, currentLeftVariables);

                // calculation time incrimentation
                currentTime.Value += this.Tau;
            } while (currentTime.Value < this.TEnd);

            List<DEVariable> result = new List<DEVariable>();
            DifferentialEquationSystemHelpers.CopyVariables(currentLeftVariables, result);
            return result;
        }

        /// <summary>
        /// Method calculates a differential equation system with RK2 method
        /// </summary>
        /// <param name="variablesAtAllStep">Container where the intermediate parameters are supposed to be saved</param>
        /// <returns>List of result variables</returns>
        private List<DEVariable> RK2Async(List<List<DEVariable>> variablesAtAllStep)
        {
            // Put left variables, constants and time variable in the one containier
            List<Variable> allVars;
            List<Variable> currentLeftVariables = new List<Variable>();
            List<Variable> halfStepVariables = new List<Variable>();
            List<Variable> nextLeftVariables = new List<Variable>();

            // Copy this.LeftVariables to the current one and to the nex one
            // To leave this.LeftVariables member unchanged (for further calculations)
            DifferentialEquationSystemHelpers.CopyVariables(this.LeftVariables, currentLeftVariables);
            DifferentialEquationSystemHelpers.CopyVariables(this.LeftVariables, halfStepVariables);
            DifferentialEquationSystemHelpers.CopyVariables(this.LeftVariables, nextLeftVariables);

            // Setting of current time (to leave this.TimeVariable unchanged)
            Variable currentTime = new Variable(this.TimeVariable);

            if (variablesAtAllStep != null)
            {
                // This is the first record for intermediate calculations containier
                // It has to be clear
                variablesAtAllStep.Clear();

                // Copying of the initial left variables to the separate list which when is going to "variablesAtAllStep" containier
                DifferentialEquationSystemHelpers.SaveLeftVariableToStatistics(variablesAtAllStep, this.LeftVariables, currentTime);
            }

            do
            {
                allVars = DifferentialEquationSystemHelpers.CollectVariables(currentLeftVariables, this.Constants, currentTime);

                Parallel.For(0, halfStepVariables.Count, (i) =>
                {
                    halfStepVariables[i].Value = currentLeftVariables[i].Value + this.Tau / 2 * this.ExpressionSystem[i].GetResultValue(allVars);
                });

                allVars = DifferentialEquationSystemHelpers.CollectVariables(halfStepVariables, this.Constants,
                    new Variable(currentTime.Name, currentTime.Value + this.Tau / 2));

                double[] halfValues = new double[currentLeftVariables.Count];
                Parallel.For(0, currentLeftVariables.Count, (i) => 
                {
                    halfValues[i] = this.ExpressionSystem[i].GetResultValue(allVars);
                });

                Parallel.For(0, currentLeftVariables.Count, (i) => 
                {
                    nextLeftVariables[i].Value = currentLeftVariables[i].Value + this.Tau * halfValues[i];
                });

                // Saving of all variables at current iteration
                if (variablesAtAllStep != null)
                {
                    DifferentialEquationSystemHelpers.SaveLeftVariableToStatistics(variablesAtAllStep, nextLeftVariables,
                                            new Variable(currentTime.Name, currentTime.Value + this.Tau));
                }

                // Next variables are becoming the current ones for the next iteration
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
