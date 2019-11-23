﻿namespace LibraryUnitTests.ExpressionsTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Expressions.Models;
    using System.Collections.Generic;

    [TestClass]
    public class ModelsTests
    {
        [TestMethod]
        public void IntervalTest()
        {
            int[] begin = new int[] { 1, 0, -1 };
            int[] end = new int[] { 2, 0, 2 };

            for (int i = 0; i < begin.Length; i++)
            {
                Interval interval = new Interval(begin[i], end[i]);

                Assert.AreEqual(begin[i], interval.IndexFrom);
                Assert.AreEqual(end[i], interval.IndexTo);
            }
        }

        [TestMethod]
        public void IntervalBelongsToIntevalsTest()
        {
            List<Interval> intervals = new List<Interval>
            {
                new Interval(0, 3),
                new Interval(10, 14)
            };

            int[] idxsInInervals = new int[] { 0, 1, 3, 10, 11, 14 };
            int[] idxsOutIntervals = new int[] { -1, 4, 7, 15 };

            foreach (int idx in idxsInInervals)
            {
                Assert.AreEqual(true, Interval.BelongsToIntevals(idx, intervals));
            }

            foreach (int idx in idxsOutIntervals)
            {
                Assert.AreEqual(false, Interval.BelongsToIntevals(idx, intervals));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Operator % is not accessable. Here is the list of allowable operators: \n+\n-\n+\n*\n/\n^")]
        public void OperatorTest()
        {
            List<char> trueOperators = new List<char>
            {
                '+', '-', '*', '/', '^'
            };

            char falseOperator = '%';
            int k = 0;
            foreach (char trueOne in trueOperators)
            {
                Operator op = new Operator(k, trueOne);

                Assert.AreEqual(k, op.Index);
                Assert.AreEqual(trueOne, op.OperatorName);
                k++;
            }

            Operator exceptionOp = new Operator(0, falseOperator);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Operator % is not accessable. Here is the list of allowable operators: \n+\n-\n+\n*\n/\n^")]
        public void OpeartorGetValueTest()
        {
            List<char> trueOperators = new List<char>
            {
                '+', '-', '*', '/', '^'
            };

            char falseOperator = '%';

            int a = 8, b = 4;

            Assert.AreEqual(12, Operator.GetValue(a, b, '+'));
            Assert.AreEqual(4, Operator.GetValue(a, b, '-'));
            Assert.AreEqual(32, Operator.GetValue(a, b, '*'));
            Assert.AreEqual(2, Operator.GetValue(a, b, '/'));
            Assert.AreEqual(4096, Operator.GetValue(a, b, '^'));

            Operator.GetValue(1, 2, falseOperator);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void StandardFunctionTest()
        {
            int idx = 0;

            List<string> trueFunctions = new List<string>
            {
                "sin", "cos", "tan", "log", "ln", "exp"
            };

            string falseOne = "abs";

            foreach (string trueFunction in trueFunctions)
            {
                StandardFunction standardFunction = new StandardFunction(idx, trueFunction);

                Assert.AreEqual(idx, standardFunction.Index);
                Assert.AreEqual(trueFunction, standardFunction.Name);
            }

            StandardFunction fakeFunction = new StandardFunction(idx, falseOne);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void StandardFunctionGetResultTest()
        {
            double value = 0.5;

            Assert.AreEqual(Math.Sin(value), StandardFunction.GetResultOfStandardFunction(value, "sin"));
            Assert.AreEqual(Math.Cos(value), StandardFunction.GetResultOfStandardFunction(value, "cos"));
            Assert.AreEqual(Math.Tan(value), StandardFunction.GetResultOfStandardFunction(value, "tan"));
            Assert.AreEqual(Math.Log10(value), StandardFunction.GetResultOfStandardFunction(value, "log"));
            Assert.AreEqual(Math.Log(value), StandardFunction.GetResultOfStandardFunction(value, "ln"));
            Assert.AreEqual(Math.Exp(value), StandardFunction.GetResultOfStandardFunction(value, "exp"));

            StandardFunction.GetResultOfStandardFunction(value, "abs");
        }

        [TestMethod]
        public void VariableTest()
        {
            string[] varNames = new string[] { "a", "b", "c", "wq", "1q", "-0,d" };
            double[] varValues = new double[] { 1, 0, 0.1, -4, 123123, 980123411 };

            for (int i = 0; i < varNames.Length; i++)
            {
                Variable variable = new Variable(varNames[i], varValues[i]);

                Assert.AreEqual(varNames[i], variable.Name);
                Assert.AreEqual(varValues[i], variable.Value);
            }
        }

        [TestMethod]
        public void Variable_IsNumberOrVariableTest()
        {
            List<Variable> vars = new List<Variable>
            {
                new Variable("a", 1),
                new Variable("b", 2),
                new Variable("c", 3)
            };

            List<string> numbers = new List<string>
            {
                "1", "-1", "1,0002", "10,01"
            };

            List<string> nothings = new List<string>
            {
                "d", "d-1", "-123a", "124b"
            };


            foreach (Variable var in vars)
            {
                Assert.AreEqual(EssenceType.Variable, Variable.IsNumberOrVariable(var.Name, vars));
            }

            foreach (string number in numbers)
            {
                Assert.AreEqual(EssenceType.Number, Variable.IsNumberOrVariable(number, vars));
            }

            foreach (string nothing in nothings)
            {
                Assert.AreEqual(EssenceType.Nothing, Variable.IsNumberOrVariable(nothing, vars));
            }
        }

        [TestMethod]
        public void VariableGetVariableValueTest()
        {
            List<Variable> variables = new List<Variable>
            {
                new Variable("a", 1),
                new Variable("b", 2)
            };

            foreach (Variable var in variables)
            {
                Assert.AreEqual(var.Value, Variable.GetVariableValue(var.Name, variables));
            }

            string notFoundErrorMessage = "Variable c wasn't found in the list of variables";
            string fakeVarName = "c";

            try
            {
                Variable.GetVariableValue(fakeVarName, variables);
            }
            catch (Exception e)
            {
                Assert.AreEqual(notFoundErrorMessage, e.Message);
            }

            string duplicateVar = "a";
            variables.Add(new Variable("a", 5));
            string duplicateErrorMessage = "There are several variables with this name: a";

            try
            {
                Variable.GetVariableValue(duplicateVar, variables);
            }
            catch (Exception e)
            {
                Assert.AreEqual(duplicateErrorMessage, e.Message);
            }
        }

        [TestMethod]
        public void TreeTest()
        {
            string data = "a+b";
            EssenceType dataType = EssenceType.Operator;
            double leftOperand = -1;
            double rightOperand = 3;
            string stringLeft = "a";
            string stringRight = "b";

            Tree tree = new Tree(data, dataType, leftOperand, rightOperand, stringLeft, stringRight);

            Assert.AreEqual(data, tree.Data);
            Assert.AreEqual(dataType, tree.DataType);
            Assert.AreEqual(leftOperand, tree.LeftOperand);
            Assert.AreEqual(rightOperand, tree.RightOperand);
            Assert.AreEqual(stringLeft, tree.StringLeft);
            Assert.AreEqual(stringRight, tree.StringRight);
        }
    }
}
