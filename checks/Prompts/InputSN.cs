using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace checks
{
    public partial class InputSN : Form
    {
        public InputSN()
        {
            InitializeComponent();
            OKButton.DialogResult = DialogResult.OK;
            CancelButton.DialogResult = DialogResult.Cancel;
        }

        public static PromptEventArgs ShowPrompt(string lastCheckNumber = "1")
        {
            var p = new InputSN();
            if (long.TryParse(lastCheckNumber, out var checkNumber))
            {
                p.SNTextBox.Text = (checkNumber + 1).ToString();
            }
            else
            {
                p.SNTextBox.Text = lastCheckNumber;
            }

            p.StartPosition = FormStartPosition.CenterParent;
            p.AcceptButton = p.OKButton;
            var dialogResult = p.ShowDialog();

            var isNumber = (long.TryParse(p.SNTextBox.Text, out var number));
            if (!isNumber && dialogResult == DialogResult.OK)
            {
                MessageBox.Show(p,
                       "Check Number you entered is not a number numbering will start from 1",
                       "Warning",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Warning);
            }

            return new PromptEventArgs
            {
                ChoiceType = dialogResult == DialogResult.OK ? PromptChoice.OK : PromptChoice.Cancel,
                Item = p.SNTextBox.Text ?? string.Empty,
            };
        }
        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
