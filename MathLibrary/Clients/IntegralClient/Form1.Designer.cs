namespace IntegralClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBoxParameters = new System.Windows.Forms.GroupBox();
            this.checkBoxLambda = new System.Windows.Forms.CheckBox();
            this.checkBoxParallelMode = new System.Windows.Forms.CheckBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxMethods = new System.Windows.Forms.ComboBox();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.buttonRemoveStep = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonAddSteps = new System.Windows.Forms.Button();
            this.textBoxSteps = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.chartResult = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBoxFunction = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartResult)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxParameters
            // 
            this.groupBoxParameters.Controls.Add(this.label5);
            this.groupBoxParameters.Controls.Add(this.textBoxFunction);
            this.groupBoxParameters.Controls.Add(this.checkBoxLambda);
            this.groupBoxParameters.Controls.Add(this.checkBoxParallelMode);
            this.groupBoxParameters.Controls.Add(this.labelResult);
            this.groupBoxParameters.Controls.Add(this.label4);
            this.groupBoxParameters.Controls.Add(this.comboBoxMethods);
            this.groupBoxParameters.Controls.Add(this.buttonCalculate);
            this.groupBoxParameters.Controls.Add(this.buttonRemoveStep);
            this.groupBoxParameters.Controls.Add(this.listBox1);
            this.groupBoxParameters.Controls.Add(this.buttonAddSteps);
            this.groupBoxParameters.Controls.Add(this.textBoxSteps);
            this.groupBoxParameters.Controls.Add(this.label3);
            this.groupBoxParameters.Controls.Add(this.label1);
            this.groupBoxParameters.Controls.Add(this.label2);
            this.groupBoxParameters.Controls.Add(this.textBoxB);
            this.groupBoxParameters.Controls.Add(this.textBoxA);
            this.groupBoxParameters.Location = new System.Drawing.Point(12, 12);
            this.groupBoxParameters.Name = "groupBoxParameters";
            this.groupBoxParameters.Size = new System.Drawing.Size(329, 534);
            this.groupBoxParameters.TabIndex = 0;
            this.groupBoxParameters.TabStop = false;
            this.groupBoxParameters.Text = "Параметры интеграла";
            // 
            // checkBoxLambda
            // 
            this.checkBoxLambda.AutoSize = true;
            this.checkBoxLambda.Location = new System.Drawing.Point(183, 86);
            this.checkBoxLambda.Name = "checkBoxLambda";
            this.checkBoxLambda.Size = new System.Drawing.Size(151, 17);
            this.checkBoxLambda.TabIndex = 11;
            this.checkBoxLambda.Text = "Исп. лямбда выражение";
            this.checkBoxLambda.UseVisualStyleBackColor = true;
            // 
            // checkBoxParallelMode
            // 
            this.checkBoxParallelMode.AutoSize = true;
            this.checkBoxParallelMode.Checked = true;
            this.checkBoxParallelMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxParallelMode.Location = new System.Drawing.Point(183, 60);
            this.checkBoxParallelMode.Name = "checkBoxParallelMode";
            this.checkBoxParallelMode.Size = new System.Drawing.Size(135, 17);
            this.checkBoxParallelMode.TabIndex = 10;
            this.checkBoxParallelMode.Text = "Считать параллельно";
            this.checkBoxParallelMode.UseVisualStyleBackColor = true;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(10, 456);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(59, 13);
            this.labelResult.TabIndex = 9;
            this.labelResult.Text = "Резултат: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Метод:";
            // 
            // comboBoxMethods
            // 
            this.comboBoxMethods.FormattingEnabled = true;
            this.comboBoxMethods.Items.AddRange(new object[] {
            "Прямоугольников",
            "Трапеций",
            "Парабол"});
            this.comboBoxMethods.Location = new System.Drawing.Point(61, 121);
            this.comboBoxMethods.Name = "comboBoxMethods";
            this.comboBoxMethods.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMethods.TabIndex = 2;
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(6, 472);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(207, 56);
            this.buttonCalculate.TabIndex = 1;
            this.buttonCalculate.Text = "Считать!";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // buttonRemoveStep
            // 
            this.buttonRemoveStep.Location = new System.Drawing.Point(9, 414);
            this.buttonRemoveStep.Name = "buttonRemoveStep";
            this.buttonRemoveStep.Size = new System.Drawing.Size(204, 23);
            this.buttonRemoveStep.TabIndex = 7;
            this.buttonRemoveStep.Text = "Удалить разбиение";
            this.buttonRemoveStep.UseVisualStyleBackColor = true;
            this.buttonRemoveStep.Click += new System.EventHandler(this.buttonRemoveStep_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "1000",
            "10000",
            "100000",
            "500000",
            "1000000",
            "5000000",
            "10000000"});
            this.listBox1.Location = new System.Drawing.Point(9, 196);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(204, 212);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // buttonAddSteps
            // 
            this.buttonAddSteps.Location = new System.Drawing.Point(230, 164);
            this.buttonAddSteps.Name = "buttonAddSteps";
            this.buttonAddSteps.Size = new System.Drawing.Size(75, 23);
            this.buttonAddSteps.TabIndex = 6;
            this.buttonAddSteps.Text = "Добавить";
            this.buttonAddSteps.UseVisualStyleBackColor = true;
            this.buttonAddSteps.Click += new System.EventHandler(this.buttonAddSteps_Click);
            // 
            // textBoxSteps
            // 
            this.textBoxSteps.Location = new System.Drawing.Point(112, 166);
            this.textBoxSteps.Name = "textBoxSteps";
            this.textBoxSteps.Size = new System.Drawing.Size(100, 20);
            this.textBoxSteps.TabIndex = 5;
            this.textBoxSteps.TextChanged += new System.EventHandler(this.textBoxSteps_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Кол-во разбиений:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "A:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "B:";
            // 
            // textBoxB
            // 
            this.textBoxB.Location = new System.Drawing.Point(61, 84);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(100, 20);
            this.textBoxB.TabIndex = 2;
            this.textBoxB.Text = "1000";
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(61, 58);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(100, 20);
            this.textBoxA.TabIndex = 1;
            this.textBoxA.Text = "1";
            // 
            // chartResult
            // 
            chartArea1.Name = "ChartArea1";
            this.chartResult.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartResult.Legends.Add(legend1);
            this.chartResult.Location = new System.Drawing.Point(347, 12);
            this.chartResult.Name = "chartResult";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartResult.Series.Add(series1);
            this.chartResult.Size = new System.Drawing.Size(659, 534);
            this.chartResult.TabIndex = 1;
            this.chartResult.Text = "chart1";
            // 
            // textBoxFunction
            // 
            this.textBoxFunction.Location = new System.Drawing.Point(61, 32);
            this.textBoxFunction.Name = "textBoxFunction";
            this.textBoxFunction.Size = new System.Drawing.Size(244, 20);
            this.textBoxFunction.TabIndex = 12;
            this.textBoxFunction.Text = "x*x";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "F(x) = ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 558);
            this.Controls.Add(this.chartResult);
            this.Controls.Add(this.groupBoxParameters);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBoxParameters.ResumeLayout(false);
            this.groupBoxParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxParameters;
        private System.Windows.Forms.TextBox textBoxSteps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Button buttonRemoveStep;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonAddSteps;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxMethods;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.CheckBox checkBoxLambda;
        private System.Windows.Forms.CheckBox checkBoxParallelMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxFunction;
    }
}

