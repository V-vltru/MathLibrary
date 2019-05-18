namespace Integral
{
    using System.Threading.Tasks;
    using Expressions;
    using Expressions.Models;

    public partial class Integral
    {
        public double CalculationRectangleRight(Expression integrand, double startValue, double endValue, int numberOfSteps, string variableName)
        {
            double result = 0.0;
            double calculationStep = GetStep(startValue, endValue, numberOfSteps);

            Variable currentVariable = new Variable(variableName, startValue);

            currentVariable.Value += calculationStep;

            for (int i = 0; i < numberOfSteps; i++)
            {
                result += calculationStep * integrand.GetResultValue(currentVariable);
                currentVariable.Value += calculationStep;
            }

            return result;
        }

        public double CalculationRectangleRightAsync(Expression integrand, double startValue, double endValue, int numberOfSteps, string variableName)
        {
            double result = 0.0;
            double calculationStep = GetStep(startValue, endValue, numberOfSteps);
            object obj = new object();

            Variable currentVariable = new Variable(variableName, startValue);

            currentVariable.Value += calculationStep;

            Parallel.For(0, numberOfSteps, () => 0.0, (i, state, local) =>
            {
                local += integrand.GetResultValue(new Variable(currentVariable.Name, currentVariable.Value + i * calculationStep));
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
