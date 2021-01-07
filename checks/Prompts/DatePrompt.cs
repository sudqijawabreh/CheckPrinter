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
    public partial class DatePrompt : Form
    {
        public static PromptEventArgs ShowPrompt(List<string> items)
        {
            var p = new DatePrompt(items);
            p.StartPosition = FormStartPosition.CenterParent;
            p.AcceptButton = p.OK;
            var dialogResult = p.ShowDialog();
            return new PromptEventArgs
            {
                ChoiceType = dialogResult == DialogResult.OK ? PromptChoice.OK : PromptChoice.Cancel,
                Item = p.dateTimePicker.Value.ToString() ?? DateTime.Now.ToString(),
            };
        }
        public DatePrompt(List<string> sheets)
        {
            InitializeComponent();
            OK.DialogResult = DialogResult.OK;
            Cancel.DialogResult = DialogResult.Cancel;
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
