using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixClient
{
    public static class MatrixClientHelper
    {
        public static bool CheckMatrixSize(DataGridView dataGridView, int rows, int columns)
        {
            if (dataGridView.ColumnCount == columns && dataGridView.RowCount == rows)
            {
                return true;
            }

            return false;
        }

        public static void SetColumnsAndRowsForDatagridView(DataGridView dataGridView, int rows, int columns, Func<double, double, double> F)
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            dataGridView.ColumnCount = columns;
            dataGridView.RowCount = rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    dataGridView.Rows[i].Cells[j].Value = F(i, j);
                }
            }
        }

        public static void SetRandomValuesForGrid(params DataGridView[] dataGridViews)
        {
            Random random = new Random();

            foreach (DataGridView dataGridView in dataGridViews)
            {
                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView.ColumnCount; j++)
                    {
                        dataGridView[j, i].Value = random.Next(-100, 100).ToString();
                    }
                }
            }
        }

        public static bool VerifyMatrixParameters(params DataGridView[] dataGridViews)
        {
            foreach (DataGridView dataGridView in dataGridViews)
            {
                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView.ColumnCount; j++)
                    {
                        if (!double.TryParse(dataGridView[j, i].Value.ToString(), out double result))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public static double[,] GetArrayFromGrid(DataGridView dataGridView)
        {
            double[,] result = new double[dataGridView.RowCount, dataGridView.ColumnCount];

            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    result[i, j] = double.Parse(dataGridView[j, i].Value.ToString());
                }
            }

            return result;
        }

        public static T[][] ToJagged<T>(T[,] mArray)
        {
            var rows = mArray.GetLength(0);
            var cols = mArray.GetLength(1);
            var jArray = new T[rows][];

            for (int i = 0; i < rows; i++)
            {
                jArray[i] = new T[cols];
                for (int j = 0; j < cols; j++)
                {
                    jArray[i][j] = mArray[i, j];
                }
            }

            return jArray;
        }
    }
}
