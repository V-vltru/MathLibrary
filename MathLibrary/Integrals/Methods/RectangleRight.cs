namespace Integral
{
    using Expressions.Models;
    using System.Threading.Tasks;

    public class RectangleRight : Integral
    {
        public RectangleRight(string integrandExpression, double startValue, double endValue, int iterations, string parameterName)
            :base(integrandExpression, startValue, endValue, iterations, parameterName)
        {
        }

        public RectangleRight(IntegralInputParameters integralInputParameters)
            : base(integralInputParameters)
        {
        }

        public override double Calculate()
        {
            double result = 0.0;
            double calculationStep = GetStep(base.StartValue, base.EndValue, base.IterationsNumber);

            Variable currentVariable = new Variable(base.Variable.Name, base.StartValue);

            currentVariable.Value += calculationStep;

            for (int i = 0; i < base.IterationsNumber; i++)
            {
                result += calculationStep * this.Integrand.GetResultValue(currentVariable);
                currentVariable.Value += calculationStep;
            }

            return result;
        }

        public override double CalculateAsync()
        {
            double result = 0.0;
            double calculationStep = GetStep(base.StartValue, base.EndValue, base.IterationsNumber);
            object obj = new object();

            Variable currentVariable = new Variable(base.Variable.Name, base.StartValue);

            currentVariable.Value += calculationStep;

            Parallel.For(0, base.IterationsNumber, () => 0.0, (i, state, local) =>
            {
                local += base.Integrand.GetResultValue(new Variable(currentVariable.Name, currentVariable.Value + i * calculationStep));
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
