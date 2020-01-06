namespace Reporting
{
    using System;
    using System.Runtime.InteropServices;
    using Excel = Microsoft.Office.Interop.Excel;

    public abstract class ExcelReporter
    {
        /// <summary>
        /// Gets or sets the file name where report is supposed to be saved.
        /// </summary>
        public string ReportFileName { get; set; }

        private Excel.Application ExcelApplication { get; set; }

        /// <summary>
        /// Constructor which sets the output file name.
        /// </summary>
        /// <param name="reportFileName">Output file name.</param>
        public ExcelReporter(string reportFileName)
        {
            this.ReportFileName = reportFileName;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ExcelReporter()
        {
        }

        /// <summary>
        /// Method is used to generate an excel report.
        /// </summary>
        /// <returns>The flag which represents whether the report was created successfully.</returns>
        public abstract void GenerateReport();

        /// <summary>
        /// Method gets column name by its index
        /// </summary>
        /// <param name="columnNumber">Number of a column</param>
        /// <returns>Column name</returns>
        protected static string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        /// <summary>
        /// Method is used to intialize the excel application 
        /// </summary>
        /// <returns>Workbook instance for which woksheet can be created.</returns>
        protected Excel.Workbook InitExcelApplication()
        {
            this.ExcelApplication = new Excel.Application();
            if (this.ExcelApplication == null)
            {
                throw new NullReferenceException("Excel is not properly installed!!");
            }

            return this.ExcelApplication.Workbooks.Add();            
        }

        /// <summary>
        /// Method is used to dispose all excel-related resources.
        /// </summary>
        /// <param name="workbook">Workbook to dispose.</param>
        protected void DisposeExcelApplication(Excel.Workbook workbook)
        {
            workbook.Close();
            this.ExcelApplication.Quit();

            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(this.ExcelApplication);
        }

        /// <summary>
        /// Method is used to build a time graph.
        /// </summary>
        /// <param name="leftTopTimeChart">Left top table index.</param>
        /// <param name="rightDownTimeChart">Right down table index.</param>
        /// <param name="xlWorkSheet">Worksheet for which chart should be created.</param>
        protected virtual void CreateTimeGraph(string leftTopTimeChart, string rightDownTimeChart, Excel.Worksheet xlWorkSheet)
        {
            Excel.Range chartRange;
            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject mychart = xlCharts.Add(10, 80, 500, 450);
            Excel.Chart chartPage = mychart.Chart;

            chartRange = xlWorkSheet.get_Range(leftTopTimeChart, rightDownTimeChart);
            chartPage.SetSourceData(chartRange);
            chartPage.ChartType = Excel.XlChartType.xl3DColumnClustered;

            chartPage.SeriesCollection(1).Name = "Calculation times";
        }
    }
}
