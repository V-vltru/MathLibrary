using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Expressions;
using Expressions.Models;
using Interpolation;

namespace InterpolationClient
{
    public partial class Form1 : Form
    {
        private string defaultTimeInfo = "Time: "; 
        
        private int steps;

        private Variable variable = new Variable("x", 0);

        public double From { get; set; }

        public double To { get; set; }

        public Expression Function { get; set; }

        public List<Point> Points { get; set; }

        public List<Point> RemainedPoints { get; set; }

        public List<Point> RemovedPoints { get; set; }

        public int Steps
        {
            get { return steps; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Value for steps shoud be more then zero! Actual one: {value}");
                }

                this.steps = value;
            }
        }

        private bool CheckInputParameters()
        {
            if (!(double.TryParse(this.textBoxFrom.Text, out double a) &&
                double.TryParse(this.textBoxTo.Text, out a) &&
                this.numericUpDownSteps.Value > 0))
            {
                return false;
            }

            try
            {
                Expression exp = new Expression(textBoxExpression.Text, this.variable);
            }
            catch
            {
                return false;
            }

            return true;
        }

        private void SetVariables()
        {
            this.From = double.Parse(textBoxFrom.Text);
            this.To = double.Parse(textBoxTo.Text);
            this.Steps = (int)numericUpDownSteps.Value;
            this.Function = new Expression(textBoxExpression.Text, this.variable);
        }

        private void SetDefaultEnablingForComponents()
        {
            this.buttonExport.Enabled = false;
            this.buttonInterpolate.Enabled = false;
            this.buttonRemoveAndBuildGraph.Enabled = false;
            this.comboBoxInterpolationType.Enabled = false;
            this.textBoxRemoveFrom.Enabled = false;
            this.textBoxRemoveTo.Enabled = false;
            this.numericUpDownRemoveCount.Enabled = false;
        }

        /// <summary>
        /// Method is used to fill the points array according to the input function.
        /// </summary>
        private void SetPoints()
        {
            this.Points = new List<Point>();

            double stepValue = (this.To - this.From) / this.Steps;
            Variable currentVariable = new Variable("x", this.From);
            for (int i = 0; i <= this.Steps; i++)
            {
                this.Points.Add(new Point(currentVariable.Value, this.Function.GetResultValue(currentVariable)));
                currentVariable.Value += stepValue;
            }

            this.Points[this.Points.Count - 1].X = this.To;
            this.Points[this.Points.Count - 1].Y = this.Function.GetResultValue(new Variable("x", this.To));
        }

        /// <summary>
        /// Method is used to draw graph on the chart.
        /// </summary>
        /// <param name="seriesIndex">Index of the chart (0, 1 or 2)</param>
        /// <param name="seriesChartType">Chart type (line or point.)</param>
        /// <param name="points">Points which expected to be drown.</param>
        private void DrawGraphic(
            int seriesIndex,
            System.Windows.Forms.DataVisualization.Charting.SeriesChartType seriesChartType,
            List<Point> points,
            string seriesName)
        {
            // Create series instance if it doesn't exist.
            if (chartFunction.Series.Count < seriesIndex + 1)
            {
                chartFunction.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series());
            }
            else
            {
                for (int i = seriesIndex + 1; i < chartFunction.Series.Count; i++)
                {
                    chartFunction.Series[i].Points.Clear();
                }
            }

            // remove all previous points of the special series.
            if (chartFunction.Series[seriesIndex].Points.Count > 0)
            {
                chartFunction.Series[seriesIndex].Points.Clear();
            }
            
            chartFunction.Series[seriesIndex].ChartType = seriesChartType;
            for (int i = 0; i < points.Count; i++)
            {
                chartFunction.Series[seriesIndex].Points.AddXY(points[i].X, points[i].Y);
            }

