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

        public static PromptEventArgs ShowPrompt()
        {
            var p = new InputSN();
            p.StartPosition = FormStartPosition.CenterParent;
            p.AcceptButton = p.OKButton;
            var dialogResult = p.ShowDialog();
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
