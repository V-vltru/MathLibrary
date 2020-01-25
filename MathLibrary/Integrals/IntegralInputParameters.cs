namespace Integral
{
    public class IntegralInputParameters
    {
        public IntegralInputParameters(string integrandExpression, double startValue, double endValue, int iterations, string parameterName)
        {
            this.IntegrandExpression = integrandExpression;
            this.StartValue = startValue;
            this.EndValue = endValue;
            this.IterationsNumber = iterations;
            this.ParameterName = parameterName;
        }

        public IntegralInputParameters()
        {
        }

        /// <summary>
        /// Gets or sets the integrand expression.
        /// </summary>
        public string IntegrandExpression { get; set; }

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
        /// Integral parameter name.
        /// </summary>
        public string ParameterName { get; set; }
    }
}
