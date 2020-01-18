using System;
using System.Collections.Generic;
using DifferentialEquationSystem;
using LinearAlgebraicEquationsSystem;
using Integral;
using Expressions.Models;
using Expressions;
using Optimization;
using System.Diagnostics;

namespace SystemTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //VerifyExpressions();
            //VerifyIntegrals();
            //VerifyDifferentialEquations();
            //VerifyOptimization();

            //MatrixT<int> mat = new MatrixT<int>(new int[3, 4] { { 2, -1, 1, 1 }, { 1, 2, -1, 1 }, { 1, 7, -4, 2 } });
            //double det = MatrixT<int>.GetRang(mat);

            //Console.WriteLine(det);

            //MatrixT<int> mat2 = new MatrixT<int>(new int[3, 5] { { 2, -1, 1, 1, 1 }, { 1, 2, -1, 1, 2 }, { 1, 7, -4, 2, 5 } });
            //double det2 = MatrixT<int>.GetRang(mat2);

            //Console.WriteLine(det2);

            //MatrixT<double> mat3 = new MatrixT<double>(new double[3, 3] { { 2, 1, 1 }, { 1, -1, 0 }, { 3, -1, 2 } });
            //MatrixT<double> reversed = MatrixT<double>.GetInverseMatrix(mat3);

            //MatrixT<double> result = reversed * mat3;

            //for (int i = 0; i < reversed.Rows; i++)
            //{
            //    for (int j = 0; j < reversed.Columns; j++)
            //    {
            //        Console.Write(reversed[i, j] + " ");
            //    }

            //    Console.WriteLine();
            //}

            //MatrixT<double> c = 2 * mat3;

            List<string> leftParts = new List<string>
            {
                "2 * x1 + x2 + x3",
                "x1 - x2",
                "3 * x1 - x2 + 2 * x3"
            };

            List<LAEVariable> lAEVariables = new List<LAEVariable>
            {
                new LAEVariable("x1", 0),
                new LAEVariable("x2", 0),
                new LAEVariable("x3", 0)
            };

            List<double> rightParts = new List<double>
            {
                2, -2, 2
            };

            LinearAlgebraicEquationSystem linearAlgebraicEquationSystem = new LinearAlgebraicEquationSystem(leftParts, rightParts, lAEVariables, null);

            //linearAlgebraicEquationSystem.Calculate(out List<LAEVariable> res, LAEMethod.Matrix);
            //linearAlgebraicEquationSystem.Calculate(out List<LAEVariable> resMatrixAsync, LAEMethod.MatrixAsync);
            //linearAlgebraicEquationSystem.Calculate(out List<LAEVariable> res2, LAEMethod.Kramer);
            //linearAlgebraicEquationSystem.Calculate(out List<LAEVariable> resKramerAsync, LAEMethod.KramerAsync);

            List<IntermediateResult> intermediateResults = new List<IntermediateResult>();
            linearAlgebraicEquationSystem.Calculate(out List<LAEVariable> res3, LAEMethod.Gauss, intermediateResults);

            //List<LAEVariable> res = linearAlgebraicEquationSystem.CalculateMatrixMethod();
            //List<LAEVariable> resMatrixAsync = linearAlgebraicEquationSystem.CalculateMatrixMethodAsync();

            //List <LAEVariable> res2 = linearAlgebraicEquationSystem.CalculateKramerMethod();
            //List <LAEVariable> resKramerAsync = linearAlgebraicEquationSystem.CalculateKramerMethodAsync();

            //linearAlgebraicEquationSystem.CalculateGaussMethod(out List<LAEVariable> res3);

            Console.WriteLine("Completed");
            Console.ReadKey();
        }

        static void VerifyIntegrals()
        {
            string integrand = "x*x";
            double startValue = -1;
            double endValue = 1;
            int iterationsNumber = 1000;
            string parameterName = "x";

            Integral.Integral integral = new Integral.Integral(integrand, startValue, endValue, iterationsNumber, parameterName);
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            double resultLeftRectangle = integral.Calculate(CalculationType.LeftRectangle);
            stopwatch.Stop();
            double leftRectangleTime = stopwatch.ElapsedMilliseconds / 1000.0;
            stopwatch.Reset();

            stopwatch.Start();
            double resultLeftRectangleAsync = integral.Calculate(CalculationType.LeftRectangleAsync);
            stopwatch.Stop();
            double leftRectangleAsyncTime = stopwatch.ElapsedMilliseconds / 1000.0;
            stopwatch.Reset();

            stopwatch.Start();
            double resultRightRectangle = integral.Calculate(CalculationType.RightRectangle);
            stopwatch.Stop();
            double rightRectangleTime = stopwatch.ElapsedMilliseconds / 1000.0;
            stopwatch.Reset();

            stopwatch.Start();
            double resultRightRectangleAsync = integral.Calculate(CalculationType.RightRectangleAsync);
            stopwatch.Stop();
            double rightRectangleAsyncTime = stopwatch.ElapsedMilliseconds / 1000.0;
            stopwatch.Reset();

            stopwatch.Start();
            double resultAverageRectangle = integral.Calculate(CalculationType.AverageRectangle);
            stopwatch.Stop();
            double averageRectangleTime = stopwatch.ElapsedMilliseconds / 1000.0;
            stopwatch.Reset();

            stopwatch.Start();
            double resultAverageRectangleAsync = integral.Calculate(CalculationType.AverageRectangleAsync);
            stopwatch.Stop();
            double averageRectangleAsyncTime = stopwatch.ElapsedMilliseconds / 1000.0;
            stopwatch.Reset();

            stopwatch.Start();
            double resultTrapezium = integral.Calculate(CalculationType.Trapezium);
            stopwatch.Stop();
            double trapeziumTime = stopwatch.ElapsedMilliseconds / 1000.0;
            stopwatch.Reset();

            stopwatch.Start();
            double resultTrapeziumAsync = integral.Calculate(CalculationType.TrapeziumAsync);
            stopwatch.Stop();
            double trapeziumAsyncTime = stopwatch.ElapsedMilliseconds / 1000.0;
            stopwatch.Reset();

            stopwatch.Start();
            double resultSimpson = integral.Calculate(CalculationType.Simpson);
            stopwatch.Stop();
            double simpsonTime = stopwatch.ElapsedMilliseconds / 1000.0;
            stopwatch.Reset();

            stopwatch.Start();
            double resultSimpsonAsync = integral.Calculate(CalculationType.SimpsonAsync);
            stopwatch.Stop();
            double simpsonAsyncTime = stopwatch.ElapsedMilliseconds / 1000.0;
            stopwatch.Reset();

            List<CalculationType> calculationTypes = new List<CalculationType>
            {
                CalculationType.LeftRectangle,
                CalculationType.LeftRectangleAsync,
                CalculationType.RightRectangle,
                CalculationType.RightRectangleAsync,
                CalculationType.AverageRectangle,
                CalculationType.AverageRectangleAsync,
                CalculationType.Trapezium,
                CalculationType.TrapeziumAsync,
                CalculationType.Simpson,
                CalculationType.SimpsonAsync
            };

            Dictionary<CalculationType, double> results = new Dictionary<CalculationType, double>
            {
                { CalculationType.LeftRectangle, resultLeftRectangle },
                { CalculationType.LeftRectangleAsync, resultLeftRectangleAsync },
                { CalculationType.RightRectangle, resultRightRectangle },
                { CalculationType.RightRectangleAsync, resultRightRectangleAsync },
                { CalculationType.AverageRectangle, resultAverageRectangle },
                { CalculationType.AverageRectangleAsync, resultAverageRectangleAsync },
                { CalculationType.Trapezium, resultTrapezium },
                { CalculationType.TrapeziumAsync, resultTrapeziumAsync },
                { CalculationType.Simpson, resultSimpson },
                { CalculationType.SimpsonAsync, resultSimpsonAsync }
            };

            Dictionary<CalculationType, double> times = new Dictionary<CalculationType, double>
            {
                { CalculationType.LeftRectangle, leftRectangleTime },
                { CalculationType.LeftRectangleAsync, leftRectangleAsyncTime },
                { CalculationType.RightRectangle, rightRectangleTime },
                { CalculationType.RightRectangleAsync, rightRectangleAsyncTime },
                { CalculationType.AverageRectangle, averageRectangleTime },
                { CalculationType.AverageRectangleAsync, averageRectangleAsyncTime },
                { CalculationType.Trapezium, trapeziumTime },
                { CalculationType.TrapeziumAsync, trapeziumAsyncTime },
                { CalculationType.Simpson, simpsonTime },
                { CalculationType.SimpsonAsync, simpsonAsyncTime }
            };

            Reporting.IntegralReporter integralReporter = new Reporting.IntegralReporter(
                "D:\\IntegralReport.xls",
                integral,
                calculationTypes,
                times, 
                results);
            integralReporter.GenerateReport();

            Console.WriteLine($"Left rectangle: {resultLeftRectangle}");
            Console.WriteLine($"Left rectangle async: {resultLeftRectangleAsync}");
            Console.WriteLine($"Right rectangle: {resultRightRectangle}");
            Console.WriteLine($"Right rectangle async: {resultRightRectangleAsync}");
            Console.WriteLine($"Average rectangle: {resultAverageRectangle}");
            Console.WriteLine($"Average rectangle async: {resultAverageRectangleAsync}");
            Console.WriteLine($"Trapezium: {resultTrapezium}");
            Console.WriteLine($"Trapezium async: {resultTrapeziumAsync}");
            Console.WriteLine($"Simpson: {resultSimpson}");
            Console.WriteLine($"Simpson async: {resultSimpsonAsync}");
        }

        static void VerifyDifferentialEquations()
        {
            List<string> expressions = new List<string>
            {
                "2 * y1 - y + time * exp(time)",
                "y1"
            };

            List<DEVariable> leftVariables = new List<DEVariable>
            {
                new DEVariable("y", 2),
                new DEVariable("y1", 1),
            };

            DEVariable timeVariable = new DEVariable("time", 0);

            DifferentialEquationSystem.DifferentialEquationSystem differentialEquationSystem = new DifferentialEquationSystem.DifferentialEquationSystem(expressions, leftVariables, null, timeVariable, 1.5, 0.001);
            List<List<DEVariable>> perTime = new List<List<DEVariable>>();
            double calcTime = 0;
            List<DEVariable> resultEuler;
            calcTime = differentialEquationSystem.Calculate(CalculationTypeName.Euler, out resultEuler, perTime);

            double calcTimeForecast = 0;
            List<List<DEVariable>> perTimeForecast = new List<List<DEVariable>>();
            List<DEVariable> resultForecastCorrection;
            calcTimeForecast = differentialEquationSystem.Calculate(CalculationTypeName.ForecastCorrection, out resultForecastCorrection, perTimeForecast);

            double calcTimeRK2 = 0;
            List<List<DEVariable>> perTimeRK2 = new List<List<DEVariable>>();
            List<DEVariable> resultRK2;
            calcTimeRK2 = differentialEquationSystem.Calculate(CalculationTypeName.RK2, out resultRK2, perTimeRK2);

            double calcTimeRK4 = 0;
            List<List<DEVariable>> perTimeRK4 = new List<List<DEVariable>>();
            List<DEVariable> resultRK4;
            calcTimeRK4 = differentialEquationSystem.Calculate(CalculationTypeName.RK4, out resultRK4, perTimeRK4);

            double calcTimeAdams1 = 0;
            List<List<DEVariable>> perTimeAdams1 = new List<List<DEVariable>>();
            List<DEVariable> resultAdams1;
            calcTimeAdams1 = differentialEquationSystem.Calculate(CalculationTypeName.AdamsExtrapolationOne, out resultAdams1, perTimeAdams1);

            double calcTimeAdams2 = 0;
            List<List<DEVariable>> perTimeAdams2 = new List<List<DEVariable>>();
            List<DEVariable> resultAdams2;
            calcTimeAdams2 = differentialEquationSystem.Calculate(CalculationTypeName.AdamsExtrapolationTwo, out resultAdams2, perTimeAdams2);

            double calcTimeAdams3 = 0;
            List<List<DEVariable>> perTimeAdams3 = new List<List<DEVariable>>();
            List<DEVariable> resultAdams3;
            calcTimeAdams3 = differentialEquationSystem.Calculate(CalculationTypeName.AdamsExtrapolationThree, out resultAdams3, perTimeAdams3);

            double calcTimeAdams4 = 0;
            List<List<DEVariable>> perTimeAdams4 = new List<List<DEVariable>>();
            List<DEVariable> resultAdams4;
            calcTimeAdams4 = differentialEquationSystem.Calculate(CalculationTypeName.AdamsExtrapolationFour, out resultAdams4, perTimeAdams4);

            double calcTimeMiln = 0;
            List<List<DEVariable>> perTimeMiln = new List<List<DEVariable>>();
            List<DEVariable> resultMiln;
            calcTimeMiln = differentialEquationSystem.Calculate(CalculationTypeName.Miln, out resultMiln, perTimeMiln);

            #region CalculateWithGroupOfMethodsSync

            List<CalculationTypeName> calculationTypes = new List<CalculationTypeName>
            {
                CalculationTypeName.Euler,
                CalculationTypeName.EulerAsyc,
                CalculationTypeName.ForecastCorrection,
                CalculationTypeName.ForecastCorrectionAsync,
                CalculationTypeName.RK2,
                CalculationTypeName.RK2Async,
                CalculationTypeName.RK4,
                CalculationTypeName.RK4Async,
                CalculationTypeName.AdamsExtrapolationOne,
                CalculationTypeName.AdamsExtrapolationOneAsync,
                CalculationTypeName.AdamsExtrapolationTwo,
                CalculationTypeName.AdamsExtrapolationTwoAsync,
                CalculationTypeName.AdamsExtrapolationThree,
                CalculationTypeName.AdamsExtrapolationThreeAsync,
                CalculationTypeName.AdamsExtrapolationFour,
                CalculationTypeName.AdamsExtrapolationFourAsync,
                CalculationTypeName.Miln,
                CalculationTypeName.MilnAsync
            };

            Dictionary<CalculationTypeName, List<DEVariable>> results;
            Dictionary<CalculationTypeName, List<List<DEVariable>>> variablesAtAllSteps = new Dictionary<CalculationTypeName, List<List<DEVariable>>>();

            Dictionary<CalculationTypeName, double> calcTimes = differentialEquationSystem.CalculateWithGroupOfMethodsSync(calculationTypes, out results, variablesAtAllSteps);

            Reporting.DEReporter dEReporter = new Reporting.DEReporter(
                "D:\\DEResult1.xls",
                calculationTypes,
                calcTimes,
                results,
                variablesAtAllSteps,
                differentialEquationSystem);
            dEReporter.GenerateReport();

            //Reporting.GenerateExcelReport(calculationTypes, calcTimes, results, variablesAtAllSteps, "csharp-Excel.xls", differentialEquationSystem);
            #endregion
        }

        static void VerifyExpressions()
        {
            string expression = "2 * x - 3 * y + 5 * z";

            List<Variable> variables = new List<Variable>
            {
                new Variable("x", 0),
                new Variable("y", 0),
                new Variable("z", 1)
            };

            Expression exp = new Expression(expression, variables);
            double result = exp.GetResultValue(variables);

            Console.WriteLine(result);
            Console.ReadKey();
        }

        static void VerifyOptimization()
        {
            string function = "5*(x1 - 3)^2+(x2 - 5)^2";
            double step = 0.01;

            List<OptimizationVariable> startVariables = new List<OptimizationVariable>()
            {
                new OptimizationVariable("x1", 0),
                new OptimizationVariable("x2", 0)
            };

            List<OptimizationVariable> endVariables = new List<OptimizationVariable>()
            {
                new OptimizationVariable("x1", 3.1),
                new OptimizationVariable("x2", 5.1)
            };

            Optimization.Optimization optimization = new Optimization.Optimization(function, step, startVariables, endVariables);

            List<OptimizationVariable> result = optimization.CalculateBrouteForce(out double fRes);

            foreach(var item in result)
            {
                Console.WriteLine($"{item.Name}: {item.Value.ToString()}");
            }

            Console.WriteLine($"Result: {fRes}");

            List<OptimizationVariable> resultGradient = optimization.CalculateGradient(out double fGradRes, 0.000000001, 0.001);
            foreach (var item in resultGradient)
            {
                Console.WriteLine($"{item.Name}: {item.Value.ToString()}");
            }

            Console.WriteLine($"Result: {fGradRes}");

            List<OptimizationVariable> resultCoords = optimization.CalculateCoordinateSearch(out double fCoordRes, 0.00001);
            foreach (var item in resultCoords)
            {
                Console.WriteLine($"{item.Name}: {item.Value.ToString()}");
            }

            Console.WriteLine($"Result: {fCoordRes}");

            Console.ReadKey();
        }

        static void VerifyLAE()
        {
            List<string> leftParts = new List<string>
            {
                "2 * x1 + x2 + x3",
                "x1 - x2",
                "3 * x1 - x2 + 2 * x3"
            };

            List<LAEVariable> lAEVariables = new List<LAEVariable>
            {
                new LAEVariable("x1", 0),
                new LAEVariable("x2", 0),
                new LAEVariable("x3", 0)
            };

            List<double> rightParts = new List<double>
            {
                2, -2, 2
            };

            LinearAlgebraicEquationSystem linearAlgebraicEquationSystem = new LinearAlgebraicEquationSystem(leftParts, rightParts, lAEVariables, null);

            linearAlgebraicEquationSystem.Calculate(out List<LAEVariable> res, LAEMethod.Matrix);
            linearAlgebraicEquationSystem.Calculate(out List<LAEVariable> resMatrixAsync, LAEMethod.MatrixAsync);
            linearAlgebraicEquationSystem.Calculate(out List<LAEVariable> res2, LAEMethod.Kramer);
            linearAlgebraicEquationSystem.Calculate(out List<LAEVariable> resKramerAsync, LAEMethod.KramerAsync);
            linearAlgebraicEquationSystem.Calculate(out List<LAEVariable> res3, LAEMethod.Gauss);

            Console.ReadKey();
        }
    }
}
