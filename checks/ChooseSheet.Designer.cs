namespace checks
{
    partial class ChooseSheet
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
            this.SheetCombo = new System.Windows.Forms.ComboBox();
            this.SheetOK = new System.Windows.Forms.Button();
            this.SheetCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SheetCombo
            // 
            this.SheetCombo.FormattingEnabled = true;
            this.SheetCombo.Location = new System.Drawing.Point(12, 57);
            this.SheetCombo.Name = "SheetCombo";
            this.SheetCombo.Size = new System.Drawing.Size(121, 21);
            this.SheetCombo.TabIndex = 0;
            // 
            // SheetOK
            // 
            this.SheetOK.Location = new System.Drawing.Point(152, 51);
            this.SheetOK.Name = "SheetOK";
            this.SheetOK.Size = new System.Drawing.Size(98, 30);
            this.SheetOK.TabIndex = 1;
            this.SheetOK.Text = "OK";
            this.SheetOK.UseVisualStyleBackColor = true;
            this.SheetOK.Click += new System.EventHandler(this.SheetOK_Click);
            // 
            // SheetCancel
            // 
            this.SheetCancel.Location = new System.Drawing.Point(271, 51);
            this.SheetCancel.Name = "SheetCancel";
            this.SheetCancel.Size = new System.Drawing.Size(85, 30);
            this.SheetCancel.TabIndex = 2;
            this.SheetCancel.Text = "Cancel";
            this.SheetCancel.UseVisualStyleBackColor = true;
            this.SheetCancel.Click += new System.EventHandler(this.SheetCancel_Click);
            // 
            // ChooseSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 119);
            this.Controls.Add(this.SheetCancel);
            this.Controls.Add(this.SheetOK);
            this.Controls.Add(this.SheetCombo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseSheet";
            this.Text = "ChooseSheet";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox SheetCombo;
        private System.Windows.Forms.Button SheetOK;
        private System.Windows.Forms.Button SheetCancel;
    }
}