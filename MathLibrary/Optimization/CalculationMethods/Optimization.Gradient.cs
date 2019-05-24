using Expressions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    public partial class Optimization
    {
        public int MaxIterationCount { get; set; } = 1000000;

        public List<OptimizationVariable> CalculateGradient(out double functionResult, double epselon, double lambda)
        {
            List<Variable> currentVariables = new List<Variable>();
            List<Variable> newVariables = new List<Variable>();

            for (int i = 0; i < this.StartVariables.Count; i++)
            {
                currentVariables.Add(new Variable(this.StartVariables[i].Name, this.StartVariables[i].Value));
                newVariables.Add(new Variable(this.StartVariables[i].Name, this.StartVariables[i].Value));
            }

            int currentIteration = 0;
            double oldValue, newValue;
            do
            {
                for (int i = 0; i < newVariables.Count; i++)
                {
                    currentVariables[i].Value += this.CalculationStep;
                    double upValue = this.Function.GetResultValue(currentVariables);

                    currentVariables[i].Value -= this.CalculationStep;
                    double downValue = this.Function.GetResultValue(currentVariables);

                    newVariables[i].Value -= lambda * (upValue - downValue) / this.CalculationStep;
                }

                oldValue = this.Function.GetResultValue(currentVariables);
                newValue = this.Function.GetResultValue(newVariables);

                for (int i = 0; i < currentVariables.Count; i++)
                {
                    currentVariables[i].Value = newVariables[i].Value;
                }

                currentIteration++;
            } while (currentIteration < this.MaxIterationCount && Math.Abs(newValue - oldValue) > epselon);

            List<OptimizationVariable> result = new List<OptimizationVariable>();
            for(int i = 0; i < currentVariables.Count; i++)
            {
                result.Add(new OptimizationVariable(currentVariables[i].Name, currentVariables[i].Value));
            }

            functionResult = newValue;
            return result;
        }
    }
}
