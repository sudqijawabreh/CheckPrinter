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
    public partial class ChooseSheet : Form
    {
        public static PromptEventArgs ShowPrompt(List<string> items)
        {
            var p = new ChooseSheet(items);
            p.StartPosition = FormStartPosition.CenterParent;
            p.AcceptButton = p.SheetOK;
            var dialogResult = p.ShowDialog();
            return new PromptEventArgs
            {
                ChoiceType = dialogResult == DialogResult.OK ? PromptChoice.OK : PromptChoice.Cancel,
                Item = p.SheetCombo.SelectedItem.ToString() ?? string.Empty,
            };
        }
        public ChooseSheet(List<string> sheets)
        {
            InitializeComponent();
            SheetCombo.Items.AddRange(sheets.ToArray());
            if(SheetCombo.Items.Count > 0)
                SheetCombo.SelectedIndex = 0;
            SheetOK.DialogResult = DialogResult.OK;
            SheetCancel.DialogResult = DialogResult.Cancel;
        }

        private void SheetOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SheetCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
