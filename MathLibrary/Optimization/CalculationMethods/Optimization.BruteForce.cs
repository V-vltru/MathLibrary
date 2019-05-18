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
        private double broutForceMin;

        private List<Variable> brouteForceResult;

        private List<Variable> currentBrouteForceParameters;

        private void BustOptions(int parameterIndex)
        {
            for(double currentValue = this.StartVariables[parameterIndex].Value; currentValue < this.EndVariables[parameterIndex].Value; currentValue += this.CalculationStep)
            {
                this.currentBrouteForceParameters[parameterIndex].Value = currentValue;

                if (parameterIndex == this.StartVariables.Count - 1)
                {
                    double currentResult = this.Function.GetResultValue(currentBrouteForceParameters);
                    if (currentResult < this.broutForceMin)
                    {
                        this.broutForceMin = currentResult;
                        Variable.CopyVariables(this.currentBrouteForceParameters, this.brouteForceResult);
                    }
                }
                else
                {
                    this.BustOptions(parameterIndex + 1);
                }
            }
        }

        public List<OptimizationVariable> CalculateBrouteForce(out double functionResult)
        {
            List<OptimizationVariable> result = new List<OptimizationVariable>();

            this.broutForceMin = double.MaxValue;
            this.brouteForceResult = new List<Variable>();
            this.currentBrouteForceParameters = new List<Variable>();

            foreach (OptimizationVariable variable in this.StartVariables)
            {
                this.brouteForceResult.Add(new Variable(variable.Name, variable.Value));
                this.currentBrouteForceParameters.Add(new Variable(variable.Name, variable.Value));
            }

            this.BustOptions(0);
            result = OptimizationVariable.ConvertVariablesToOptimizationVariables(this.brouteForceResult);

            functionResult = this.broutForceMin;
            return result;
        }
    }
}
