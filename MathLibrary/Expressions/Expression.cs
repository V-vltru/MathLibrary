namespace Expressions
{
    using System;
    using System.Collections.Generic;
    using Expressions.Models;

    public partial class Expression
    {
        /// <summary>
        /// Pointer to the parent Tree
        /// </summary>
        private Tree parent;

        /// <summary>
        /// Initializes a new instance of the <see cref="Expression" /> class.
        /// Constructor validates the input expression and defines the expression tree
        /// </summary>
        /// <param name="expression">Initial expression</param>
        /// <param name="variables">Initial variables for the expression.</param>
        public Expression(string expression, List<Variable> variables)
        {
            if (ExpressionParsingHelpers.CheckBracketBalance(expression))
            {
                this.parent = new Tree();
                this.Variables = variables;

                expression = ExpressionParsingHelpers.RemoveSpaces(expression);
                expression = ExpressionParsingHelpers.DeleteEmptyBrackets(expression);
                expression = ExpressionParsingHelpers.AddMinusOne(expression);

                this.ExpressionString = expression;
                this.DefineLeaves(this.parent, this.ExpressionString);
            }
            else
            {
                throw new Exception("Ballance of brackets is invalid");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Expression" /> class.
        /// Constructor validates the input expression and defines the expression tree
        /// </summary>
        /// <param name="expression">Initial expression</param>
        public Expression(string expression) : this(expression, new List<Variable>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Expression" /> class.
        /// </summary>
        public Expression()
        {
        }

        /// <summary>
        /// Gets expression as string to parse
        /// </summary>
        public string ExpressionString { get; }

        /// <summary>
        /// Gets or sets the standard functions of expression.
        /// </summary>
        public List<StandardFunction> StandardFunctions { get; set; }

        /// <summary>
        /// Gets or sets the list of variables in the expression
        /// </summary>
        public List<Variable> Variables { get; set; }

        /// <summary>
        /// Method is used to get the result of expression.
        /// </summary>
        /// <param name="variables">Current variables for getting results.</param>
        /// <returns>The expression result.</returns>
        public double GetResultValue(List<Variable> variables)
        {
            return this.GetExpressionResult(this.parent, variables);
        }

        /// <summary>
        /// Method is used to get the result of expression.
        /// </summary>
        /// <param name="variable">Current (one) variable for getting results.</param>
        /// <returns>The expression result.</returns>
        public double GetResultValue(Variable variable)
        {
            return this.GetExpressionResult(this.parent, new List<Variable> { variable });
        }
    }
}
