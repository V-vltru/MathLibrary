using Expressions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integral
{
    public class RectangleLeft : Integral
    {
        public RectangleLeft(string integrandExpression, double startValue, double endValue, int iterations, string parameterName)
            :base(integrandExpression, startValue, endValue, iterations, parameterName)
        {
        }

        public RectangleLeft(IntegralInputParameters integralInputParameters)
            : base(integralInputParameters)
        {
        }

        public override double Calculate()
        {
            double result = 0.0;
            double calculationStep = GetStep(base.StartValue, base.EndValue, base.IterationsNumber);

            Variable currentVariable = new Variable(base.Variable.Name, base.StartValue);

            for (int i = 0; i < base.IterationsNumber; i++)
            {
                result += calculationStep * base.Integrand.GetResultValue(currentVariable);
                currentVariable.Value += calculationStep;
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
                local += base.Integrand.GetResultValue(new Variable(base.Variable.Name, base.StartValue + calculationStep * i));
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
