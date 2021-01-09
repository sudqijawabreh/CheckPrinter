namespace checks
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.nextRecordButton = new System.Windows.Forms.Button();
            this.previousRecordButton = new System.Windows.Forms.Button();
            this.recordNumberTextBox = new System.Windows.Forms.TextBox();
            this.recordsGrid = new System.Windows.Forms.DataGridView();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.SNButton = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.notNegoCheckBox = new System.Windows.Forms.CheckBox();
            this.exportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.recordsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(183, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(700, 311);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(100, 20);
            this.textBoxWidth.TabIndex = 3;
            this.textBoxWidth.Text = "21";
            this.textBoxWidth.Visible = false;
            this.textBoxWidth.TextChanged += new System.EventHandler(this.textBoxWidth_TextChanged);
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(700, 337);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(100, 20);
            this.textBoxHeight.TabIndex = 4;
            this.textBoxHeight.Text = "7.2";
            this.textBoxHeight.Visible = false;
            this.textBoxHeight.TextChanged += new System.EventHandler(this.textBoxHeight_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(806, 311);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Measure";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(595, 340);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Import";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Import_Click);
            // 
            // nextRecordButton
            // 
            this.nextRecordButton.Location = new System.Drawing.Point(485, 278);
            this.nextRecordButton.Name = "nextRecordButton";
            this.nextRecordButton.Size = new System.Drawing.Size(75, 23);
            this.nextRecordButton.TabIndex = 7;
            this.nextRecordButton.Text = "Next";
            this.nextRecordButton.UseVisualStyleBackColor = true;
            this.nextRecordButton.Click += new System.EventHandler(this.nextRecordButton_Click);
            // 
            // previousRecordButton
            // 
            this.previousRecordButton.Location = new System.Drawing.Point(286, 278);
            this.previousRecordButton.Name = "previousRecordButton";
            this.previousRecordButton.Size = new System.Drawing.Size(75, 23);
            this.previousRecordButton.TabIndex = 8;
            this.previousRecordButton.Text = "Previous";
            this.previousRecordButton.UseVisualStyleBackColor = true;
            this.previousRecordButton.Click += new System.EventHandler(this.previousRecordButton_Click);
            // 
            // recordNumberTextBox
            // 
            this.recordNumberTextBox.Location = new System.Drawing.Point(392, 278);
            this.recordNumberTextBox.Name = "recordNumberTextBox";
            this.recordNumberTextBox.Size = new System.Drawing.Size(63, 20);
            this.recordNumberTextBox.TabIndex = 9;
            this.recordNumberTextBox.Text = "1";
            this.recordNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.recordNumberTextBox.TextChanged += new System.EventHandler(this.recordNumberTextBox_TextChanged);
            // 
            // recordsGrid
            // 
            this.recordsGrid.AllowUserToAddRows = false;
            this.recordsGrid.AllowUserToDeleteRows = false;
            this.recordsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.recordsGrid.Location = new System.Drawing.Point(12, 379);
            this.recordsGrid.Name = "recordsGrid";
            this.recordsGrid.ReadOnly = true;
            this.recordsGrid.RowHeadersWidth = 100;
            this.recordsGrid.Size = new System.Drawing.Size(886, 226);
            this.recordsGrid.TabIndex = 10;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(273, 340);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(107, 23);
            this.SaveButton.TabIndex = 11;
            this.SaveButton.Text = "Save Positions";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(485, 340);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(104, 23);
            this.ResetButton.TabIndex = 12;
            this.ResetButton.Text = "Reset Positions";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(60, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(794, 260);
            this.pictureBox.TabIndex = 13;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseClick);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseUp);
            // 
            // SNButton
            // 
            this.SNButton.Location = new System.Drawing.Point(485, 309);
            this.SNButton.Name = "SNButton";
            this.SNButton.Size = new System.Drawing.Size(94, 23);
            this.SNButton.TabIndex = 14;
            this.SNButton.Text = "Set Starting SN";
            this.SNButton.UseVisualStyleBackColor = true;
            this.SNButton.Click += new System.EventHandler(this.SNButton_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(279, 314);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(101, 20);
            this.dateTimePicker.TabIndex = 16;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Check Date";
            // 
            // notNegoCheckBox
            // 
            this.notNegoCheckBox.AutoSize = true;
            this.notNegoCheckBox.Checked = true;
            this.notNegoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.notNegoCheckBox.Location = new System.Drawing.Point(60, 340);
            this.notNegoCheckBox.Name = "notNegoCheckBox";
            this.notNegoCheckBox.Size = new System.Drawing.Size(97, 17);
            this.notNegoCheckBox.TabIndex = 18;
            this.notNegoCheckBox.Text = "Not Negotiable";
            this.notNegoCheckBox.UseVisualStyleBackColor = true;
            this.notNegoCheckBox.CheckedChanged += new System.EventHandler(this.notNegoCheckBox_CheckedChanged);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(392, 340);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 19;
            this.exportButton.Text = "Export Report";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 623);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.notNegoCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.SNButton);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.recordsGrid);
            this.Controls.Add(this.recordNumberTextBox);
            this.Controls.Add(this.previousRecordButton);
            this.Controls.Add(this.nextRecordButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxHeight);
            this.Controls.Add(this.textBoxWidth);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check Printer";
            ((System.ComponentModel.ISupportInitialize)(this.recordsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button nextRecordButton;
        private System.Windows.Forms.Button previousRecordButton;
        private System.Windows.Forms.TextBox recordNumberTextBox;
        private System.Windows.Forms.DataGridView recordsGrid;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button SNButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox notNegoCheckBox;
        private System.Windows.Forms.Button exportButton;
    }
}

