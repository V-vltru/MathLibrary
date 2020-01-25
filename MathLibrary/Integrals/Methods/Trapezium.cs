namespace Integral
{
    using Expressions.Models;
    using System.Threading.Tasks;

    public class Trapezium : Integral
    {
        public Trapezium(string integrandExpression, double startValue, double endValue, int iterations, string parameterName)
            :base(integrandExpression, startValue, endValue, iterations, parameterName)
        {
        }

        public Trapezium(IntegralInputParameters integralInputParameters)
            : base(integralInputParameters)
        {
        }

        public override double Calculate()
        {
            double result = 0.0;
            double calculationStep = Integral.GetStep(base.StartValue, base.EndValue, base.IterationsNumber);

            Variable currentVariable = new Variable(base.Variable.Name, base.StartValue + calculationStep);
            Variable prevVariable = new Variable(base.Variable.Name, base.StartValue);

            for (int i = 0; i < base.IterationsNumber; i++)
            {
                result += (base.Integrand.GetResultValue(currentVariable) + base.Integrand.GetResultValue(prevVariable)) / 2 * calculationStep;

                currentVariable.Value += calculationStep;
                prevVariable.Value += calculationStep;
            }

            return result;
        }

        public override double CalculateAsync()
        {
            double result = 0.0;
            double calculationStep = GetStep(base.StartValue, base.EndValue, base.IterationsNumber);
            object obj = new object();

            Parallel.For(0, base.IterationsNumber, () => 0.0, (i, state, local) =>
            {
                local += (base.Integrand.GetResultValue(new Variable(base.Variable.Name, base.StartValue + i * calculationStep)) +
                    base.Integrand.GetResultValue(new Variable(base.Variable.Name, base.StartValue + (i + 1) * calculationStep))) / 2;
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
