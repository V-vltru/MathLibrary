namespace MatrixClient
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxMatrixParameters = new System.Windows.Forms.GroupBox();
            this.textBoxBColumns = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxBRows = new System.Windows.Forms.TextBox();
            this.textBoxAColumns = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxARows = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonFillMatrixes = new System.Windows.Forms.Button();
            this.groupBoxMatrixes = new System.Windows.Forms.GroupBox();
            this.labelOperation = new System.Windows.Forms.Label();
            this.dataGridViewB = new System.Windows.Forms.DataGridView();
            this.dataGridViewA = new System.Windows.Forms.DataGridView();
            this.buttonFillRandom = new System.Windows.Forms.Button();
            this.groupBoxOperations = new System.Windows.Forms.GroupBox();
            this.comboBoxOperation = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewResult = new System.Windows.Forms.DataGridView();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.labelState = new System.Windows.Forms.Label();
            this.checkBoxParallel = new System.Windows.Forms.CheckBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.buttonSaveCSV = new System.Windows.Forms.Button();
            this.saveFileDialogCSV = new System.Windows.Forms.SaveFileDialog();
            this.groupBoxMatrixParameters.SuspendLayout();
            this.groupBoxMatrixes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewA)).BeginInit();
            this.groupBoxOperations.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxMatrixParameters
            // 
            this.groupBoxMatrixParameters.Controls.Add(this.textBoxBColumns);
            this.groupBoxMatrixParameters.Controls.Add(this.label4);
            this.groupBoxMatrixParameters.Controls.Add(this.textBoxBRows);
            this.groupBoxMatrixParameters.Controls.Add(this.textBoxAColumns);
            this.groupBoxMatrixParameters.Controls.Add(this.label3);
            this.groupBoxMatrixParameters.Controls.Add(this.textBoxARows);
            this.groupBoxMatrixParameters.Controls.Add(this.label2);
            this.groupBoxMatrixParameters.Controls.Add(this.label1);
            this.groupBoxMatrixParameters.Location = new System.Drawing.Point(0, 0);
            this.groupBoxMatrixParameters.Name = "groupBoxMatrixParameters";
            this.groupBoxMatrixParameters.Size = new System.Drawing.Size(348, 82);
            this.groupBoxMatrixParameters.TabIndex = 0;
            this.groupBoxMatrixParameters.TabStop = false;
            this.groupBoxMatrixParameters.Text = "Параметры матриц";
            // 
            // textBoxBColumns
            // 
            this.textBoxBColumns.Location = new System.Drawing.Point(137, 54);
            this.textBoxBColumns.Name = "textBoxBColumns";
            this.textBoxBColumns.Size = new System.Drawing.Size(43, 20);
            this.textBoxBColumns.TabIndex = 6;
            this.textBoxBColumns.Text = "3";
            this.textBoxBColumns.TextChanged += new System.EventHandler(this.textBoxARows_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "X";
            // 
            // textBoxBRows
            // 
            this.textBoxBRows.Location = new System.Drawing.Point(69, 54);
            this.textBoxBRows.Name = "textBoxBRows";
            this.textBoxBRows.Size = new System.Drawing.Size(42, 20);
            this.textBoxBRows.TabIndex = 4;
            this.textBoxBRows.Text = "4";
            this.textBoxBRows.TextChanged += new System.EventHandler(this.textBoxARows_TextChanged);
            // 
            // textBoxAColumns
            // 
            this.textBoxAColumns.Location = new System.Drawing.Point(137, 27);
            this.textBoxAColumns.Name = "textBoxAColumns";
            this.textBoxAColumns.Size = new System.Drawing.Size(43, 20);
            this.textBoxAColumns.TabIndex = 3;
            this.textBoxAColumns.Text = "4";
            this.textBoxAColumns.TextChanged += new System.EventHandler(this.textBoxARows_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "X";
            // 
            // textBoxARows
            // 
            this.textBoxARows.Location = new System.Drawing.Point(69, 27);
            this.textBoxARows.Name = "textBoxARows";
            this.textBoxARows.Size = new System.Drawing.Size(42, 20);
            this.textBoxARows.TabIndex = 1;
            this.textBoxARows.Text = "3";
            this.textBoxARows.TextChanged += new System.EventHandler(this.textBoxARows_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Matrix B: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Matrix A: ";
            // 
            // buttonFillMatrixes
            // 
            this.buttonFillMatrixes.Location = new System.Drawing.Point(204, 30);
            this.buttonFillMatrixes.Name = "buttonFillMatrixes";
            this.buttonFillMatrixes.Size = new System.Drawing.Size(131, 40);
            this.buttonFillMatrixes.TabIndex = 1;
            this.buttonFillMatrixes.Text = "Заполнить!";
            this.buttonFillMatrixes.UseVisualStyleBackColor = true;
            this.buttonFillMatrixes.Click += new System.EventHandler(this.buttonFillMatrixes_Click);
            // 
            // groupBoxMatrixes
            // 
            this.groupBoxMatrixes.Controls.Add(this.labelOperation);
            this.groupBoxMatrixes.Controls.Add(this.dataGridViewB);
            this.groupBoxMatrixes.Controls.Add(this.dataGridViewA);
            this.groupBoxMatrixes.Location = new System.Drawing.Point(0, 103);
            this.groupBoxMatrixes.Name = "groupBoxMatrixes";
            this.groupBoxMatrixes.Size = new System.Drawing.Size(1184, 351);
            this.groupBoxMatrixes.TabIndex = 7;
            this.groupBoxMatrixes.TabStop = false;
            this.groupBoxMatrixes.Text = "Матрицы";
            // 
            // labelOperation
            // 
            this.labelOperation.AutoSize = true;
            this.labelOperation.Location = new System.Drawing.Point(575, 173);
            this.labelOperation.Name = "labelOperation";
            this.labelOperation.Size = new System.Drawing.Size(0, 13);
            this.labelOperation.TabIndex = 2;
            // 
            // dataGridViewB
            // 
            this.dataGridViewB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewB.Location = new System.Drawing.Point(671, 19);
            this.dataGridViewB.Name = "dataGridViewB";
            this.dataGridViewB.Size = new System.Drawing.Size(507, 326);
            this.dataGridViewB.TabIndex = 1;
            // 
            // dataGridViewA
            // 
            this.dataGridViewA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewA.Location = new System.Drawing.Point(12, 19);
            this.dataGridViewA.Name = "dataGridViewA";
            this.dataGridViewA.Size = new System.Drawing.Size(507, 326);
            this.dataGridViewA.TabIndex = 0;
            // 
            // buttonFillRandom
            // 
            this.buttonFillRandom.Location = new System.Drawing.Point(796, 17);
            this.buttonFillRandom.Name = "buttonFillRandom";
            this.buttonFillRandom.Size = new System.Drawing.Size(382, 67);
            this.buttonFillRandom.TabIndex = 8;
            this.buttonFillRandom.Text = "Заполнить случайно";
            this.buttonFillRandom.UseVisualStyleBackColor = true;
            this.buttonFillRandom.Click += new System.EventHandler(this.buttonFillRandom_Click);
            // 
            // groupBoxOperations
            // 
            this.groupBoxOperations.Controls.Add(this.comboBoxOperation);
            this.groupBoxOperations.Location = new System.Drawing.Point(364, 0);
            this.groupBoxOperations.Name = "groupBoxOperations";
            this.groupBoxOperations.Size = new System.Drawing.Size(362, 84);
            this.groupBoxOperations.TabIndex = 9;
            this.groupBoxOperations.TabStop = false;
            this.groupBoxOperations.Text = "Выбор операции";
            // 
            // comboBoxOperation
            // 
            this.comboBoxOperation.FormattingEnabled = true;
            this.comboBoxOperation.Items.AddRange(new object[] {
            "Сложение",
            "Умножение"});
            this.comboBoxOperation.Location = new System.Drawing.Point(6, 30);
            this.comboBoxOperation.Name = "comboBoxOperation";
            this.comboBoxOperation.Size = new System.Drawing.Size(350, 21);
            this.comboBoxOperation.TabIndex = 0;
            this.comboBoxOperation.SelectedIndexChanged += new System.EventHandler(this.comboBoxOperation_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewResult);
            this.groupBox1.Location = new System.Drawing.Point(671, 460);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 310);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Результат";
            // 
            // dataGridViewResult
            // 
            this.dataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResult.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewResult.Name = "dataGridViewResult";
            this.dataGridViewResult.Size = new System.Drawing.Size(504, 294);
            this.dataGridViewResult.TabIndex = 0;
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(12, 499);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(504, 68);
            this.buttonCalculate.TabIndex = 11;
            this.buttonCalculate.Text = "Рассчитать";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(12, 757);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(47, 13);
            this.labelState.TabIndex = 12;
            this.labelState.Text = "Статус: ";
            // 
            // checkBoxParallel
            // 
            this.checkBoxParallel.AutoSize = true;
            this.checkBoxParallel.Location = new System.Drawing.Point(12, 476);
            this.checkBoxParallel.Name = "checkBoxParallel";
            this.checkBoxParallel.Size = new System.Drawing.Size(204, 17);
            this.checkBoxParallel.TabIndex = 13;
            this.checkBoxParallel.Text = "Выполнить операцию параллельно";
            this.checkBoxParallel.UseVisualStyleBackColor = true;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(12, 722);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(46, 13);
            this.labelTime.TabIndex = 14;
            this.labelTime.Text = "Время: ";
            // 
            // buttonSaveCSV
            // 
            this.buttonSaveCSV.Location = new System.Drawing.Point(12, 583);
            this.buttonSaveCSV.Name = "buttonSaveCSV";
            this.buttonSaveCSV.Size = new System.Drawing.Size(204, 23);
            this.buttonSaveCSV.TabIndex = 15;
            this.buttonSaveCSV.Text = "Сохранить в .csv";
            this.buttonSaveCSV.UseVisualStyleBackColor = true;
            this.buttonSaveCSV.Click += new System.EventHandler(this.buttonSaveCSV_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 782);
            this.Controls.Add(this.buttonSaveCSV);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.checkBoxParallel);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxOperations);
            this.Controls.Add(this.buttonFillRandom);
            this.Controls.Add(this.groupBoxMatrixes);
            this.Controls.Add(this.buttonFillMatrixes);
            this.Controls.Add(this.groupBoxMatrixParameters);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBoxMatrixParameters.ResumeLayout(false);
            this.groupBoxMatrixParameters.PerformLayout();
            this.groupBoxMatrixes.ResumeLayout(false);
            this.groupBoxMatrixes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewA)).EndInit();
            this.groupBoxOperations.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMatrixParameters;
        private System.Windows.Forms.TextBox textBoxAColumns;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxARows;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBColumns;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxBRows;
        private System.Windows.Forms.Button buttonFillMatrixes;
        private System.Windows.Forms.GroupBox groupBoxMatrixes;
        private System.Windows.Forms.DataGridView dataGridViewB;
        private System.Windows.Forms.DataGridView dataGridViewA;
        private System.Windows.Forms.Button buttonFillRandom;
        private System.Windows.Forms.GroupBox groupBoxOperations;
        private System.Windows.Forms.ComboBox comboBoxOperation;
        private System.Windows.Forms.Label labelOperation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewResult;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.CheckBox checkBoxParallel;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Button buttonSaveCSV;
        private System.Windows.Forms.SaveFileDialog saveFileDialogCSV;
    }
}

