namespace Integral
{
    using Expressions.Models;
    using System.Threading.Tasks;

    public class Simpson : Integral
    {
        public Simpson(string integrandExpression, double startValue, double endValue, int iterations, string parameterName)
            :base(integrandExpression, startValue, endValue, iterations, parameterName)
        {
        }

        public Simpson(IntegralInputParameters integralInputParameters)
            : base(integralInputParameters)
        {
        }

        public override double Calculate()
        {
            double result = 0.0;
            double calculationStep = GetStep(base.StartValue, base.EndValue, base.IterationsNumber);

            Variable currentVariable = new Variable(base.Variable.Name, base.StartValue);

            result += base.Integrand.GetResultValue(currentVariable);
            for (int i = 1; i < base.IterationsNumber; i++)
            {
                currentVariable.Value += calculationStep;
                result += 2 * base.Integrand.GetResultValue(currentVariable);
            }

            currentVariable.Value += calculationStep;
            result += base.Integrand.GetResultValue(currentVariable);

            result *= calculationStep / 2.0;

            return result;
        }

        public override double CalculateAsync()
        {
            double result = 0.0;
            double calculationStep = GetStep(base.StartValue, base.EndValue, base.IterationsNumber);
            object obj = new object();

            result += base.Integrand.GetResultValue(new Variable(base.Variable.Name, base.StartValue));
            result += base.Integrand.GetResultValue(new Variable(base.Variable.Name, base.EndValue));

            Parallel.For(1, base.IterationsNumber, () => 0.0, (i, state, local) =>
            {
                local += 2 * base.Integrand.GetResultValue(new Variable(base.Variable.Name, base.StartValue + i * calculationStep));
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
