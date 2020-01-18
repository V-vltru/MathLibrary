namespace InterpolationClient
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownSteps = new System.Windows.Forms.NumericUpDown();
            this.textBoxTo = new System.Windows.Forms.TextBox();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.textBoxExpression = new System.Windows.Forms.TextBox();
            this.buttonSetGraph = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxParallelMode = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxInterpolationType = new System.Windows.Forms.ComboBox();
            this.chartFunction = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxRemoveTo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxRemoveFrom = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownRemoveCount = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonRemoveAndBuildGraph = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonInterpolate = new System.Windows.Forms.Button();
            this.saveFileDialogInitialPoints = new System.Windows.Forms.SaveFileDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSteps)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFunction)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRemoveCount)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDownSteps);
            this.groupBox1.Controls.Add(this.textBoxTo);
            this.groupBox1.Controls.Add(this.textBoxFrom);
            this.groupBox1.Controls.Add(this.textBoxExpression);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Начальные значения";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Steps:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "To: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "From: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "F(X) = ";
            // 
            // numericUpDownSteps
            // 
            this.numericUpDownSteps.Location = new System.Drawing.Point(49, 143);
            this.numericUpDownSteps.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownSteps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSteps.Name = "numericUpDownSteps";
            this.numericUpDownSteps.Size = new System.Drawing.Size(98, 20);
            this.numericUpDownSteps.TabIndex = 3;
            this.numericUpDownSteps.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // textBoxTo
            // 
            this.textBoxTo.Location = new System.Drawing.Point(47, 108);
            this.textBoxTo.Name = "textBoxTo";
            this.textBoxTo.Size = new System.Drawing.Size(100, 20);
            this.textBoxTo.TabIndex = 2;
            this.textBoxTo.Text = "2";
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Location = new System.Drawing.Point(47, 73);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(100, 20);
            this.textBoxFrom.TabIndex = 1;
            this.textBoxFrom.Text = "-2";
            // 
            // textBoxExpression
            // 
            this.textBoxExpression.Location = new System.Drawing.Point(47, 38);
            this.textBoxExpression.Name = "textBoxExpression";
            this.textBoxExpression.Size = new System.Drawing.Size(190, 20);
            this.textBoxExpression.TabIndex = 0;
            this.textBoxExpression.Text = "x*x";
            // 
            // buttonSetGraph
            // 
            this.buttonSetGraph.Location = new System.Drawing.Point(12, 206);
            this.buttonSetGraph.Name = "buttonSetGraph";
            this.buttonSetGraph.Size = new System.Drawing.Size(193, 57);
            this.buttonSetGraph.TabIndex = 1;
            this.buttonSetGraph.Text = "Построить график";
            this.buttonSetGraph.UseVisualStyleBackColor = true;
            this.buttonSetGraph.Click += new System.EventHandler(this.buttonSetGraph_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxParallelMode);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.comboBoxInterpolationType);
            this.groupBox2.Location = new System.Drawing.Point(12, 283);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 76);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Интерполяция";
            // 
            // checkBoxParallelMode
            // 
            this.checkBoxParallelMode.AutoSize = true;
            this.checkBoxParallelMode.Location = new System.Drawing.Point(180, 31);
            this.checkBoxParallelMode.Name = "checkBoxParallelMode";
            this.checkBoxParallelMode.Size = new System.Drawing.Size(89, 17);
            this.checkBoxParallelMode.TabIndex = 9;
            this.checkBoxParallelMode.Text = "Parallel mode";
            this.checkBoxParallelMode.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Тип:";
            // 
            // comboBoxInterpolationType
            // 
            this.comboBoxInterpolationType.FormattingEnabled = true;
            this.comboBoxInterpolationType.Location = new System.Drawing.Point(44, 29);
            this.comboBoxInterpolationType.Name = "comboBoxInterpolationType";
            this.comboBoxInterpolationType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxInterpolationType.TabIndex = 7;
            // 
            // chartFunction
            // 
            chartArea1.Name = "ChartArea1";
            this.chartFunction.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartFunction.Legends.Add(legend1);
            this.chartFunction.Location = new System.Drawing.Point(341, 12);
            this.chartFunction.Name = "chartFunction";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartFunction.Series.Add(series1);
            this.chartFunction.Size = new System.Drawing.Size(648, 457);
            this.chartFunction.TabIndex = 3;
            this.chartFunction.Text = "chart1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxRemoveTo);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBoxRemoveFrom);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.numericUpDownRemoveCount);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(341, 478);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(648, 68);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Удаление данных";
            // 
            // textBoxRemoveTo
            // 
            this.textBoxRemoveTo.Location = new System.Drawing.Point(347, 28);
            this.textBoxRemoveTo.Name = "textBoxRemoveTo";
            this.textBoxRemoveTo.Size = new System.Drawing.Size(35, 20);
            this.textBoxRemoveTo.TabIndex = 5;
            this.textBoxRemoveTo.Text = "1.5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(332, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "до";
            // 
            // textBoxRemoveFrom
            // 
            this.textBoxRemoveFrom.Location = new System.Drawing.Point(294, 28);
            this.textBoxRemoveFrom.Name = "textBoxRemoveFrom";
            this.textBoxRemoveFrom.Size = new System.Drawing.Size(32, 20);
            this.textBoxRemoveFrom.TabIndex = 3;
            this.textBoxRemoveFrom.Text = "-1.5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(182, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "точек в диапазоне от";
            // 
            // numericUpDownRemoveCount
            // 
            this.numericUpDownRemoveCount.Location = new System.Drawing.Point(122, 29);
            this.numericUpDownRemoveCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRemoveCount.Name = "numericUpDownRemoveCount";
            this.numericUpDownRemoveCount.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownRemoveCount.TabIndex = 1;
            this.numericUpDownRemoveCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Удалить случайные ";
            // 
            // buttonRemoveAndBuildGraph
            // 
            this.buttonRemoveAndBuildGraph.Location = new System.Drawing.Point(341, 552);
            this.buttonRemoveAndBuildGraph.Name = "buttonRemoveAndBuildGraph";
            this.buttonRemoveAndBuildGraph.Size = new System.Drawing.Size(648, 36);
            this.buttonRemoveAndBuildGraph.TabIndex = 5;
            this.buttonRemoveAndBuildGraph.Text = "Удалить и построить график";
            this.buttonRemoveAndBuildGraph.UseVisualStyleBackColor = true;
            this.buttonRemoveAndBuildGraph.Click += new System.EventHandler(this.buttonRemoveAndBuildGraph_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(211, 206);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(124, 57);
            this.buttonExport.TabIndex = 6;
            this.buttonExport.Text = "Экспорт точек";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonInterpolate
            // 
            this.buttonInterpolate.Location = new System.Drawing.Point(12, 365);
            this.buttonInterpolate.Name = "buttonInterpolate";
            this.buttonInterpolate.Size = new System.Drawing.Size(323, 58);
            this.buttonInterpolate.TabIndex = 7;
            this.buttonInterpolate.Text = "Считать и построить график";
            this.buttonInterpolate.UseVisualStyleBackColor = true;
            this.buttonInterpolate.Click += new System.EventHandler(this.buttonInterpolate_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 578);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Time: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 600);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.buttonInterpolate);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonRemoveAndBuildGraph);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.chartFunction);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonSetGraph);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSteps)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFunction)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRemoveCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownSteps;
        private System.Windows.Forms.TextBox textBoxTo;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.TextBox textBoxExpression;
        private System.Windows.Forms.Button buttonSetGraph;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFunction;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownRemoveCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxInterpolationType;
        private System.Windows.Forms.TextBox textBoxRemoveTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxRemoveFrom;
        private System.Windows.Forms.Button buttonRemoveAndBuildGraph;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonInterpolate;
        private System.Windows.Forms.SaveFileDialog saveFileDialogInitialPoints;
        private System.Windows.Forms.CheckBox checkBoxParallelMode;
        private System.Windows.Forms.Label label9;
    }
}

