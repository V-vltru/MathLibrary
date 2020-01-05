namespace Reporting
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Excel = Microsoft.Office.Interop.Excel;
    using DifferentialEquationSystem;
    using Expressions.Models;

    /// <summary>
    /// Represents the logic of generating a report for Differential equation system.
    /// </summary>
    public class DEReporter : ExcelReporter
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public DEReporter()
            :base()
        {
        }

        /// <summary>
        /// Constructor which takes a file path.
        /// </summary>
        /// <param name="reportFileName">Report file name.</param>
        public DEReporter(string reportFileName)
            :base(reportFileName)
        {
        }

        /// <summary>
        /// Constructor which takes all class parameter.
        /// </summary>
        /// <param name="reportFileName">Report file name.</param>
        /// <param name="calculationTypes">Calcuation types.</param>
        /// <param name="times">Calculation times for each type.</param>
        /// <param name="results">Calculation results for each type.</param>
        /// <param name="allVariables">All variables at each time for each type.</param>
        /// <param name="differentialEquationSystem">Differential equation system instance</param>
        public DEReporter(
            string reportFileName,
            List<CalculationTypeName> calculationTypes,
            Dictionary<CalculationTypeName, double> times,
            Dictionary<CalculationTypeName, List<DEVariable>> results,
            Dictionary<CalculationTypeName, List<List<DEVariable>>> allVariables,
            DifferentialEquationSystem differentialEquationSystem)
            :base(reportFileName)
        {
            this.CalculationTypes = calculationTypes;
            this.Times = times;
            this.Results = results;
            this.AllVariables = allVariables;
            this.DifferentialEquationSystem = differentialEquationSystem;
        }

        /// <summary>
        /// Gets or sets calculation types which were used to get results.
        /// </summary>
        public List<CalculationTypeName> CalculationTypes { get; set; }

        /// <summary>
        /// Gets or sets calculation times for each calculation time.
        /// </summary>
        public Dictionary<CalculationTypeName, double> Times { get; set; }

        /// <summary>
        /// Gets or sets calculation results for each calculation time.
        /// </summary>
        public Dictionary<CalculationTypeName, List<DEVariable>> Results { get; set; }

        /// <summary>
        /// Gets or sets all variables values at each time for each calculation type.
        /// </summary>
        public Dictionary<CalculationTypeName, List<List<DEVariable>>> AllVariables { get; set; }

        /// <summary>
        /// Gets or sets Differential equation instance.
        /// </summary>
        public DifferentialEquationSystem DifferentialEquationSystem { get; set; }

        /// <summary>
        /// Method is used to generate a report.
        /// </summary>
        public override void GenerateReport()
        {
            Excel.Workbook xlWorkbook = base.InitExcelApplication();

            // Adding variables per each steps
            for (int i = this.CalculationTypes.Count - 1; i >= 0; i--)
            {
                Excel.Worksheet itemWorkSheet = (Excel.Worksheet)xlWorkbook.Worksheets.Add();
                this.SetCalculationResults(
                    itemWorkSheet,
                    this.CalculationTypes[i], 
                    this.DifferentialEquationSystem.LeftVariables, 
                    this.Results[this.CalculationTypes[i]],
                    this.AllVariables[this.CalculationTypes[i]],
                    this.Times[this.CalculationTypes[i]]);
            }

            // Generate common results when the amount of calculation times more than 1
            if (this.CalculationTypes.Count > 1)
            {
                Excel.Worksheet commonResultsWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.Add();
                this.SetCommonResults(commonResultsWorksheet);
            }

            Excel.Worksheet initialXlWorkSheet = (Excel.Worksheet)xlWorkbook.Worksheets.Add();
            this.SetInitalSheet(initialXlWorkSheet);
            Marshal.ReleaseComObject(initialXlWorkSheet);

            xlWorkbook.SaveAs(base.ReportFileName, Excel.XlFileFormat.xlWorkbookNormal);

            base.DisposeExcelApplication(xlWorkbook);
        }

        //public void GenerateReport(params CalculationTypeName[] calculationTypeNames)
        //{
        //    Excel.Application xlApp = new Excel.Application();
        //    if (xlApp == null)
        //    {
        //        throw new NullReferenceException("Excel is not properly installed!!");
        //    }

        //    Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
        //    for (int i = calculationTypeNames.Length - 1; i >= 0; i--)
        //    {
        //        Excel.Worksheet itemWorkSheet = (Excel.Worksheet)xlWorkbook.Worksheets.Add();
        //        this.SetCalculationResults(
        //            itemWorkSheet,
        //            this.CalculationTypes[i],
        //            this.DifferentialEquationSystem.LeftVariables,
        //            this.Results[this.CalculationTypes[i]],
        //            this.AllVariables[this.CalculationTypes[i]],
        //            this.Times[this.CalculationTypes[i]]);
        //    }

        //    // Generate common results when the amount of calculation times more than 1
        //    if (this.CalculationTypes.Count > 1)
        //    {
        //        Excel.Worksheet commonResultsWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.Add();
        //        this.SetCommonResults(commonResultsWorksheet);
        //    }

        //    Excel.Worksheet initialXlWorkSheet = (Excel.Worksheet)xlWorkbook.Worksheets.Add();
        //    this.SetInitalSheet(initialXlWorkSheet);

        //    xlWorkbook.SaveAs(base.ReportFileName, Excel.XlFileFormat.xlWorkbookNormal);
        //    xlWorkbook.Close();
        //    xlApp.Quit();

        //    Marshal.ReleaseComObject(initialXlWorkSheet);
        //    Marshal.ReleaseComObject(xlWorkbook);
        //    Marshal.ReleaseComObject(xlApp);
        //}

        /// <summary>
        /// Method is used to report about calculation result for each type.
        /// </summary>
        /// <param name="worksheet">Current worksheet.</param>
        /// <param name="calculationTypeName">Current calculation type name.</param>
        /// <param name="leftVariables">Left variables of the differential equation system.</param>
        /// <param name="result"></param>
        /// <param name="allVariables"></param>
        /// <param name="calcTime"></param>
        private void SetCalculationResults(
            Excel.Worksheet worksheet,
            CalculationTypeName calculationTypeName,
            List<Variable> leftVariables,
            List<DEVariable> result,
            List<List<DEVariable>> allVariables,
            double calcTime)
        {
            worksheet.Name = calculationTypeName.ToString();
            int rowIndex = 1;
            int columnIndex = 1;

            for (int i = 0; i < result.Count; i++)
            {
                worksheet.Cells[rowIndex, columnIndex] = $"{result[i].Name} = ";
                worksheet.Cells[rowIndex, columnIndex + 1] = result[i].Value;
                rowIndex++;
            }

            rowIndex++;
            worksheet.Cells[rowIndex, columnIndex] = "Calculation time = ";
            worksheet.Cells[rowIndex, columnIndex + 1] = calcTime;
            rowIndex++;

            if (allVariables != null)
            {
                rowIndex++;
                worksheet.Cells[rowIndex, columnIndex] = "Detailed results";
                rowIndex++;

                for (int i = 0; i < allVariables[0].Count; i++)
                {
                    worksheet.Cells[rowIndex, columnIndex + i] = allVariables[0][i].Name;
                }

                rowIndex++;

                string leftTopCellforChart = GetExcelColumnName(columnIndex) + rowIndex.ToString();
                string horinzontalAxisTop = GetExcelColumnName(columnIndex + allVariables[0].Count - 1) + rowIndex.ToString();
                int idxStart = rowIndex;

                for (int i = 0; i < allVariables.Count; i++)
                {
                    for (int j = 0; j < allVariables[0].Count; j++)
                    {
                        worksheet.Cells[rowIndex, columnIndex + j] = allVariables[i][j].Value;
                    }

                    rowIndex++;
                }

                string rightDownCellForChart = GetExcelColumnName(columnIndex + allVariables[0].Count - 2) + (allVariables.Count - 1 + idxStart).ToString();
                string horizontalAlignmentDown = GetExcelColumnName(columnIndex + allVariables[0].Count - 1) + (allVariables.Count - 1 + idxStart).ToString();
                Excel.Range chartRange;
                Excel.Range horizontalAlignmentRange;
                Excel.ChartObjects xlCharts = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Excel.ChartObject mychart = xlCharts.Add(10, 80, 500, 450);
                Excel.Chart chartPage = mychart.Chart;

                chartRange = worksheet.get_Range(leftTopCellforChart, rightDownCellForChart);
                chartPage.SetSourceData(chartRange);
                chartPage.ChartType = Excel.XlChartType.xlLine;
                horizontalAlignmentRange = worksheet.get_Range(horinzontalAxisTop, horizontalAlignmentDown);

                chartPage.SeriesCollection(1).XValues = horizontalAlignmentRange;

                for (int i = 0; i < this.DifferentialEquationSystem.LeftVariables.Count; i++)
                {
                    chartPage.SeriesCollection(i + 1).Name = this.DifferentialEquationSystem.LeftVariables[i].Name;
                }
            }
        }

        /// <summary>
        /// Method is used to set the common results.
        /// </summary>
        /// <param name="worksheet">Current worksheet.</param>
        private void SetCommonResults(Excel.Worksheet worksheet)
        {
            worksheet.Name = "Common results";
            int rowIndex = 1;
            int columnIndex = 1;

            worksheet.Cells[rowIndex, columnIndex] = "Calculation results";
            rowIndex++;

            int i = 0;

            foreach (KeyValuePair<CalculationTypeName, List<DEVariable>> item in this.Results)
            {
                int j = 0;
                List<DEVariable> result;

                if (i == 0)
                {
                    result = item.Value;
                    foreach (DEVariable variable in result)
                    {
                        worksheet.Cells[rowIndex + j + 1, columnIndex] = variable.Name;
                        j++;
                    }
                }

                worksheet.Cells[rowIndex, columnIndex + i + 1] = item.Key.ToString();

                j = 0;
                result = item.Value;
                foreach (DEVariable variable in result)
                {
                    worksheet.Cells[rowIndex + 1 + j, columnIndex + i + 1] = variable.Value;
                    j++;
                }

                i++;
            }

            rowIndex += 3;
            worksheet.Cells[rowIndex, columnIndex] = "Time results";
            rowIndex++;

            i = 0;
            foreach (KeyValuePair<CalculationTypeName, double> calculationTime in this.Times)
            {
                worksheet.Cells[rowIndex, columnIndex + i] = calculationTime.Key.ToString();
                worksheet.Cells[rowIndex + 1, columnIndex + i] = calculationTime.Value;

                i++;
            }

            string leftTopTimeChart = GetExcelColumnName(1) + rowIndex.ToString();
            string rightDownTimeChart = GetExcelColumnName(this.Times.Count) + (rowIndex + 1).ToString();

            Excel.Range chartRange;
            Excel.ChartObjects xlCharts = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
            Excel.ChartObject mychart = xlCharts.Add(10, 80, 500, 450);
            Excel.Chart chartPage = mychart.Chart;

            chartRange = worksheet.get_Range(leftTopTimeChart, rightDownTimeChart);
            chartPage.SetSourceData(chartRange);
            chartPage.ChartType = Excel.XlChartType.xl3DColumnClustered;

            chartPage.SeriesCollection(1).Name = "Calculation times";
        }

        /// <summary>
        /// Method is used to set the initial sheet.
        /// </summary>
        /// <param name="xlWorkSheet">Current worksheet.</param>
        private void SetInitalSheet(Excel.Worksheet xlWorkSheet)
        {
            xlWorkSheet.Name = "Intial parameters";
            int rowIndex = 1;
            int columnIndex = 1;

            // Adding a header
            xlWorkSheet.Cells[rowIndex, columnIndex] = "Differential Equation System";

            // Adding a differential equation content
            rowIndex++;
            for (int i = 0; i < this.DifferentialEquationSystem.ExpressionSystem.Count; i++)
            {
                xlWorkSheet.Cells[rowIndex, columnIndex] = $"{ this.DifferentialEquationSystem.LeftVariables[i].Name}' = ";
                xlWorkSheet.Cells[rowIndex, columnIndex + 1] = this.DifferentialEquationSystem.ExpressionSystem[i].ExpressionString;

                rowIndex++;
            }

            // Adding initial values
            rowIndex++;
            xlWorkSheet.Cells[rowIndex, columnIndex] = "Intial values";
            rowIndex++;

            // Adding initial values content
            for (int i = 0; i < this.DifferentialEquationSystem.LeftVariables.Count; i++)
            {
                xlWorkSheet.Cells[rowIndex, columnIndex] = $"{this.DifferentialEquationSystem.LeftVariables[i].Name}' = ";
                xlWorkSheet.Cells[rowIndex, columnIndex + 1] = this.DifferentialEquationSystem.LeftVariables[i].Value.ToString();

                rowIndex++;
            }

            rowIndex++;
            xlWorkSheet.Cells[rowIndex, columnIndex] = "Time parameters";
            rowIndex++;

            xlWorkSheet.Cells[rowIndex, columnIndex] = $"{this.DifferentialEquationSystem.TimeVariable.Name} = ";
            xlWorkSheet.Cells[rowIndex, columnIndex + 1] = this.DifferentialEquationSystem.TimeVariable.Value.ToString();
            rowIndex++;

            xlWorkSheet.Cells[rowIndex, columnIndex] = "Tau = ";
            xlWorkSheet.Cells[rowIndex, columnIndex + 1] = this.DifferentialEquationSystem.Tau;
            rowIndex++;

            xlWorkSheet.Cells[rowIndex, columnIndex] = "TimeEnd = ";
            xlWorkSheet.Cells[rowIndex, columnIndex + 1] = this.DifferentialEquationSystem.Tau;
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
    }
}
