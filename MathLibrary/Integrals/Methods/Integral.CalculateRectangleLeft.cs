namespace Integral
{
    using System.Threading.Tasks;
    using Expressions;
    using Expressions.Models;

    public partial class Integral
    {
        public double CalculateRectangleLeft(Expression integrand, double startValue, double endValue, int numberOfSteps, string variableName)
        {
            double result = 0.0;
            double calculationStep = GetStep(startValue, endValue, numberOfSteps);

            Variable currentVariable = new Variable(variableName, startValue);

            for (int i = 0; i < numberOfSteps; i++)
            {
                result += calculationStep * integrand.GetResultValue(currentVariable);
                currentVariable.Value += calculationStep;
            }

            return result;
        }

        public double CalculateRectangleLeftAsync(Expression integrand, double startValue, double endValue, int numberOfSteps, string variableName)
        {
            double result = 0.0;
            double calculationStep = GetStep(startValue, endValue, numberOfSteps);
            object obj = new object();

            Parallel.For(0, numberOfSteps, () => 0.0, (i, state, local) =>
            {
                local += integrand.GetResultValue(new Variable(variableName, startValue + calculationStep * i));
                return local;
            }, local =>
            {
                lock (obj)
                {
                    result += local;
                }
            });

            result *= calculationStep;
            return result;
        }
    }
}
