namespace Optimization
{
    using Expressions.Models;
    using System.Collections.Generic;

    public class OptimizationVariable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OptimizationVariable" /> class.
        /// </summary>
        /// <param name="name">Name of the init variable</param>
        /// <param name="value">Value of init variable</param>
        public OptimizationVariable(string name, double value)
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OptimizationVariable" /> class.
        /// </summary>
        /// <param name="integralVariable">Initial variable which is supposed to be copied to the current one</param>
        public OptimizationVariable(OptimizationVariable integralVariable)
        {
            this.Name = integralVariable.Name;
            this.Value = integralVariable.Value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OptimizationVariable" /> class.
        /// </summary>
        public OptimizationVariable()
        {
        }

        /// <summary>
        /// Gets or sets the name of the variable
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of the variable
        /// </summary>
        public double Value { get; set; }

        public static List<Variable> ConvertOptimizationVariablesToVariables(List<OptimizationVariable> lAEVariables)
        {
            List<Variable> result = new List<Variable>();

            foreach (OptimizationVariable lAEVariable in lAEVariables)
            {
                result.Add(new Variable(lAEVariable.Name, lAEVariable.Value));
            }

            return result;
        }

        public static List<OptimizationVariable> ConvertVariablesToOptimizationVariables(List<Variable> variables)
        {
            List<OptimizationVariable> result = new List<OptimizationVariable>();

            foreach (Variable variable in variables)
            {
                result.Add(new OptimizationVariable(variable.Name, variable.Value));
            }

            return result;
        }

        /// <summary>
        /// Method implicitly converts InitVariable instance to the Variable one
        /// </summary>
        /// <param name="integralVariable">InitVariable instance</param>
        public static implicit operator Variable(OptimizationVariable integralVariable)
        {
            if (integralVariable != null)
            {
                Variable result = new Variable(integralVariable.Name, integralVariable.Value);

                return result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Method implicitly converts Variable instance to the InitVariable one
        /// </summary>
        /// <param name="variable">Variable instance</param>
        public static implicit operator OptimizationVariable(Variable variable)
        {
            if (variable != null)
            {
                OptimizationVariable result = new OptimizationVariable(variable.Name, variable.Value);

                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
