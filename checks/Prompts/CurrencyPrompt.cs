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
    public partial class CurrencyPrompt : Form
    {
        public static PromptEventArgs ShowPrompt()
        {
            var p = new CurrencyPrompt();
            p.StartPosition = FormStartPosition.CenterParent;
            p.AcceptButton = p.OK;
            var dialogResult = p.ShowDialog();
            return new PromptEventArgs
            {
                ChoiceType = dialogResult == DialogResult.OK ? PromptChoice.OK : PromptChoice.Cancel,
                Item = p.currencyComboBox.SelectedItem.ToString(),
            };
        }
        public CurrencyPrompt()
        {
            InitializeComponent();
            OK.DialogResult = DialogResult.OK;
            Cancel.DialogResult = DialogResult.Cancel;
            currencyComboBox.SelectedIndex = 0;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
