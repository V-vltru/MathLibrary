﻿namespace Expressions
{
    using System;
    using System.Collections.Generic;
    using Expressions.Models;

    public partial class Expression
    {
        /// <summary>
        /// Method is used to build the expression tree.
        /// </summary>
        /// <param name="parent">Parent leave.</param>
        /// <param name="expression">Expression string.</param>
        public void DefineLeaves(Tree parent, string expression)
        {
            string expressionPrev;
            do
            {
                expressionPrev = expression;
                expression = ExpressionParsingHelpers.RemoveWrappedBrackets(expression);
            }
            while (expression != expressionPrev);

            List<StandardFunction> funcs = new List<StandardFunction>();
            List<Operator> operators = this.GetOperators(expression, '-', '+');
            if (operators.Count == 0)
            {
                operators = this.GetOperators(expression, '*');

                if (operators.Count == 0)
                {
                    operators = this.GetOperators(expression, '/');

                    if (operators.Count == 0)
                    {
                        operators = this.GetOperators(expression, '^');
                        if (operators.Count == 0)
                        {
                            List<Interval> intervals = this.GetIntervals(expression);
                            funcs = this.GetStandardFunctions(expression, intervals);

                            if (funcs.Count == 0 && Variable.IsNumberOrVariable(expression, this.Variables) == EssenceType.Nothing)
                            {
                                throw new Exception("No operators, no functions, no variables were found in string: " + expression);
                            }
                        }
                    }
                }
            }

            EssenceType type;

            if (operators.Count > 1)
            {
                type = EssenceType.Cascade;
            }
            else if (operators.Count > 0)
            {
                type = EssenceType.Operator;
            }
            else if (funcs.Count > 0)
            {
                type = EssenceType.StandardFunction;
            }
            else if (Variable.IsNumberOrVariable(expression, this.Variables) != EssenceType.Nothing)
            {
                type = Variable.IsNumberOrVariable(expression, this.Variables);
            }
            else
            {
                throw new Exception("Can't determine type of operator/function/Variable/Number");
            }

            if (type == EssenceType.Operator)
            {
                parent.DataType = type;
                parent.Data = operators[0].OperatorName.ToString();
                parent.StringLeft = ExpressionParsingHelpers.COPY(expression, 0, operators[0].Index - 1);
                parent.StringRight = ExpressionParsingHelpers.COPY(expression, operators[0].Index + 1, expression.Length - 1);
                parent.LeftOperand = 0;
                parent.RightOperand = 0;
                parent.Cascade = null;
                parent.CascadeOperators = null;

                parent.LeftLeave = new Tree();
                parent.RightLeave = new Tree();

                this.DefineLeaves(parent.LeftLeave, parent.StringLeft);
                this.DefineLeaves(parent.RightLeave, parent.StringRight);
            }
            else if (type == EssenceType.StandardFunction)
            {
                parent.DataType = type;
                parent.Data = funcs[0].Name;
                parent.StringLeft = null;
                parent.StringRight = ExpressionParsingHelpers.COPY(expression, funcs[0].Index + funcs[0].Name.Length, expression.Length - 1);
                parent.LeftOperand = 0;
                parent.RightOperand = 0;
                parent.Cascade = null;
                parent.CascadeOperators = null;

                parent.LeftLeave = null;
                parent.RightLeave = new Tree();

                this.DefineLeaves(parent.RightLeave, parent.StringRight);
            }
            else if (type == EssenceType.Variable || type == EssenceType.Number)
            {
                parent.DataType = type;
                parent.Data = expression;
                parent.StringLeft = null;
                parent.StringRight = null;
                parent.LeftOperand = 0;
                parent.RightOperand = 0;
                parent.Cascade = null;
                parent.CascadeOperators = null;

                parent.LeftLeave = null;
                parent.RightLeave = null;
            }
            else if (type == EssenceType.Cascade)
            {
                parent.DataType = type;
                parent.Data = expression;
                parent.StringLeft = null;
                parent.StringRight = null;
                parent.LeftOperand = 0;
                parent.RightOperand = 0;

                parent.LeftLeave = null;
                parent.RightLeave = null;

                List<string> subExpressions = Operator.SplitExpressionByOperators(operators, expression);
                parent.Cascade = new List<Tree>();
                parent.CascadeOperators = operators;

                foreach (string subExpression in subExpressions)
                {
                    Tree subTree = new Tree();

                    this.DefineLeaves(subTree, subExpression);
                    parent.Cascade.Add(subTree);
                }
            }
        }
    }
}
