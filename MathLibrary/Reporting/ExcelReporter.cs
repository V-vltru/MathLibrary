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
        /// <returns></returns>
        protected Excel.Workbook InitExcelApplication()
        {
            this.ExcelApplication = new Excel.Application();
            if (this.ExcelApplication == null)
            {
                throw new NullReferenceException("Excel is not properly installed!!");
            }

            return this.ExcelApplication.Workbooks.Add();            
        }

        protected void DisposeExcelApplication(Excel.Workbook workbook)
        {
            workbook.Close();
            this.ExcelApplication.Quit();

            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(this.ExcelApplication);
        }
    }
}
