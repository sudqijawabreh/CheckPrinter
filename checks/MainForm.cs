using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace checks
{
    public partial class MainForm : Form
    {
        private int _DpiX = 96;
        private int _DpiY = 96;
        private  int count = 0;
        private readonly int _pageWidth;
        private readonly int _pageHeight;
        private bool _isInDrag = false;
        private MeasureState _measureState = MeasureState.None;
        List<stringDraw> _toDrawStrings = new List<stringDraw>();
        stringDraw _currentDrawing = new stringDraw { Text = "", Position = new Point(0, 0) };
        stringDraw _overDrawing = new stringDraw { Text = "", Position = new Point(0, 0) };
        private Point _previousCursorPosition = new Point(0, 0);
        private readonly int _amountInWordsWidth = 290;
        private Image _image;
        private List<CheckRecord> _records = new List<CheckRecord> { new CheckRecord { Amount = "532.12", Date = "09/09/2019", Name = "Yusra" } };
        //private List<CheckRecord> _records = new List<CheckRecord> { new CheckRecord { Amount = "532.12", Date = "09/09/2019", Name = "Yusra" } };
        private int _currentRecord = 1;
        private int _currentPreview = 1;
        private int _firstRecord = 1;
        private int _lastRecord = 1;
        private BindingSource _bindingSource;


        private Point _firstMeasure;
        private Point _secondMeasure;
        private int toInche(double value)
        {
            return (int)(value * 0.393701 * 100);
        }
        public MainForm()
        {
            InitializeComponent();

            _pageHeight = toInche(21);
            _pageWidth = toInche(7.2);
            _toDrawStrings.Add(new stringDraw {
                Label = "Name",
                //Position = new Point(104, 109),
                Position = new Point(286, 110),
                //Text = "Yusra A\\kAreem Saleh Abu Roos",
                Text = "Yusra",
                MaxWidth = _amountInWordsWidth,
                field = "Name",
                fontSize = 10,
            });

            _toDrawStrings.Add(new stringDraw {
                Label = "small date",
                Position = new Point(46, 41),
                Text = "09/09/2020",
                MaxWidth = 129,
                field = "Date",
                fontSize = 10,
            });

            _toDrawStrings.Add(new stringDraw {
                Label = "small amount",
                Position = new Point(65, 124),
                Text = "1,339.240",
                MaxWidth = 129,
                field = "Amount",
                fontSize = 10,
            });
            _toDrawStrings.Add(new stringDraw {
                Label = "small name",
                Position = new Point(39, 78),
                Text = "Yusra A\\kAreem Saleh Abu Roos",
                MaxWidth = 129,
                field = "Name",
                fontSize = 7,
            });
            _toDrawStrings.Add(new stringDraw
            {
                Label = "Amount in Words",
                Position = new Point(286, 142),
                Text = "JD One Thousand Three Hundred Thirty Nine And  Two Hundred Forty ils Only",
                MaxWidth = _amountInWordsWidth,
                field = "Name",
                fontSize = 10,
            }); 
            _toDrawStrings.Add(new stringDraw { Label = "Amount", Position = new Point(725, 139), Text = "1,339.240" , field = "Amount", fontSize = 10});
            _toDrawStrings.Add(new stringDraw { Label = "Date", Position = new Point(573, 190), Text = "09/09/2020" , field = "Date", fontSize = 10});
            //_image =Bitmap.FromFile("empty check.png");
            _image =Bitmap.FromFile("full check.png");
            //_image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            /*            _pageHeight = toInche(7.2);
            _pageWidth = toInche(16);*/
            var bindingList = new BindingList<CheckRecord>();
            _bindingSource= new BindingSource(bindingList, null);
            recordsGrid.DataSource = _bindingSource;
            recordsGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            recordsGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            recordsGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            recordsGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            recordsGrid.RowHeadersVisible = false;
        }
        private float cmToPixel(float value)
        {
            return (value * 0.393700787f) * 100.44117647058823529411764705882f;
        }
        private float pixelToInche(float value)
        {
            return value * 96 / 100.44117647058823529411764705882f;
        }

        private void Draw(Graphics formGraphics, float inputWidth, float inputHeight)
        {
            var backImg = File.OpenRead("full check.png");
            //var backImg = File.OpenRead("empty check.png");
            var bitmap = Bitmap.FromStream(backImg);
            formGraphics.DrawImage(bitmap, 0, 0, (int)cmToPixel(inputWidth), (int)cmToPixel(inputHeight));

        }
        private void readFile(Stream file)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var sheets = new List<DataTable>();
            //using (var stream = File.Open("file.xlsx", FileMode.Open, FileAccess.Read))
            //{
            // Auto-detect format, supports:
            //  - Binary Excel files (2.0-2003 format; *.xls)
            //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
            using (var reader = ExcelReaderFactory.CreateReader(file))
            {
                // Choose one of either 1 or 2:

                // 1. Use the reader methods
                /*                    do
                                    {
                                        while (reader.Read())
                                        {
                                            for (int i = 0; i < reader.FieldCount; i++)
                                            {
                                                var value = reader.GetValue(i);
                                            }

                                            //var value = reader.GetString(0);
                                        }
                                    } while (reader.NextResult());*/

                // 2. Use the AsDataSet extension method
                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    // Gets or sets a value indicating whether to set the DataColumn.DataType 
                    // property in a second pass.
                    UseColumnDataType = false,

                    // Gets or sets a callback to determine whether to include the current sheet
                    // in the DataSet. Called once per sheet before ConfigureDataTable.
                    FilterSheet = (tableReader, sheetIndex) =>
                    {
                        return true;
                    },

                    // Gets or sets a callback to obtain configuration options for a DataTable. 
                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                    {
                        // Gets or sets a value indicating the prefix of generated column names.
                        EmptyColumnNamePrefix = "Column",

                        // Gets or sets a value indicating whether to use a row from the 
                        // data as column names.
                        UseHeaderRow = true,

                        // Gets or sets a callback to determine which row is the header row. 
                        // Only called when UseHeaderRow = true.
                        ReadHeaderRow = (rowReader) =>
                        {
                            // F.ex skip the first row and use the 2nd row as column headers:
                            ///rowReader.Read();
                            return;
                        },

                        // Gets or sets a callback to determine whether to include the 
                        // current row in the DataTable.
                        FilterRow = (rowReader) =>
                        {
                            return true;
                        },

                        // Gets or sets a callback to determine whether to include the specific
                        // column in the DataTable. Called once per column after reading the 
                        // headers.
                        FilterColumn = (rowReader, columnIndex) =>
                        {
                            return true;
                        }
                    }
                });
                //result.Tables.Cast<DataTable>().Select(t => new { })
                var tables = result.Tables.Cast<DataTable>().ToList();
                //var chooseSheetFrom = new ChooseSheet(tables.Select(t => t.TableName).ToList());
                //chooseSheetFrom.OnChoice += onChoiceOfSheet;
                //chooseSheetFrom.Show();
                //var value = Prompt.ShowDialog("hello", "there");
                sheets = result.Tables.OfType<DataTable>().ToList();
                var value = ChooseSheet.ShowPrompt(tables.Select(t => t.TableName).ToList());
                if (value.ChoiceType == SheetChoiceType.OK)
                {
                    var currentSheet = sheets.Where(s => s.TableName == value.ChoosenItem).First();
                    var sheetColumnNames = currentSheet.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower());
                    var missingColumns = ColumnNames.List.Where(n => !sheetColumnNames.Contains(n.ToLower())).ToList();

                    if (missingColumns.Any())
                    {
                        MessageBox.Show(this,
                            $"One or more columns are missing : {string.Join(", ", missingColumns)}",
                            "Missing Column",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    _records = currentSheet.Rows.Cast<DataRow>().Select(r => new
                    {
                        Name = r.Field<object>(ColumnNames.Name),
                        Amount = r.Field<object>(ColumnNames.Amount),
                        Date = r.Field<object>(ColumnNames.Date),
                    }).Where(r => r.Name != null && r.Date != null)
                        .Select((r,i) =>
                        {
                            var isSuccess = DateTime.TryParse(r.Date.ToString(), out var dateResult);

                            return new CheckRecord
                            {
                                Number = i + 1,
                                Name = r.Name.ToString(),
                                Amount = r.Amount.ToString(),
                                Date = isSuccess ? dateResult.ToString("dd/MM/yyyy") : r.Date.ToString(),
                            };
                        }
                        ).ToList();

                    MessageBox.Show(this,
                        $"Successfuly imported {_records.Count} records.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    var bindingList = new BindingList<CheckRecord>(_records);
                    _bindingSource = new BindingSource(bindingList, null);
                    recordsGrid.DataSource = _bindingSource;

                }
                // The result of each spreadsheet is in result.Tables
            }
            //}

        }
        private void button1_Click(object sender, EventArgs e)
        {

            var printPreview = new PrintPreviewDialog();
            var printDialog = new PrintDialog();


            var printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            printDialog.Document = printDocument;
            printDialog.AllowSelection = true;
            printDialog.AllowSomePages = true;
            printDialog.AllowCurrentPage = true;
            printDialog.PrinterSettings.FromPage = 1;
            printDialog.PrinterSettings.ToPage = _records.Count;
            DialogResult = printDialog.ShowDialog();
            PrinterSettings ps = new PrinterSettings();
            var paperSizes = ps.PaperSizes.Cast<PaperSize>().ToList();
            PaperSize sizeA4 = paperSizes.First<PaperSize>(size => size.PaperName == "check"); // setting paper size to A4 size
            //PaperSize sizeA4 = paperSizes.First<PaperSize>(size => size.PaperName == "A4"); // setting paper size to A4 size
            printDocument.DefaultPageSettings.PaperSize = sizeA4;

            if (printDialog.PrinterSettings.PrintRange == PrintRange.AllPages)
            {
                _firstRecord = 1;
                _lastRecord = _records.Count;
            }
            else if (printDialog.PrinterSettings.PrintRange == PrintRange.SomePages)
            {
                _firstRecord = printDialog.PrinterSettings.FromPage;
                _lastRecord = printDialog.PrinterSettings.ToPage;
            }
            else if (printDialog.PrinterSettings.PrintRange == PrintRange.Selection)
            {
                _firstRecord = _currentPreview;
                _lastRecord = _currentPreview;
            }
            _currentRecord = _firstRecord;

            printPreview.PrintPreviewControl.AutoZoom = true;
            printPreview.Document = printDocument;
            var viewResult = printPreview.ShowDialog();
            if (viewResult == DialogResult.Cancel)
            {
                //  printDocument.Print();
            }
            count = 0;

/*            if (DialogResult == DialogResult.OK)
            {
                //printDocument.Print();
            }*/
        }


        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {

            if (_currentRecord >= _firstRecord && _currentRecord <= _lastRecord)
            {
                var record = _records[_currentRecord - 1];
                //e.Graphics.DrawImage(_image, 0, 0, _pageHeight, toInche(7.2));
                //e.Graphics.DrawImage(_image, 0, 0, toInche(7.2), _pageHeight);
                e.Graphics.RotateTransform(-90);
                e.Graphics.TranslateTransform(-(_pageHeight), 0);
                e.Graphics.TranslateTransform(0 + e.PageSettings.HardMarginY, 0 - e.PageSettings.HardMarginX);
                //e.Graphics.TranslateTransform(-(_pageHeight) - e.PageSettings.PrintableArea.X, 0);
                //e.Graphics.DrawImage(_image,0, 0, _pageHeight, toInche(7.2));
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                StringFormat stringFormat = new StringFormat(StringFormatFlags.LineLimit);
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                foreach (var item in _toDrawStrings)
                {
                    var font = new Font("Times New Roman", item.fontSize);
                    var text = record.GetType().GetProperty(item.field).GetValue(record).ToString();
                    var sizeText = e.Graphics.MeasureString(text, font, (item.MaxWidth));
                    var bound = new RectangleF((item.Position.X),(item.Position.Y), sizeText.Width, sizeText.Height);
                    //var bound1 = new Rectangle((int)pixelToInche(item.Position.X), (int)pixelToInche(item.Position.Y),(int) sizeText.Width ,(int) sizeText.Height);
                    //e.Graphics.DrawRectangle(Pens.Black, bound1);
                    e.Graphics.DrawString(text, font, new SolidBrush(Color.Black), bound);

                }
                _currentRecord++;
            }

            if (_currentRecord <= _lastRecord)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
                _currentRecord = _firstRecord;
            }
        }

        private void textBoxWidth_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(textBoxWidth.Text, out float width);
            float.TryParse(textBoxHeight.Text, out float height);
            Invalidate();
        }

        private void textBoxHeight_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(textBoxWidth.Text, out float width);
            float.TryParse(textBoxHeight.Text, out float height);
            Invalidate();
            Update();
        }

        private void DrawText(Graphics formGraphics, stringDraw el,CheckRecord record)
        {

            var lfont = new Font("Times New Roman", 8);
            var font = new Font("Times New Roman", el.fontSize);
            //var sizeText = formGraphics.MeasureString(el.Text, font, el.MaxWidth);
            var text = record.GetType().GetProperty(el.field).GetValue(record).ToString();
            var sizeText = formGraphics.MeasureString(text, font, (int)Math.Ceiling((double)pixelToInche(el.MaxWidth)));
            el.Bound = new Rectangle(el.Position, sizeText.ToSize());
            var sizeLabel = formGraphics.MeasureString(el.Label, lfont);
            var pointlabel = new Point(el.Position.X + (int)(sizeText.Width / 2) - (int)(sizeLabel.Width / 2), el.Position.Y - (int)(sizeLabel.Height));
            if ((_isInDrag && _currentDrawing == el) || (!_isInDrag && _overDrawing == el))
            {
                formGraphics.FillRectangle(Brushes.Bisque, new Rectangle(pointlabel, sizeLabel.ToSize()));
                formGraphics.DrawString(el.Label, lfont, new SolidBrush(Color.Black), pointlabel);
            }
            //formGraphics.DrawRectangle(Pens.Black, el.Bound);
            var bound = new RectangleF(el.Position, sizeText);
            formGraphics.DrawString(text, font, new SolidBrush(Color.Black), bound);
            formGraphics.DrawString($"x : {el.Position.X} , y: {el.Position.Y}", new Font("Times New Roman", 10), new SolidBrush(Color.Black), el.Position.X + 100, el.Position.Y + 100);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            float.TryParse(textBoxWidth.Text, out float width);
            float.TryParse(textBoxHeight.Text, out float height);
            Draw(e.Graphics, width, height);
            foreach (var item in _toDrawStrings)
            {
                DrawText(e.Graphics, item,_records[_currentPreview - 1]);
            }
            DrawMeasureXLineDistance(e.Graphics);

        }

        private void DrawMeasureXLineDistance(Graphics graphics)
        {
            if (_measureState == MeasureState.End || _measureState == MeasureState.SecondPoint)
            {

                _secondMeasure = new Point(_secondMeasure.X, _firstMeasure.Y);
                var stringPoint = new Point(_firstMeasure.X + (_secondMeasure.X - _firstMeasure.X)/2, _firstMeasure.Y + (_secondMeasure.Y - _firstMeasure.Y)/2);
                graphics.DrawString( $"{Math.Abs(_firstMeasure.X - _secondMeasure.X)}", new Font("Arial", 10), Brushes.Black, stringPoint);
                graphics.DrawLine(Pens.Black, _firstMeasure, _secondMeasure);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (_measureState == MeasureState.FirstPoint)
            {
                _firstMeasure = new Point(e.X, e.Y);
                _measureState = MeasureState.SecondPoint;
            }
            else if(_measureState == MeasureState.SecondPoint)
            {
                _secondMeasure = new Point(e.X, e.Y);
                _measureState = MeasureState.End;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            var underCursror = getStringUnderCursor(new Point(e.X, e.Y));
            if (underCursror != null)
            {
                _currentDrawing = underCursror;
                _isInDrag = true;
                _previousCursorPosition = new Point(e.X, e.Y);
            }
        }

        private stringDraw getStringUnderCursor(Point point)
        {
            return _toDrawStrings.Where(s => s.Bound.Contains(point)).FirstOrDefault();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isInDrag)
            {
                var deltPoint = new Point(e.X - _previousCursorPosition.X, e.Y - _previousCursorPosition.Y);
                _currentDrawing.Position = new Point((_currentDrawing.Position.X + deltPoint.X), (_currentDrawing.Position.Y + deltPoint.Y));
                _previousCursorPosition = new Point(e.X, e.Y);
                Invalidate();
            }
            else
            {
                if(_measureState == MeasureState.SecondPoint)
                {
                    _secondMeasure = new Point(e.X, e.Y);
                }
                var underCursror = getStringUnderCursor(new Point(e.X, e.Y));
                if (underCursror != null)
                {
                    _overDrawing = underCursror;
                }
                else
                {
                    _overDrawing = new stringDraw { Label = "", Text = "", Position = new Point(0, 0) };

                }
                Invalidate();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _isInDrag = false;
            Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_measureState == MeasureState.None)
            {
                _measureState = MeasureState.FirstPoint;
            }
            else
            {
                _measureState = MeasureState.None;
            }
        }

        private void Print(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs eve)
        {

            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Excel Files|*.xlsx";
            var result =fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    using (var file = fileDialog.OpenFile())
                    {
                        readFile(file);
                    }
                }
                catch(IOException eio)
                {

                    MessageBox.Show(this,
                        $"{eio.Message}. Make sure the file is not opened by Excel.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (Exception e)
                {
                    MessageBox.Show(this,
                        $"Erorr in importing file",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void nextRecordButton_Click(object sender, EventArgs e)
        {
            
            if (_currentPreview < _records.Count)
            {
                int.TryParse(this.recordNumberTextBox.Text, out var number);
                this.recordNumberTextBox.Text = (number + 1).ToString();
                _currentPreview = number + 1;
                Invalidate();
            }
        }

        private void previousRecordButton_Click(object sender, EventArgs e)
        {

            if (_currentPreview > 1)
            {
                int.TryParse(this.recordNumberTextBox.Text, out var number);
                this.recordNumberTextBox.Text = (number - 1).ToString();
                _currentPreview = number - 1;
                Invalidate();
            }
        }
    }
    class CheckRecord
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Date { get; set; }
    }
    static class ColumnNames
    {
        public static string Name => "Name";
        public static string Amount => "Amount";
        public static string Date => "Date";
        public static string SN => "SN";

        public static IReadOnlyCollection<string> List = new List<string> { Name, Amount, Date }.AsReadOnly();
    }
}
