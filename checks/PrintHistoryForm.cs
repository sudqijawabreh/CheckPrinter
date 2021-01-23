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
    public partial class PrintHistoryForm : Form
    {
        private List<CheckRecord> _records;
        private List<string> searchIFields = new List<string> { "Name", "Check Number","ID Number", "Print Date", "Check Date" , "Amount"};
        public PrintHistoryForm(List<CheckRecord> records)
        {
            InitializeComponent();
            _records = records;
            this.historyGridView.ReadOnly = true;
            UpdateGridView(_records);
            historyGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            historyGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            historyGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            historyGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            historyGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            historyGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            historyGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            historyGridView.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            historyGridView.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            fieldDropdown.Items.AddRange(searchIFields.ToArray());
            fieldDropdown.SelectedIndex = 0;

        }

        private void History_Load(object sender, EventArgs e)
        {

        }
        private void UpdateGridView(List<CheckRecord> records)
        {

            var bindingList = new BindingList<HistoryGridRecord>(records.Select(r => new HistoryGridRecord
            {
                Number = r.Number,
                SN = r.SN,
                Name = r.Name,
                Amount = r.Amount,
                CheckDate = r.CheckDate,
                PrintDate = r.PrintDate,
                Currency = r.Currency,
                Area = r.Area,
                IDNumber = r.IDNumber
            }).ToList());
            var _bindingSource = new BindingSource(bindingList, null);
            historyGridView.DataSource = _bindingSource;
        }
        class HistoryGridRecord
        {
            public int Number { get; set; }
            public string SN { get; set; }
            public string Name { get; set; }
            public string Amount { get; set; }
            public string CheckDate { get; set; }
            public string PrintDate { get; set; }
            public string Currency { get; set; }
            public string Area { get; set; }
            public string IDNumber { get; set; }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            var filterdRecords = GetFilteredRecords(_records);
            UpdateGridView(filterdRecords);
        }

        private List<CheckRecord> GetFilteredRecords(List<CheckRecord> records)
        {
            var selector = new Func<CheckRecord, bool>(r => true);
            var searchText = searchTextBox.Text.ToLower();
            if ((fieldDropdown.SelectedItem as string) == "Name")
            {
                selector = new Func<CheckRecord, bool>(r => r.Name.ToLower().Contains(searchText));
            }
            else if ((fieldDropdown.SelectedItem as string) == "ID Number")
            {
                selector = new Func<CheckRecord, bool>(r => r.IDNumber.StartsWith(searchText));
            }
            else if ((fieldDropdown.SelectedItem as string) == "Print Date")
            {
                selector = new Func<CheckRecord, bool>(r => r.PrintDate.Contains(searchText));
            }
            else if ((fieldDropdown.SelectedItem as string) == "Check Serial Number")
            {
                selector = new Func<CheckRecord, bool>(r => r.SN.Contains(searchText));
            }
            else if ((fieldDropdown.SelectedItem as string) == "Check Date")
            {
                selector = new Func<CheckRecord, bool>(r => r.CheckDate.Contains(searchText));
            }
            else if ((fieldDropdown.SelectedItem as string) == "Amount")
            {
                selector = new Func<CheckRecord, bool>(r => r.Amount.StartsWith(searchText));
            }
            return _records.Where(selector).ToList();
        }

        private void fieldDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchTextBox_TextChanged(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var fileDialog = new SaveFileDialog();
                fileDialog.FileName = "Printed Records";
                fileDialog.Filter = "Excel Files|*.xlsx";
                fileDialog.DefaultExt = "xlsx";
                var result = fileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ReportGenerator.ExportHistory(fileDialog.FileName, GetFilteredRecords(_records));
                    System.Diagnostics.Process.Start(fileDialog.FileName);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(this,
                    $"{ex.Message}",
                    "Error Exporting To Excel File",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

            }
        }
    }
}
