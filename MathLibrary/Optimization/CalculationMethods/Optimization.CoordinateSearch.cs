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
        public List<OptimizationVariable> CalculateCoordinateSearch(out double functionResult, double epselon)
        {
            List<Variable> currentVariables = new List<Variable>();
            double[] shifts = new double[this.StartVariables.Count * 2];
            
            for (int i = 0; i < this.StartVariables.Count; i++)
            {
                currentVariables.Add(new Variable(this.StartVariables[i].Name, this.StartVariables[i].Value));
                shifts[i] = 0;
            }

            int currenIteration = 0;
            double oldValue, newValue;
            do
            {
                oldValue = this.Function.GetResultValue(currentVariables);
                for (int i = 0; i < this.StartVariables.Count; i++)
                {
                    currentVariables[i].Value += this.CalculationStep;
                    shifts[i * 2] = this.Function.GetResultValue(currentVariables);

                    currentVariables[i].Value -= 2 * this.CalculationStep;
                    shifts[i * 2 + 1] = this.Function.GetResultValue(currentVariables);
                    currentVariables[i].Value += this.CalculationStep;
                }

                int minimalShiftIndex = this.GetMinIndex(shifts);
                int parameterIndex = minimalShiftIndex / 2;
                if (minimalShiftIndex % 2 == 0)
                {
                    currentVariables[parameterIndex].Value += this.CalculationStep;
                }
                else
                {
                    currentVariables[parameterIndex].Value -= this.CalculationStep;
                }

                newValue = this.Function.GetResultValue(currentVariables);
                currenIteration++;
            } while (Math.Abs(newValue - oldValue) > epselon && currenIteration < this.MaxIterationCount);

            List<OptimizationVariable> result = OptimizationVariable.ConvertVariablesToOptimizationVariables(currentVariables);
            functionResult = newValue;
            return result;
        }

        private int GetMinIndex(double[] shifts)
        {
            double minimalValue = double.MaxValue;
            int minIndex = 0;
            
            for (int i = 0; i < shifts.Length; i++)
            {
                if (shifts[i] < minimalValue)
                {
                    minIndex = i;
                    minimalValue = shifts[i];
                }
            }

            return minIndex;
        }
    }
}