            chartFunction.Series[seriesIndex].Name = seriesName;
        }

        public Form1()
        {
            InitializeComponent();
            this.SetDefaultEnablingForComponents();
            this.comboBoxInterpolationType.Items.AddRange(Enum.GetNames(typeof(InterpolationType)));
        }

        private void buttonSetGraph_Click(object sender, EventArgs e)
        {
            if (!this.CheckInputParameters())
            {
                MessageBox.Show("Входные параметры заданы неверно!");
                return;
            }

            this.SetVariables();
            this.SetPoints();
            this.DrawGraphic(
                0,
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line,
                this.Points,
                "Initial");

            this.buttonExport.Enabled = true;
            this.textBoxRemoveFrom.Enabled = true;
            //this.textBoxRemoveFrom.Text = this.textBoxFrom.Text;
            this.textBoxRemoveTo.Enabled = true;
            //this.textBoxRemoveTo.Text = this.textBoxTo.Text;
            this.numericUpDownRemoveCount.Enabled = true;
            this.numericUpDownRemoveCount.Maximum = this.numericUpDownSteps.Maximum;
            this.numericUpDownRemoveCount.Value = this.numericUpDownSteps.Value / 3;
            this.buttonRemoveAndBuildGraph.Enabled = true;
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            saveFileDialogInitialPoints.FileName = "points.csv";
            saveFileDialogInitialPoints.ShowDialog();

            if (!string.IsNullOrWhiteSpace(saveFileDialogInitialPoints.FileName))
            {
                FileStream fs = (FileStream)saveFileDialogInitialPoints.OpenFile();

                using (StreamWriter writer = new StreamWriter(fs))
                {
                    foreach(Point point in this.Points)
                    {
                        string line = $"{point.X};{point.Y}";
                        writer.WriteLine(line);
                    }
                }

                fs.Close();
            }
        }

        private void buttonRemoveAndBuildGraph_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            this.RemainedPoints = new List<Point>();
            this.RemovedPoints = new List<Point>();

            if (this.numericUpDownRemoveCount.Value < 0 || 
                !double.TryParse(this.textBoxRemoveFrom.Text, out double r) ||
                !double.TryParse(this.textBoxRemoveTo.Text, out r))
            {
                MessageBox.Show("неправильные параметры удаления!");
                return;
            }

            double removeFrom = double.Parse(this.textBoxRemoveFrom.Text);
            double removeTo = double.Parse(this.textBoxRemoveTo.Text);
            int removeCount = (int)this.numericUpDownRemoveCount.Value;

            List<Point> viewPoints = new List<Point>();
            for (int i = 0; i < this.Points.Count; i++)
            {
                if (this.Points[i].X >= removeFrom && this.Points[i].X <= removeTo)
                {
                    viewPoints.Add(new Point
                    {
                        X = this.Points[i].X,
                        Y = this.Points[i].Y
                    });
                }
            }

            for (int i = 0; i < removeCount; i++)
            {
                if (viewPoints.Count > 0)
                {
                    int idx = random.Next(0, viewPoints.Count);
                    this.RemovedPoints.Add(new Point
                    {
                        X = viewPoints[idx].X,
                        Y = viewPoints[idx].Y
                    });
                    viewPoints.Remove(viewPoints[idx]);
                }
                else
                {
                    break;
                }
            }

            this.RemovedPoints.Sort();

            for (int i = 0; i < this.Points.Count; i++)
            {
                bool isPointRemoved = (from g in this.RemovedPoints
                                       where g.X == this.Points[i].X
                                       select g).Any();

                if (!isPointRemoved)
                {
                    this.RemainedPoints.Add(new Point
                    {
                        X = this.Points[i].X,
                        Y = this.Points[i].Y
                    });
                }
            }

            this.DrawGraphic(
            1,
            System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point,
            this.RemainedPoints,
            "Remained");
            
            this.comboBoxInterpolationType.Enabled = true;
            this.buttonInterpolate.Enabled = true;
        }

        private void buttonInterpolate_Click(object sender, EventArgs e)
        {
            if (comboBoxInterpolationType.SelectedIndex < 0)
            {
                MessageBox.Show("Не выбран тип интерполяции.");
                return;
            }

            InterpolationType interpolationType = (InterpolationType)Enum.Parse(typeof(InterpolationType), comboBoxInterpolationType.SelectedItem.ToString());

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Interpolation.Interpolation instance = InterpolationFactory.GetInterpolationProvider(interpolationType, this.RemainedPoints.ToArray());

            if (checkBoxParallelMode.Checked)
            {
                List<Task> tasks = new List<Task>();
                foreach (var item in this.RemovedPoints)
                {
                    Task task = new Task(() => 
                    {
                        item.Y = instance.GetInterpolatedValue(item.X);
                    });

                    task.Start();
                    tasks.Add(task);
                }

                Task.WaitAll(tasks.ToArray());
            }
            else
            {
                foreach (var item in this.RemovedPoints)
                {
                    item.Y = checked(instance.GetInterpolatedValue(item.X));
                }
            }

            stopwatch.Stop();
            this.DrawGraphic(
                2,
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point,
                this.RemovedPoints,
                "Interpolated");

            this.label9.Text = this.defaultTimeInfo + (stopwatch.ElapsedMilliseconds / 1000.0).ToString();
        }
    }
}
