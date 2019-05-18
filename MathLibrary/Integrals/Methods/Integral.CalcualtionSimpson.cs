namespace Integral
{
    using System.Threading.Tasks;
    using Expressions;
    using Expressions.Models;

    public partial class Integral
    {
        public double CalcualtionSimpson(Expression integrand, double startValue, double endValue, int numberOfSteps, string variableName)
        {
            double result = 0.0;
            double calculationStep = GetStep(startValue, endValue, numberOfSteps);

            Variable currentVariable = new Variable(variableName, startValue);

            result += integrand.GetResultValue(currentVariable);
            for (int i = 1; i < numberOfSteps; i++)
            {
                currentVariable.Value += calculationStep;
                result += 2 * integrand.GetResultValue(currentVariable);
            }

            currentVariable.Value += calculationStep;
            result += integrand.GetResultValue(currentVariable);

            result *= calculationStep / 2.0;

            return result;
        }

        public double CalcualtionSimpsonAsync(Expression integrand, double startValue, double endValue, int numberOfSteps, string variableName)
        {
            double result = 0.0;
            double calculationStep = GetStep(startValue, endValue, numberOfSteps);
            object obj = new object();

            result += integrand.GetResultValue(new Variable(variableName, startValue));
            result += integrand.GetResultValue(new Variable(variableName, endValue));

            Parallel.For(1, numberOfSteps, () => 0.0, (i, state, local) =>
            {
                local += 2 * integrand.GetResultValue(new Variable(variableName, startValue + i * calculationStep));
                return local;
            }, local =>
            {
                lock (obj)
                {
                    result += local;
                }
            });

            result *= calculationStep / 2.0;
            return result;
        }
    }
}
