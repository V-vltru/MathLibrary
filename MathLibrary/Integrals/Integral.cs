namespace Integral
{
    using System;
    using System.Collections.Generic;
    using Expressions;
    using Expressions.Models;

    public abstract class Integral
    {
        /// <summary>
        /// Gets or sets the integrand expression.
        /// </summary>
        public Expression Integrand { get; set; }
        
        /// <summary>
        /// Gets or sets the start value of a definite integral.
        /// </summary>
        public double StartValue { get; set; }

        /// <summary>
        /// Gets or sets the end value of a definite integral.
        /// </summary>
        public double EndValue { get; set; }

        /// <summary>
        /// Gets ot sets the amount of iterations for integrtal calculating.
        /// </summary>
        public int IterationsNumber { get; set; }

        /// <summary>
        /// A variable by which the integral is calculated.
        /// </summary>
        public IntegralVariable Variable { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Integral" /> class.
        /// Default constructor.
        /// </summary>
        public Integral()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Integral" /> class.
        /// </summary>
        /// <param name="integrandExpression">Integrand expression of the integral.</param>
        /// <param name="startValue">Start value of the definite integral.</param>
        /// <param name="endValue">End value of the definite integral.</param>
        /// <param name="iterations">Amount of iterations.</param>
        /// <param name="parameterName">Name of the variable by which the integral is calculated.</param>
        public Integral(string integrandExpression, double startValue, double endValue, int iterations, string parameterName)
        {
            this.Variable = new Variable(parameterName, 0.0);
            this.Integrand = new Expression(integrandExpression, new List<Variable>() { this.Variable });

            this.StartValue = startValue;
            this.EndValue = endValue;
            this.IterationsNumber = iterations;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Integral" /> class.
        /// </summary>
        /// <param name="integralInputParameters"></param>
        public Integral(IntegralInputParameters integralInputParameters)
            :this(integralInputParameters.IntegrandExpression,
                 integralInputParameters.StartValue,
                 integralInputParameters.EndValue,
                 integralInputParameters.IterationsNumber,
                 integralInputParameters.ParameterName)
        {
        }

        /// <summary>
        /// Method ia used to calculate a definite integral.
        /// </summary>
        public abstract double Calculate();

        /// <summary>
        /// Method ia used to calculate a definite integral in parallel mode.
        /// </summary>
        public abstract double CalculateAsync();

        /// <summary>
        /// Method is used to get the step according to an iterations number.
        /// </summary>
        /// <param name="startValue">Calculation start value.</param>
        /// <param name="endValue">Calculation end value.</param>
        /// <param name="iterationNumber">Iterations number.</param>
        /// <returns>the step length</returns>
        protected static double GetStep(double startValue, double endValue, int iterationNumber)
        {
            if (startValue > endValue)
            {
                throw new ArgumentException($"Parameter 'startValue' is greater than 'endValue' which is wrong! {startValue} > {endValue}");
            }

            if (iterationNumber <= 0)
            {
                throw new ArgumentException($"Parameter 'iterationNumber' is expected to be more than zero. Now it is {iterationNumber}");
            }

            return (endValue - startValue) / iterationNumber;
        }

        /// <summary>
        /// Method is used to get an appropriate Integral instance which implements a correct calculation method.
        /// </summary>
        /// <param name="calculationType">Calculation type.</param>
        /// <param name="integralInputParameters">Inegral input parameters</param>
        /// <returns>An appropriate integral instance.</returns>
        public static Integral GetIntegral(CalculationType calculationType, IntegralInputParameters integralInputParameters)
        {
            switch(calculationType)
            {
                case CalculationType.AverageRectangle: return new RectangleAverage(integralInputParameters);
                case CalculationType.LeftRectangle: return new RectangleLeft(integralInputParameters);
                case CalculationType.RightRectangle: return new RectangleRight(integralInputParameters);
                case CalculationType.Simpson: return new Simpson(integralInputParameters);
                case CalculationType.Trapezium: return new Trapezium(integralInputParameters);
                default: throw new Exception("Couldn't define an appropriate calculation method.");
            }
        }

        /// <summary>
        /// Gets an appropriate Integral instance which implements a correct calculation method.
        /// </summary>
        /// <param name="calculationType">Calculation type.</param>
        /// <returns>An appropriate integral instance.</returns>
        public static Integral GetIntegral(CalculationType calculationType)
        {
            return Integral.GetIntegral(calculationType, new IntegralInputParameters());
        }
    }
}
