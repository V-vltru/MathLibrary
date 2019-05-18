namespace Integral
{
    using System.Threading.Tasks;
    using Expressions;
    using Expressions.Models;

    public partial class Integral
    {
        public double CalcualtionRectangleAverage(Expression integrand, double startValue, double endValue, int numberOfSteps, string variableName)
        {
            double result = 0.0;
            double calculationStep = GetStep(startValue, endValue, numberOfSteps);

            Variable currentVariable = new Variable(variableName, startValue);

            for (int i = 0; i < numberOfSteps; i++)
            {
                currentVariable.Value += calculationStep / 2.0;
                result += calculationStep * integrand.GetResultValue(currentVariable);

                currentVariable.Value += calculationStep / 2.0;
            }

            return result;
        }

        public double CalcualtionRectangleAverageAsync(Expression integrand, double startValue, double endValue, int numberOfSteps, string variableName)
        {
            double result = 0.0;
            double calculationStep = GetStep(startValue, endValue, numberOfSteps);
            object obj = new object();

            Parallel.For(0, numberOfSteps, () => 0.0, (i, state, local) =>
            {
                local += integrand.GetResultValue(new Variable(variableName, startValue + (i + 0.5) * calculationStep));
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
