﻿namespace DifferentialEquationSystem
{
    using System;
    using System.Collections.Generic;
    using Expressions;
    using Expressions.Models;

    public static class DifferentialEquationSystemHelpers
    {
        /// <summary>
        /// Method converts List<InitVariable> items to List<Variable> items
        /// </summary>
        /// <param name="initVariables">Instance of List<InitVariable></param>
        /// <returns>List of Variables</returns>
        public static List<Variable> ConvertDEVariablesToVariables(List<DEVariable> initVariables)
        {
            List<Variable> result = new List<Variable>();
            foreach (DEVariable initVariable in initVariables)
            {
                result.Add(initVariable);
            }

            return result;
        }

        /// <summary>
        /// Method converts List<Variable> items to List<InitVariable> items
        /// </summary>
        /// <param name="variables">Instance of List<InitVariable></param>
        /// <returns>List of Variables</returns>
        public static List<DEVariable> ConvertVariableToDEVariable(List<Variable> variables)
        {
            List<DEVariable> result = new List<DEVariable>();
            foreach (Variable variable in variables)
            {
                result.Add(variable);
            }

            return result;
        }

        /// <summary>
        /// Method validates initial parameters.
        /// It is recommended to invoke this method before differentail equation system calculation
        /// </summary>
        /// <param name="expressionSystem">List of expression of the differential equation system</param>
        /// <param name="leftVariables">List of left variables of the differential equation system</param>
        /// <param name="timeVariable">Time variable</param>
        /// <param name="Tau">Calculation step</param>
        /// <param name="tEnd">The end time of the calculation process</param>
        public static void CheckVariables(List<Expression> expressionSystem, List<Variable> leftVariables, Variable timeVariable,
            double Tau, double tEnd)
        {
            // Validation of the Expression list of the differential equation system
            if (expressionSystem == null || expressionSystem.Count == 0)
            {
                throw new ArgumentException("Container 'expressions' of the constructor cannot be null or empty! Nothing in the differential equation system.");
            }
            else if (expressionSystem.Count != leftVariables.Count)
            {
                throw new ArgumentException($"Number of expressions must be equal to the number of left variables! Number of expressions:{expressionSystem.Count}; Number of left variables: {leftVariables.Count}");
            }

            // Validation of the left variables of the differential equation system
            if (leftVariables == null || leftVariables.Count == 0)
            {
                throw new ArgumentException("Container 'leftVariables' of the constructor cannot be null or empty! Nothing in the left part.");
            }

            // Validation of the time parameter
            if (timeVariable == null)
            {
                throw new ArgumentNullException("Start time cannot be null!");
            }

            // Validation of the end time parameter
            if (timeVariable.Value > tEnd)
            {
                throw new ArgumentException($"End time should be more or equal than start one! Start time: {timeVariable.Value}; End time: {tEnd}");
            }

            // Validation of the calculation step
            if (Tau <= 0)
            {
                throw new ArgumentException($"Tau is required to be more than zero! Yours: {Tau}");
            }
            else if (Tau > tEnd - timeVariable.Value)
            {
                throw new ArgumentException($"Tau cannot be more than calculation interval! Tau: {Tau}; Start time: {timeVariable.Value}; End time: {tEnd}; Interval: {tEnd - timeVariable.Value}");
            }
        }

        #region Methods for List<InitVariables> / List<Variables> copying

        /// <summary>
        /// Method copies Variables from source containier to the destination one
        /// </summary>
        /// <param name="sourceVariables">Source list with Variables</param>
        /// <param name="destVariables">Destination list where Variables from source are expected to be copied to</param>
        public static void CopyVariables(List<Variable> sourceVariables, List<Variable> destVariables)
        {
            destVariables.Clear();
            foreach (Variable oneFromSource in sourceVariables)
            {
                destVariables.Add(new Variable(oneFromSource));
            }
        }

        public static void CopyVariables(List<DEVariable> sourceVariables, List<Variable> destVariables)
        {
            destVariables.Clear();
            foreach (DEVariable oneFromSource in sourceVariables)
            {
                destVariables.Add(new Variable(oneFromSource));
            }
        }

        public static void CopyVariables(List<Variable> sourceVariables, List<DEVariable> destVariables)
        {
            destVariables.Clear();
            foreach (Variable oneFromSource in sourceVariables)
            {
                destVariables.Add(new DEVariable(oneFromSource));
            }
        }

        public static void CopyVariables(List<DEVariable> sourceVariables, List<DEVariable> destVariables)
        {
            destVariables.Clear();
            foreach (DEVariable oneFromSource in sourceVariables)
            {
                destVariables.Add(new DEVariable(oneFromSource));
            }
        }

        #endregion

        /// <summary>
        /// Method saves current left variables and current time to statistics
        /// </summary>
        /// <param name="statistics">Container where left variables for each time are saved</param>
        /// <param name="leftVariables">Current left variables</param>
        /// <param name="currentTime">Current time</param>
        public static void SaveLeftVariableToStatistics(List<List<DEVariable>> statistics, List<Variable> leftVariables, Variable currentTime)
        {
            if (statistics != null)
            {
                // Copying of the initial left variables to the separate list which when is going to "variablesAtAllStep" containier
                List<DEVariable> initLeftVariables = new List<DEVariable>();
                CopyVariables(leftVariables, initLeftVariables);

                // Current time is also required to be saved in the intermediate vlues
                initLeftVariables.Add(new DEVariable(currentTime));
                statistics.Add(initLeftVariables);
            }
        }

        /// <summary>
        /// Method collects left variables, constants and time parameter into one containier
        /// </summary>
        /// <param name="leftVariables">Left variables</param>
        /// <param name="constants">Constants</param>
        /// <param name="time">Time parameters</param>
        /// <returns>Container which contains left variables, constants and time parameter</returns>
        public static List<Variable> CollectVariables(List<Variable> leftVariables, List<Variable> constants, Variable time)
        {
            List<Variable> allVars = new List<Variable>();
            allVars.AddRange(leftVariables);
            if (constants != null)
            {
                if (constants.Count > 0)
                {
                    allVars.AddRange(constants);
                }
            }

            allVars.Add(time);
            return allVars;
        }
    }
}
