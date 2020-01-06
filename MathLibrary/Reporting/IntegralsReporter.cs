namespace Reporting
{
    using System.Collections.Generic;
    using Excel = Microsoft.Office.Interop.Excel;
    using Integral;

    public class IntegralReporter : ExcelReporter
    {
        public IntegralReporter(
            string fileName,
            Integral integral,
            List<CalculationType> calculationTypes,
            Dictionary<CalculationType, double> calculationTimes,
            Dictionary<CalculationType, double> results)
            :base(fileName)
        {
            this.Integral = integral;
            this.CalculationTypes = calculationTypes;
            this.CalculationTimes = calculationTimes;
            this.Results = results;
        }
        
        public IntegralReporter()
        {
        }

        public Integral Integral { get; set; }

        public List<CalculationType> CalculationTypes { get; set; }

        public Dictionary<CalculationType, double> CalculationTimes { get; set; }

        public Dictionary<CalculationType, double> Results { get; set; }

        public override void GenerateReport()
        {
            Excel.Workbook xlWorkbook = base.InitExcelApplication();
            Excel.Worksheet itemWorkSheet = (Excel.Worksheet)xlWorkbook.Worksheets.Add();
            this.SetInitialSheet(itemWorkSheet);

            Excel.Worksheet commonResultsWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.Add();
            this.SetCommonResult(commonResultsWorksheet);
            xlWorkbook.SaveAs(base.ReportFileName, Excel.XlFileFormat.xlWorkbookNormal);

            base.DisposeExcelApplication(xlWorkbook);
        }

        private void SetInitialSheet(Excel.Worksheet xlWorkSheet)
        {
            xlWorkSheet.Name = "Intial parameters";
            int rowIndex = 1;
            int columnIndex = 1;

            // Adding a header
            xlWorkSheet.Cells[rowIndex, columnIndex] = "Integral";

            // Adding an Integral content
            rowIndex++;
            xlWorkSheet.Cells[rowIndex, columnIndex] = $"{this.Integral.Integrand.ExpressionString}(d{this.Integral.Variable.Name})";
            rowIndex++;

            // Adding initial values
            rowIndex++;
            xlWorkSheet.Cells[rowIndex, columnIndex] = "From = ";
            xlWorkSheet.Cells[rowIndex, columnIndex + 1] = this.Integral.StartValue;
            rowIndex++;

            xlWorkSheet.Cells[rowIndex, columnIndex] = "To = ";
            xlWorkSheet.Cells[rowIndex, columnIndex + 1] = this.Integral.EndValue;
            rowIndex++;

            xlWorkSheet.Cells[rowIndex, columnIndex] = "Number of steps = ";
            xlWorkSheet.Cells[rowIndex, columnIndex + 1] = this.Integral.IterationsNumber;
            rowIndex++;

            rowIndex++;
            xlWorkSheet.Cells[rowIndex, columnIndex] = "Calculate with next methods:";
            rowIndex++;

            for (int i = 0; i < this.CalculationTypes.Count; i++)
            {
                xlWorkSheet.Cells[rowIndex, columnIndex] = this.CalculationTypes[i].ToString();
                rowIndex++;
            }
        }

        private void SetCommonResult(Excel.Worksheet xlWorkSheet)
        {
            xlWorkSheet.Name = "Common results";
            int rowIndex = 1;
            int columnIndex = 1;

            xlWorkSheet.Cells[rowIndex, columnIndex] = "Calculation results";
            rowIndex++;

            rowIndex++;
            xlWorkSheet.Cells[rowIndex, columnIndex] = "Calculation type";
            xlWorkSheet.Cells[rowIndex + 1, columnIndex] = "Time";
            xlWorkSheet.Cells[rowIndex + 2, columnIndex] = "Value";

            columnIndex++;
            foreach(CalculationType calculationType in this.CalculationTypes)
            {
                xlWorkSheet.Cells[rowIndex, columnIndex] = calculationType.ToString();
                xlWorkSheet.Cells[rowIndex + 1, columnIndex] = this.CalculationTimes[calculationType].ToString();
                xlWorkSheet.Cells[rowIndex + 2, columnIndex] = this.Results[calculationType].ToString();

                columnIndex++;
            }

            columnIndex = 1;

            string leftTopTimeChart = GetExcelColumnName(1) + (rowIndex).ToString();
            string rightDownTimeChart = GetExcelColumnName(this.CalculationTimes.Count) + (rowIndex + 1).ToString();
            base.CreateTimeGraph(leftTopTimeChart, rightDownTimeChart, xlWorkSheet);
        }
    }
}
