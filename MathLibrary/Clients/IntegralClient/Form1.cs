namespace IntegralClient
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    using Integral;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.buttonRemoveStep.Enabled = false;
            buttonAddSteps.Enabled = false;
            comboBoxMethods.SelectedIndex = 0;
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxA.Text, out double a) && double.TryParse(textBoxB.Text, out a)
                && double.Parse(textBoxA.Text) < double.Parse(textBoxB.Text) && comboBoxMethods.SelectedIndex > -1)
            {
                List<string> sections = listBox1.Items.Cast<string>().ToList();
                List<double> times = new List<double>();
                List<double> parallelTimes = null;
                if (checkBoxParallelMode.Checked)
                {
                    parallelTimes = new List<double>();
                }


                CalculationType currentMethod;
                switch (comboBoxMethods.SelectedIndex)
                {
                    case 0: currentMethod = CalculationType.AverageRectangle; break;
                    case 1: currentMethod = CalculationType.Trapezium; break;
                    case 2: currentMethod = CalculationType.Simpson; break;
                    default: MessageBox.Show("Метод не был выбран!"); return;
                }

                IntegralInputParameters inputParameters = new IntegralInputParameters
                {
                    IntegrandExpression = textBoxFunction.Text,
                    StartValue = int.Parse(textBoxA.Text),
                    EndValue = int.Parse(textBoxB.Text),
                    ParameterName = "x"
                };

                Integral currentIntegral = Integral.GetIntegral(currentMethod, inputParameters);

                double result = 0.0;
                Stopwatch stopwatch = new Stopwatch();

                foreach (string section in sections)
                {
                    currentIntegral.IterationsNumber = Convert.ToInt32(section);

                    stopwatch.Reset();
                    stopwatch.Start();
                    result = currentIntegral.Calculate();
                    stopwatch.Stop();

                    times.Add(stopwatch.ElapsedMilliseconds / 1000.0);

                    if (checkBoxParallelMode.Checked)
                    {
                        stopwatch.Reset();
                        stopwatch.Start();
                        currentIntegral.CalculateAsync();
                        stopwatch.Stop();

                        parallelTimes.Add(stopwatch.ElapsedMilliseconds / 1000.0);
                    }
                }

                labelResult.Text = $"Результат: {result.ToString()}";

                this.chartResult.Series.Clear();
                this.chartResult.Titles.Clear();

                this.chartResult.Titles.Add("Зависимость времени выполнения от количества разбиений.");

                Series series = this.chartResult.Series.Add("Время выполнения");
                series.ChartType = SeriesChartType.Line;

                for (int i = 0; i < times.Count; i++)
                {
                    series.Points.AddXY(sections[i], times[i]);
                }

                if (checkBoxParallelMode.Checked)
                {
                    Series parallelSeries = this.chartResult.Series.Add("Параллельный вариант");
                    parallelSeries.ChartType = SeriesChartType.Line;

                    for (int i = 0; i < parallelTimes.Count; i++)
                    {
                        parallelSeries.Points.AddXY(sections[i], parallelTimes[i]);
                    }
                }
            }
            else
            {
                MessageBox.Show("Параметры A и B заданы не корректно!");
            }
        }

        private void buttonRemoveStep_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Разбиение не выбрано!");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedIndex > -1)
            {
                this.buttonRemoveStep.Enabled = true;
            }
            else
            {
                this.buttonRemoveStep.Enabled = false;
            }
        }

        private void buttonAddSteps_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxSteps.Text, out int a) && int.Parse(textBoxSteps.Text) > 0)
            {
                listBox1.Items.Add(int.Parse(textBoxSteps.Text));

                List<int> items = new List<int>();
                foreach (var item in listBox1.Items)
                {
                    items.Add(Convert.ToInt32(item));
                }

                items.Sort();

                listBox1.Items.Clear();
                foreach (var item in items)
                {
                    listBox1.Items.Add(item.ToString());
                }
            }
            else
            {
                MessageBox.Show("Невозможно сохранить данный параметр!");
            }
        }

        private void textBoxSteps_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxSteps.Text, out int a) && int.Parse(textBoxSteps.Text) > 0)
            {
                buttonAddSteps.Enabled = true;
            }
            else
            {
                buttonAddSteps.Enabled = false;
            }
        }

        private double GetIntegrandValue(double x)
        {
            return 2 * x - Math.Log(2 * x) + 234;
        }
    }

    public enum Method
    {
        Rectangle,
        Trapeze,
        Simpson
    }
}
