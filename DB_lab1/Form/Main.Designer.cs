namespace DB_lab1
{
    partial class Main
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
            dataGridView1 = new System.Windows.Forms.DataGridView();
            AddRow = new System.Windows.Forms.Button();
            comboBox1 = new System.Windows.Forms.ComboBox();
            Reload = new System.Windows.Forms.Button();
            Edit = new System.Windows.Forms.Button();
            Delete = new System.Windows.Forms.Button();
            Randomize = new System.Windows.Forms.Button();
            numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            Search = new System.Windows.Forms.Button();
            Statistic = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(64, 130);
            dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new System.Drawing.Size(672, 317);
            dataGridView1.TabIndex = 0;
            // 
            // AddRow
            // 
            AddRow.Location = new System.Drawing.Point(64, 63);
            AddRow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            AddRow.Name = "AddRow";
            AddRow.Size = new System.Drawing.Size(88, 27);
            AddRow.TabIndex = 1;
            AddRow.Text = "Add row";
            AddRow.UseVisualStyleBackColor = true;
            AddRow.Click += AddRow_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(595, 67);
            comboBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(140, 23);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Reload
            // 
            Reload.Location = new System.Drawing.Point(500, 63);
            Reload.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Reload.Name = "Reload";
            Reload.Size = new System.Drawing.Size(88, 27);
            Reload.TabIndex = 3;
            Reload.Text = "Reload";
            Reload.UseVisualStyleBackColor = true;
            Reload.Click += Reload_Click;
            // 
            // Edit
            // 
            Edit.Location = new System.Drawing.Point(159, 63);
            Edit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Edit.Name = "Edit";
            Edit.Size = new System.Drawing.Size(88, 27);
            Edit.TabIndex = 4;
            Edit.Text = "Edit";
            Edit.UseVisualStyleBackColor = true;
            Edit.Click += Edit_Click;
            // 
            // Delete
            // 
            Delete.Location = new System.Drawing.Point(254, 65);
            Delete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Delete.Name = "Delete";
            Delete.Size = new System.Drawing.Size(88, 27);
            Delete.TabIndex = 5;
            Delete.Text = "Delete";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // Randomize
            // 
            Randomize.Location = new System.Drawing.Point(793, 130);
            Randomize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Randomize.Name = "Randomize";
            Randomize.Size = new System.Drawing.Size(140, 27);
            Randomize.TabIndex = 7;
            Randomize.Text = "Randomize";
            Randomize.UseVisualStyleBackColor = true;
            Randomize.Click += Randomize_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new System.Drawing.Point(793, 164);
            numericUpDown1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new System.Drawing.Size(140, 23);
            numericUpDown1.TabIndex = 8;
            // 
            // Search
            // 
            Search.Location = new System.Drawing.Point(793, 63);
            Search.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Search.Name = "Search";
            Search.Size = new System.Drawing.Size(88, 27);
            Search.TabIndex = 9;
            Search.Text = "Search";
            Search.UseVisualStyleBackColor = true;
            Search.Click += Search_Click;
            // 
            // Statistic
            // 
            Statistic.Location = new System.Drawing.Point(793, 243);
            Statistic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Statistic.Name = "Statistic";
            Statistic.Size = new System.Drawing.Size(140, 27);
            Statistic.TabIndex = 10;
            Statistic.Text = "Statistic";
            Statistic.UseVisualStyleBackColor = true;
            Statistic.Click += Statistic_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(947, 519);
            Controls.Add(Statistic);
            Controls.Add(Search);
            Controls.Add(numericUpDown1);
            Controls.Add(Randomize);
            Controls.Add(Delete);
            Controls.Add(Edit);
            Controls.Add(Reload);
            Controls.Add(comboBox1);
            Controls.Add(AddRow);
            Controls.Add(dataGridView1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Main";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddRow;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Reload;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Randomize;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button Statistic;
    }
}

