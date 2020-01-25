namespace Integral
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Expressions.Models;

    public class RectangleAverage: Integral
    {
        public RectangleAverage(string integrandExpression, double startValue, double endValue, int iterations, string parameterName)
            :base(integrandExpression, startValue, endValue, iterations, parameterName)
        {
        }

        public RectangleAverage(IntegralInputParameters integralInputParameters)
            :base(integralInputParameters)
        {
        }

        public override double Calculate()
        {
            double result = 0.0;
            double calculationStep = Integral.GetStep(base.StartValue, base.EndValue, base.IterationsNumber);

            Variable currentVariable = new Variable(base.Variable.Name, base.Variable.Value);

            for (int i = 0; i < base.IterationsNumber; i++)
            {
                currentVariable.Value += calculationStep / 2.0;
                result += calculationStep * base.Integrand.GetResultValue(currentVariable);

                currentVariable.Value += calculationStep / 2.0;
            }

            return result;
        }

        public override double CalculateAsync()
        {
            double result = 0.0;
            double calculationStep = Integral.GetStep(base.StartValue, base.EndValue, base.IterationsNumber);
            object obj = new object();

            Parallel.For(0, base.IterationsNumber, () => 0.0, (i, state, local) =>
            {
                local += base.Integrand.GetResultValue(new Variable(base.Variable.Name, base.StartValue + (i + 0.5) * calculationStep));
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
