﻿namespace checks
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.recordNumberTextBox = new System.Windows.Forms.TextBox();
            this.recordsGrid = new System.Windows.Forms.DataGridView();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.changeCurrencyButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.negotiableButton = new System.Windows.Forms.Button();
            this.changeDateButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.previousRecordButton = new System.Windows.Forms.Button();
            this.nextRecordButton = new System.Windows.Forms.Button();
            this.SNButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.smallPreviousButton = new System.Windows.Forms.Button();
            this.smallNextButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.recordsGrid)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(925, 553);
            this.textBoxWidth.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(132, 22);
            this.textBoxWidth.TabIndex = 3;
            this.textBoxWidth.Text = "21";
            this.textBoxWidth.Visible = false;
            this.textBoxWidth.TextChanged += new System.EventHandler(this.textBoxWidth_TextChanged);
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(925, 553);
            this.textBoxHeight.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(132, 22);
            this.textBoxHeight.TabIndex = 4;
            this.textBoxHeight.Text = "7.2";
            this.textBoxHeight.Visible = false;
            this.textBoxHeight.TextChanged += new System.EventHandler(this.textBoxHeight_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1067, 550);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 5;
            this.button2.Text = "Measure";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // recordNumberTextBox
            // 
            this.recordNumberTextBox.Location = new System.Drawing.Point(573, 449);
            this.recordNumberTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.recordNumberTextBox.Name = "recordNumberTextBox";
            this.recordNumberTextBox.Size = new System.Drawing.Size(83, 22);
            this.recordNumberTextBox.TabIndex = 9;
            this.recordNumberTextBox.Text = "1";
            this.recordNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.recordNumberTextBox.TextChanged += new System.EventHandler(this.recordNumberTextBox_TextChanged);
            // 
            // recordsGrid
            // 
            this.recordsGrid.AllowUserToAddRows = false;
            this.recordsGrid.AllowUserToDeleteRows = false;
            this.recordsGrid.ColumnHeadersHeight = 29;
            this.recordsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.recordsGrid.Location = new System.Drawing.Point(16, 542);
            this.recordsGrid.Margin = new System.Windows.Forms.Padding(4);
            this.recordsGrid.Name = "recordsGrid";
            this.recordsGrid.RowHeadersWidth = 100;
            this.recordsGrid.Size = new System.Drawing.Size(1228, 292);
            this.recordsGrid.TabIndex = 10;
            this.recordsGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.recordsGrid_CellDoubleClick);
            this.recordsGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.recordsGrid_CellEndEdit);
            this.recordsGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.recordsGrid_DataBindingComplete);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(967, 449);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(143, 28);
            this.SaveButton.TabIndex = 11;
            this.SaveButton.Text = "Save Positions";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Visible = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(792, 452);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(4);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(139, 28);
            this.ResetButton.TabIndex = 12;
            this.ResetButton.Text = "Reset Positions";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Visible = false;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.changeCurrencyButton);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.negotiableButton);
            this.panel1.Controls.Add(this.changeDateButton);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.exportButton);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.previousRecordButton);
            this.panel1.Controls.Add(this.nextRecordButton);
            this.panel1.Controls.Add(this.SNButton);
            this.panel1.Location = new System.Drawing.Point(85, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1066, 62);
            this.panel1.TabIndex = 20;
            // 
            // changeCurrencyButton
            // 
            this.changeCurrencyButton.BackgroundImage = global::checks.Properties.Resources.currency_exchange_pngrepo_com1;
            this.changeCurrencyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.changeCurrencyButton.Location = new System.Drawing.Point(700, 4);
            this.changeCurrencyButton.Margin = new System.Windows.Forms.Padding(4);
            this.changeCurrencyButton.Name = "changeCurrencyButton";
            this.changeCurrencyButton.Size = new System.Drawing.Size(69, 50);
            this.changeCurrencyButton.TabIndex = 23;
            this.changeCurrencyButton.UseVisualStyleBackColor = true;
            this.changeCurrencyButton.Click += new System.EventHandler(this.changeCurrencyButton_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::checks.Properties.Resources.history_pngrepo_com;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(901, 4);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(69, 50);
            this.button4.TabIndex = 22;
            this.toolTip1.SetToolTip(this.button4, "Show Print History");
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // negotiableButton
            // 
            this.negotiableButton.BackgroundImage = global::checks.Properties.Resources.stamp_pngrepo_com;
            this.negotiableButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.negotiableButton.Location = new System.Drawing.Point(796, 4);
            this.negotiableButton.Margin = new System.Windows.Forms.Padding(4);
            this.negotiableButton.Name = "negotiableButton";
            this.negotiableButton.Size = new System.Drawing.Size(69, 50);
            this.negotiableButton.TabIndex = 21;
            this.toolTip1.SetToolTip(this.negotiableButton, "Show or Hide Not Negotiable Stamp");
            this.negotiableButton.UseVisualStyleBackColor = true;
            this.negotiableButton.Click += new System.EventHandler(this.negotiableButton_Click);
            // 
            // changeDateButton
            // 
            this.changeDateButton.BackgroundImage = global::checks.Properties.Resources.calendar_pngrepo_com;
            this.changeDateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.changeDateButton.Location = new System.Drawing.Point(508, 4);
            this.changeDateButton.Margin = new System.Windows.Forms.Padding(4);
            this.changeDateButton.Name = "changeDateButton";
            this.changeDateButton.Size = new System.Drawing.Size(69, 50);
            this.changeDateButton.TabIndex = 21;
            this.toolTip1.SetToolTip(this.changeDateButton, "Change Check Date");
            this.changeDateButton.UseVisualStyleBackColor = true;
            this.changeDateButton.Click += new System.EventHandler(this.changeDateButton_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::checks.Properties.Resources.print_pngrepo_com;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(236, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 50);
            this.button1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button1, "Print Preview Checks");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // exportButton
            // 
            this.exportButton.BackgroundImage = global::checks.Properties.Resources.excel_file_pngrepo_com;
            this.exportButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exportButton.Location = new System.Drawing.Point(145, 4);
            this.exportButton.Margin = new System.Windows.Forms.Padding(4);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(69, 50);
            this.exportButton.TabIndex = 19;
            this.toolTip1.SetToolTip(this.exportButton, "Generate Excel Report");
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::checks.Properties.Resources.open_folder_with_document_pngrepo_com;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(44, 4);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 50);
            this.button3.TabIndex = 6;
            this.toolTip1.SetToolTip(this.button3, "Open Excel File");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Import_Click);
            // 
            // previousRecordButton
            // 
            this.previousRecordButton.BackgroundImage = global::checks.Properties.Resources.left_arrow_pngrepo_com1;
            this.previousRecordButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.previousRecordButton.Location = new System.Drawing.Point(325, 4);
            this.previousRecordButton.Margin = new System.Windows.Forms.Padding(4);
            this.previousRecordButton.Name = "previousRecordButton";
            this.previousRecordButton.Size = new System.Drawing.Size(69, 50);
            this.previousRecordButton.TabIndex = 8;
            this.toolTip1.SetToolTip(this.previousRecordButton, "Previous Check");
            this.previousRecordButton.UseVisualStyleBackColor = true;
            this.previousRecordButton.Click += new System.EventHandler(this.previousRecordButton_Click);
            // 
            // nextRecordButton
            // 
            this.nextRecordButton.BackgroundImage = global::checks.Properties.Resources.right_arrow_pngrepo_com;
            this.nextRecordButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nextRecordButton.Location = new System.Drawing.Point(416, 4);
            this.nextRecordButton.Margin = new System.Windows.Forms.Padding(4);
            this.nextRecordButton.Name = "nextRecordButton";
            this.nextRecordButton.Size = new System.Drawing.Size(69, 50);
            this.nextRecordButton.TabIndex = 7;
            this.nextRecordButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.nextRecordButton, "Next Check");
            this.nextRecordButton.UseVisualStyleBackColor = true;
            this.nextRecordButton.Click += new System.EventHandler(this.nextRecordButton_Click);
            // 
            // SNButton
            // 
            this.SNButton.BackgroundImage = global::checks.Properties.Resources.license_plate_number_pngrepo_com;
            this.SNButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SNButton.Location = new System.Drawing.Point(608, 4);
            this.SNButton.Margin = new System.Windows.Forms.Padding(4);
            this.SNButton.Name = "SNButton";
            this.SNButton.Size = new System.Drawing.Size(69, 50);
            this.SNButton.TabIndex = 14;
            this.toolTip1.SetToolTip(this.SNButton, "Change Starting Serial Number");
            this.SNButton.UseVisualStyleBackColor = true;
            this.SNButton.Click += new System.EventHandler(this.SNButton_Click);
            // 
            // smallPreviousButton
            // 
            this.smallPreviousButton.BackgroundImage = global::checks.Properties.Resources.left_arrow_pngrepo_com1;
            this.smallPreviousButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smallPreviousButton.Location = new System.Drawing.Point(489, 443);
            this.smallPreviousButton.Margin = new System.Windows.Forms.Padding(4);
            this.smallPreviousButton.Name = "smallPreviousButton";
            this.smallPreviousButton.Size = new System.Drawing.Size(53, 37);
            this.smallPreviousButton.TabIndex = 22;
            this.smallPreviousButton.UseVisualStyleBackColor = true;
            this.smallPreviousButton.Click += new System.EventHandler(this.previousRecordButton_Click);
            // 
            // smallNextButton
            // 
            this.smallNextButton.BackgroundImage = global::checks.Properties.Resources.right_arrow_pngrepo_com;
            this.smallNextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smallNextButton.Location = new System.Drawing.Point(681, 443);
            this.smallNextButton.Margin = new System.Windows.Forms.Padding(4);
            this.smallNextButton.Name = "smallNextButton";
            this.smallNextButton.Size = new System.Drawing.Size(53, 37);
            this.smallNextButton.TabIndex = 22;
            this.smallNextButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.smallNextButton.UseVisualStyleBackColor = true;
            this.smallNextButton.Click += new System.EventHandler(this.nextRecordButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.InitialImage = global::checks.Properties.Resources.full_check;
            this.pictureBox.Location = new System.Drawing.Point(85, 105);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1058, 320);
            this.pictureBox.TabIndex = 13;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseClick);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseUp);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(363, 508);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(780, 22);
            this.searchTextBox.TabIndex = 23;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searcTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 512);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Search By";
            // 
            // searchComboBox
            // 
            this.searchComboBox.FormattingEnabled = true;
            this.searchComboBox.Location = new System.Drawing.Point(161, 507);
            this.searchComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.searchComboBox.Name = "searchComboBox";
            this.searchComboBox.Size = new System.Drawing.Size(160, 24);
            this.searchComboBox.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1157, 837);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Records:";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(1220, 837);
            this.countLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(16, 17);
            this.countLabel.TabIndex = 27;
            this.countLabel.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 855);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.recordsGrid);
            this.Controls.Add(this.smallPreviousButton);
            this.Controls.Add(this.smallNextButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.recordNumberTextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxHeight);
            this.Controls.Add(this.textBoxWidth);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check Printer";
            ((System.ComponentModel.ISupportInitialize)(this.recordsGrid)).EndInit();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button changeDateButton;
        private System.Windows.Forms.Button negotiableButton;
        private System.Windows.Forms.Button smallNextButton;
        private System.Windows.Forms.Button smallPreviousButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button changeCurrencyButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox searchComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label countLabel;
    }
}

