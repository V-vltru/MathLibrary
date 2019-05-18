using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expressions;
using Expressions.Models;

namespace Optimization
{
    public partial class Optimization
    {
        private double calculationStep;

        private List<Variable> startVariables;
        
        public Expression Function { get; set; }

        public List<OptimizationVariable> StartVariables { get; set; }
        //{
        //    get { return OptimizationVariable.ConvertVariablesToOptimizationVariables(startVariables); }
        //    set { this.startVariables = OptimizationVariable.ConvertOptimizationVariablesToVariables(value); }
        //}

        public List<OptimizationVariable> EndVariables { get; set; }
        
        public List<OptimizationVariable> Constants { get; set; }

        public double CalculationStep
        {
            get { return this.calculationStep; }
            set
            {
                if (value > 0)
                {
                    this.calculationStep = value;
                }
                else
                {
                    throw new ArgumentException($"Step {value} is expected to be more than zero!");
                }
            }
        }

        public Optimization(string function, double calculationStep, List<OptimizationVariable> startVariables, List<OptimizationVariable> endVariables, List<OptimizationVariable> constants = null)
        {
            if (Optimization.CheckInputParametersName(startVariables, endVariables))
            {
                List<OptimizationVariable> allVariables = new List<OptimizationVariable>();

                this.StartVariables = startVariables;
                this.EndVariables = endVariables;
                allVariables.AddRange(startVariables);

                if (constants != null && constants.Count > 0)
                {
                    this.Constants = constants;
                    allVariables.AddRange(constants);
                }

                this.Function = new Expression(function, OptimizationVariable.ConvertOptimizationVariablesToVariables(allVariables));

                this.CalculationStep = calculationStep;
            }
            else
            {
                throw new ArgumentException("Parameters 'startValue' and 'endVariable' are incorrect.");
            }
        }

        private static bool CheckInputParametersName(List<OptimizationVariable> startVariables, List<OptimizationVariable> endVariables)
        {
            if (startVariables != null && endVariables != null
                && startVariables.Count > 0 && endVariables.Count > 0 && startVariables.Count == endVariables.Count)
            {
                for(int i = 0; i < startVariables.Count; i++)
                {
                    OptimizationVariable variable = (from g in endVariables
                                                     where g.Name.Equals(startVariables[i].Name)
                                                     select g).FirstOrDefault();

                    if (variable == null)
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }
    }
}
