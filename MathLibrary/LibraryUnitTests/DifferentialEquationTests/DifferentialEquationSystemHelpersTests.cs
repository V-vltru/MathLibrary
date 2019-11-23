namespace LibraryUnitTests.DifferentialEquationTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DifferentialEquationSystem;
    using Expressions.Models;
    using Expressions;

    [TestClass]
    public class DifferentialEquationSystemHelpersTests
    {
        private static List<string> expressions = new List<string>
        {
            "2 * y1 - y + time * exp(time)",
            "y1"
        };

        private static List<DEVariable> leftDEVariables = new List<DEVariable>
        {
            new DEVariable("y", 2),
            new DEVariable("y1", 1)
        };

        private static List<Variable> leftVariables = new List<Variable>
        {
            new Variable("y", 2),
            new Variable("y1", 1)
        };

        private static DEVariable timeVariable = new DEVariable("time", 0);
        private static double tEnd = 1.5;
        private static double tau = 0.001;

        private static DifferentialEquationSystem differentialEquationSystem = 
            new DifferentialEquationSystem(
                expressions,
                leftDEVariables,
                null,
                timeVariable,
                tEnd,
                tau);

        private static void VerifyCollections(List<DEVariable> expectedCollection, List<DEVariable> actualCollection)
        {
            if (expectedCollection.Count != actualCollection.Count)
            {
                throw new Exception("Collections have different count of items.");
            }

            for (int i = 0; i < expectedCollection.Count; i++)
            {
                Assert.AreEqual(expectedCollection[i].Name, actualCollection[i].Name);
                Assert.AreEqual(expectedCollection[i].Value, actualCollection[i].Value);
            }
        }

        private static void VerifyCollections(List<Variable> expectedCollection, List<Variable> actualCollection)
        {
            if (expectedCollection.Count != actualCollection.Count)
            {
                throw new Exception("Collections have different count of items.");
            }

            for (int i = 0; i < expectedCollection.Count; i++)
            {
                Assert.AreEqual(expectedCollection[i].Name, actualCollection[i].Name);
                Assert.AreEqual(expectedCollection[i].Value, actualCollection[i].Value);
            }
        }

        private static void VerifyCollections(List<DEVariable> expectedCollection, List<Variable> actualCollection)
        {
            if (expectedCollection.Count != actualCollection.Count)
            {
                throw new Exception("Collections have different count of items.");
            }

            for (int i = 0; i < expectedCollection.Count; i++)
            {
                Assert.AreEqual(expectedCollection[i].Name, actualCollection[i].Name);
                Assert.AreEqual(expectedCollection[i].Value, actualCollection[i].Value);
            }
        }

        private static void VerifyCollections(List<Variable> expectedCollection, List<DEVariable> actualCollection)
        {
            if (expectedCollection.Count != actualCollection.Count)
            {
                throw new Exception("Collections have different count of items.");
            }

            for (int i = 0; i < expectedCollection.Count; i++)
            {
                Assert.AreEqual(expectedCollection[i].Name, actualCollection[i].Name);
                Assert.AreEqual(expectedCollection[i].Value, actualCollection[i].Value);
            }
        }

        [TestMethod]
        public void TestConvertDEVariablesToVariables()
        {
            List<DEVariable> variables = new List<DEVariable>
            {
                new DEVariable("a", 1),
                new DEVariable("b", 2),
                new DEVariable("c", 3)
            };

            List<Variable> expectedVariables = new List<Variable>
            {
                new Variable("a", 1),
                new Variable("b", 2),
                new Variable("c", 3)
            };

            List<Variable> actualVariables = DifferentialEquationSystemHelpers.ConvertDEVariablesToVariables(variables);

            for (int i = 0; i < actualVariables.Count; i++)
            {
                Assert.AreEqual(expectedVariables[i].Name, actualVariables[i].Name);
                Assert.AreEqual(expectedVariables[i].Value, actualVariables[i].Value);
            }
        }

        [TestMethod]
        public void TestConvertVariableToDEVariable()
        {
            List<Variable> variables = new List<Variable>
            {
                new Variable("a", 1),
                new Variable("b", 2),
                new Variable("c", 3)
            };

            List<DEVariable> expectedVariables = new List<DEVariable>
            {
                new DEVariable("a", 1),
                new DEVariable("b", 2),
                new DEVariable("c", 3)
            };

            List<DEVariable> actualVariables = DifferentialEquationSystemHelpers.ConvertVariableToDEVariable(variables);

            for (int i = 0; i < actualVariables.Count; i++)
            {
                Assert.AreEqual(expectedVariables[i].Name, actualVariables[i].Name);
                Assert.AreEqual(expectedVariables[i].Value, actualVariables[i].Value);
            }
        }

        [TestMethod]
        public void TestCheckVariablesAllCorrect()
        {
            DifferentialEquationSystemHelpers.CheckVariables(
                differentialEquationSystem.ExpressionSystem,
                differentialEquationSystem.LeftVariables,
                differentialEquationSystem.TimeVariable,
                differentialEquationSystem.Tau,
                differentialEquationSystem.TEnd);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Container 'expressions' of the constructor cannot be null or empty!Nothing in the differential equation system.")]
        public void TestCheckVariablesExpressionNull()
        {
            DifferentialEquationSystemHelpers.CheckVariables(
                null,
                differentialEquationSystem.LeftVariables,
                differentialEquationSystem.TimeVariable,
                differentialEquationSystem.Tau,
                differentialEquationSystem.TEnd);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Container 'expressions' of the constructor cannot be null or empty!Nothing in the differential equation system.")]
        public void TestCheckVariablesExpressionEmpty()
        {
            DifferentialEquationSystemHelpers.CheckVariables(
                new List<Expression>(),
                differentialEquationSystem.LeftVariables,
                differentialEquationSystem.TimeVariable,
                differentialEquationSystem.Tau,
                differentialEquationSystem.TEnd);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Container 'leftVariables' of the constructor cannot be null or empty! Nothing in the left part.")]
        public void TestCheckVariablesVariableNull()
        {
            DifferentialEquationSystemHelpers.CheckVariables(
                differentialEquationSystem.ExpressionSystem,
                null,
                differentialEquationSystem.TimeVariable,
                differentialEquationSystem.Tau,
                differentialEquationSystem.TEnd);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Container 'leftVariables' of the constructor cannot be null or empty! Nothing in the left part.")]
        public void TestCheckVariablesVariableEmpty()
        {
            DifferentialEquationSystemHelpers.CheckVariables(
                differentialEquationSystem.ExpressionSystem,
                new List<Variable>(),
                differentialEquationSystem.TimeVariable,
                differentialEquationSystem.Tau,
                differentialEquationSystem.TEnd);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Number of expressions must be equal to the number of left variables! Number of expressions: 2; Number of left variables: 3")]
        public void TestCheckVariablesExpressionNotEqualVariables()
        {
            List<Variable> vars = new List<Variable>();
            DifferentialEquationSystemHelpers.CopyVariables(differentialEquationSystem.LeftVariables, vars);
            vars.Add(new Variable("x1", 8));

            DifferentialEquationSystemHelpers.CheckVariables(
                differentialEquationSystem.ExpressionSystem,
                vars,
                differentialEquationSystem.TimeVariable,
                differentialEquationSystem.Tau,
                differentialEquationSystem.TEnd);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Start time cannot be null!")]
        public void TestCheckVariablesTimeVariableNull()
        {
            DifferentialEquationSystemHelpers.CheckVariables(
                differentialEquationSystem.ExpressionSystem,
                differentialEquationSystem.LeftVariables,
                null,
                differentialEquationSystem.Tau,
                differentialEquationSystem.TEnd);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "End time should be more or equal than start one! Start time: 100; End time: 1.5")]
        public void TestCheckVariablesTimeVariableMoreThanTEnd()
        {
            DifferentialEquationSystemHelpers.CheckVariables(
                differentialEquationSystem.ExpressionSystem,
                differentialEquationSystem.LeftVariables,
                new Variable("time", 100),
                differentialEquationSystem.Tau,
                differentialEquationSystem.TEnd);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Tau is required to be more than zero! Yours: -100")]
        public void TestCheckVariablesTauLessThanZero()
        {
            DifferentialEquationSystemHelpers.CheckVariables(
                differentialEquationSystem.ExpressionSystem,
                differentialEquationSystem.LeftVariables,
                differentialEquationSystem.TimeVariable,
                -100,
                differentialEquationSystem.TEnd);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "")]
        public void TestCheckVariablesTauMoreThanInterval()
        {
            DifferentialEquationSystemHelpers.CheckVariables(
                differentialEquationSystem.ExpressionSystem,
                differentialEquationSystem.LeftVariables,
                differentialEquationSystem.TimeVariable,
                100,
                differentialEquationSystem.TEnd);
        }

        [TestMethod]
        public void TestCopyVariables()
        {
            List<DEVariable> expectedResult = new List<DEVariable>
            {
                new DEVariable(leftDEVariables[0].Name, leftDEVariables[0].Value),
                new DEVariable(leftDEVariables[1].Name, leftDEVariables[1].Value)
            };

            List<DEVariable> actualResult = new List<DEVariable>();
            DifferentialEquationSystemHelpers.CopyVariables(leftDEVariables, actualResult);

            VerifyCollections(expectedResult, actualResult);

            List<Variable> secondActualResult = new List<Variable>();
            DifferentialEquationSystemHelpers.CopyVariables(leftDEVariables, secondActualResult);

            VerifyCollections(expectedResult, secondActualResult);

            List<DEVariable> thirdActualResult = new List<DEVariable>();
            DifferentialEquationSystemHelpers.CopyVariables(leftDEVariables, thirdActualResult);

            VerifyCollections(leftDEVariables, thirdActualResult);

            List<Variable> forthActualResult = new List<Variable>();
            DifferentialEquationSystemHelpers.CopyVariables(leftDEVariables, forthActualResult);

            VerifyCollections(leftDEVariables, forthActualResult);
        }

        [TestMethod]
        public void TestSaveLeftVariableToStatistics()
        {
            List<List<DEVariable>> expectedStatistics = new List<List<DEVariable>>();
            List<List<DEVariable>> actualStatistics = new List<List<DEVariable>>();
            List<DEVariable> expectedResult = new List<DEVariable>
            {
                new DEVariable(leftDEVariables[0].Name, leftDEVariables[0].Value),
                new DEVariable(leftDEVariables[1].Name, leftDEVariables[1].Value),
                new DEVariable("time", 0)
            };

            expectedStatistics.Add(expectedResult);

            DifferentialEquationSystemHelpers.SaveLeftVariableToStatistics(
                actualStatistics,
                leftVariables,
                new DEVariable("time", 0));

            VerifyCollections(expectedStatistics[0], actualStatistics[0]);
        }

        [TestMethod]
        public void TestCollectVariables()
        {
            List<Variable> constants = new List<Variable>
            {
                new Variable("w", 10),
                new Variable("r", 100)
            };

            List<Variable> expectedResult = new List<Variable>();
            expectedResult.AddRange(leftVariables);
            expectedResult.AddRange(constants);
            expectedResult.Add(new Variable("time", 0));

            List<Variable> actualVariable = DifferentialEquationSystemHelpers.CollectVariables(leftVariables, constants, new Variable("time", 0));

            VerifyCollections(expectedResult, actualVariable);
        }
    }
}
