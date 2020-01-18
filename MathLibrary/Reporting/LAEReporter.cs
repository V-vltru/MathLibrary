namespace Reporting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LinearAlgebraicEquationsSystem;
    using Excel = Microsoft.Office.Interop.Excel;

    class LAEReporter : ExcelReporter
    {
        public LAEReporter(
            string filePath,
            LinearAlgebraicEquationSystem linearAlgebraicEquationSystem,
            List<LAEMethod> methods,
            Dictionary<LAEMethod, List<LAEVariable>> results,
            Dictionary<LAEMethod, double> times,
            Dictionary<LAEMethod, List<IntermediateResult>> intermediateResults)
            :base(filePath)
        {
            this.LinearAlgebraicEquationSystem = linearAlgebraicEquationSystem;
            this.Methods = methods;
            this.Results = results;
            this.Times = times;
            this.IntermediateResults = intermediateResults;
        }

        public LAEReporter(
            string filePath,
            LinearAlgebraicEquationSystem linearAlgebraicEquationSystem,
            LAEMethod method,
            List<LAEVariable> result,
            double time,
            List<IntermediateResult> intermediateResults)
            : this(
                 filePath,
                 linearAlgebraicEquationSystem,
                 new List<LAEMethod> { method },
                 new Dictionary<LAEMethod, List<LAEVariable>> { { method, result} },
                 new Dictionary<LAEMethod, double> { { method, time} },
                 new Dictionary<LAEMethod, List<IntermediateResult>> { { method, intermediateResults} }
                 )
        {
        }

        public LAEReporter()
        {
        }

        /// <summary>
        /// Gets or sets the linear algebraical equation system.
        /// </summary>
        public LinearAlgebraicEquationSystem LinearAlgebraicEquationSystem { get; set; }

        /// <summary>
        /// Gets or sets the list of methods to report.
        /// </summary>
        public List<LAEMethod> Methods { get; set; }

        /// <summary>
        /// Gets or sets the results for each method.
        /// </summary>
        public Dictionary<LAEMethod, List<LAEVariable>> Results { get; set; }

        /// <summary>
        /// Gets or sets calculation times for each method.
        /// </summary>
        public Dictionary<LAEMethod, double> Times { get; set; }

        /// <summary>
        /// Gets or sets the Intermediate results for each method.
        /// </summary>
        public Dictionary<LAEMethod, List<IntermediateResult>> IntermediateResults { get; set; }

        public override void GenerateReport()
        {
            throw new NotImplementedException();
        }

        private void SetInitialSheet(Excel.Worksheet xlWorkSheet)
        {
            xlWorkSheet.Name = "Intial parameters";
            int rowIndex = 1;
            int columnIndex = 1;

            // Adding a header
            xlWorkSheet.Cells[rowIndex, columnIndex] = "Linear algebraic equation system";

            for (int i = 0; i < this.LinearAlgebraicEquationSystem.LeftPartEquations.Count; i++)
            {
                rowIndex++;
                xlWorkSheet.Cells[rowIndex, columnIndex] = this.LinearAlgebraicEquationSystem.LeftPartEquations[i].ExpressionString + "=" + this.LinearAlgebraicEquationSystem.RightPartEquations[i].ToString();
            }

            rowIndex++;
            xlWorkSheet.Cells[rowIndex, columnIndex] = "Calculate with next methods:";
            rowIndex++;

            for (int i = 0; i < this.Methods.Count; i++)
            {
                xlWorkSheet.Cells[rowIndex, columnIndex] = this.Methods[i].ToString();
                rowIndex++;
            }
        }

        private void SetIntermediateResults(int rowIndex, Excel.Worksheet xlWorkSheet, LAEMethod lAEMethod)
        {
            int columnIndex = 1;
            for (int i = 0; i < this.IntermediateResults[lAEMethod].Count; i++)
            {
                xlWorkSheet.Cells[rowIndex, columnIndex] = this.IntermediateResults[lAEMethod][i].Description;

                if (this.IntermediateResults[lAEMethod][i].Matrix != null)
                {
                    rowIndex++;
                    for (int j = 0; j < this.IntermediateResults[lAEMethod][i].Matrix.Rows; j++)
                    {
                        for (int k = 0; k < this.IntermediateResults[lAEMethod][i].Matrix.Columns; k++)
                        {
                            xlWorkSheet.Cells[rowIndex + j, columnIndex + k] = this.IntermediateResults[lAEMethod][i].Matrix[j, k];
                        }
                    }

                    //rowIndex += this.IntermediateResults[lAEMethod][i].Matrix.Rows + 1;
                }

                if (this.IntermediateResults[lAEMethod][i].RightPart != null)
                {
                    rowIndex++;
                    for (int j = 0; j < )
                }
            }
        }
    }
}
