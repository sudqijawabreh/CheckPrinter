using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using checks.Models;

namespace checks
{
    public partial class MainForm : Form
    {
        private float _DpiX = 96;
        private float _DpiY = 96;
        private int count = 0;
        private readonly int _pageWidth;
        private readonly int _pageHeight;
        private bool _isInDrag = false;
        private MeasureState _measureState = MeasureState.None;
        List<stringDraw> _toDrawStrings = new List<stringDraw>();
        stringDraw _currentDrawing = new stringDraw { Text = "", Position = new Point(0, 0) };
        stringDraw _overDrawing = new stringDraw { Text = "", Position = new Point(0, 0) };
        private Point _previousCursorPosition = new Point(0, 0);
        private readonly int _amountInWordsWidth = 275;
        private Image _image;
        private List<CheckRecord> _records = new List<CheckRecord> { new CheckRecord { Amount = "12332.12", CheckDate = "09/09/2019", Name = "Ahmad" , Number = 1} };
        //private List<CheckRecord> _records = new List<CheckRecord> { new CheckRecord { Amount = "532.12", Date = "09/09/2019", Name = "Yusra" } };
        private int _currentRecord = 1;
        private int _currentPreview = 1;
        private int _firstRecord = 1;
        private int _lastRecord = 1;
        private BindingSource _bindingSource;
        private PrintAction _printAction;
        private readonly CheckRecord _checkRecord = new CheckRecord();
        private readonly string _fileName = "Positions.txt";
        private readonly string _backupFielName = "backup.csv";
        private readonly List<stringDraw> _defaultValues;
        private string _startingSN = string.Empty;
        private List<CheckRecord> _printedRecords = new List<CheckRecord>();


        private Point _firstMeasure;
        private Point _secondMeasure;
        private int toIncheHundredth(double value)
        {
            return (int)(value * 0.393701 * 100);
        }
        public MainForm()
        {
            InitializeComponent();


            _pageHeight = toIncheHundredth(21);
            _pageWidth = toIncheHundredth(7.2);
            _defaultValues = new List<stringDraw> {
            (new stringDraw {
                Label = "Name",
                //Position = new Point(104, 109),
                Position = new Point(282, 105),
                //Text = "Yusra A\\kAreem Saleh Abu Roos",
                Text = "Ahmad",
                MaxWidth = _amountInWordsWidth,
                field = $"{nameof(_checkRecord.Name)}",
                fontSize = 10,
            }),

            (new stringDraw {
                Label = "small date",
                Position = new Point(66, 40),
                Text = "09/09/2020",
                MaxWidth = 115,
                field = $"{nameof(_checkRecord.CheckDate)}",
                fontSize = 10,
            }),

            (new stringDraw {
                Label = "small amount",
                Position = new Point(68, 120),
                Text = "1,339.240",
                field = $"{nameof(_checkRecord.Amount)}",
                fontSize = 9,
            }),
            (new stringDraw {
                Label = "small name",
                Position = new Point(48, 75),
                Text = "Ahmad Mohammad Ali",
                MaxWidth = 105,
                field = $"{nameof(_checkRecord.Name)}",
                fontSize = 7,
            }),
            (new stringDraw
            {
                Label = "Amount in Words",
                Position = new Point(281, 135),
                Text = "JD One Thousand Three Hundred Thirty Nine And  Two Hundred Forty ils Only",
                MaxWidth = _amountInWordsWidth,
                field = $"{nameof(_checkRecord.AmountInWords)}",
                fontSize = 10,
            }),
            (new stringDraw { Label = "Amount", Position = new Point(675, 130), Text = "1,339.240", field = $"{nameof(_checkRecord.Amount)}", fontSize = 10 }),
            (new stringDraw { Label = "Date", Position = new Point(503, 181), Text = "09/09/2020", field = $"{nameof(_checkRecord.CheckDate)}", fontSize = 10 }),
            (new stringDraw { Label = "Not Negotiable", Position = new Point(270, 71), Text = "NOT NEGOTIABLE", field = "not", fontSize = 15 ,Angle = -20}),
            };
            _toDrawStrings = _defaultValues;
            //_image =Bitmap.FromFile("empty check.png");
            _image = Bitmap.FromFile("full_check.png");
            //_image = RotateImage(_image, -0.5f);

            /*            _pageHeight = toInche(7.2);
            _pageWidth = toInche(16);*/
            UpdateGridView(_records);
            recordsGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            recordsGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            recordsGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            recordsGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            recordsGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            recordsGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            recordsGrid.Columns[5].HeaderText = "Amount In Words";
            recordsGrid.Columns[4].HeaderText = "Check Date";
            recordsGrid.RowHeadersVisible = false;

            ReadPositions();

        }
        private Bitmap RotateImage(Image bmp, float angle)
        {
            Bitmap rotatedImage = new Bitmap(bmp.Width, bmp.Height);
            rotatedImage.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                // Set the rotation point to the center in the matrix
                //g.TranslateTransform(bmp.Width / 2, bmp.Height / 2);
                // Rotate
                g.RotateTransform(angle);
                // Restore rotation point in the matrix
                //g.TranslateTransform(-bmp.Width / 2, -bmp.Height / 2);
                // Draw the image on the bitmap
                g.DrawImage(bmp, new Point(0, 0));
            }

            return rotatedImage;
        }
        private float cmToInche(float value)
        {
            return (value * 0.393700787f);
        }
        private float cmToPixelX(float value)
        {
            return cmToInche(value) * _DpiX;
        }
        private float cmToPixelY(float value)
        {
            return cmToInche(value) * _DpiY;
        }

        /*        private float cmToPixel(float value)
                {
                    return (value * 0.393700787f) * 100.44117647058823529411764705882f;
                }*/
        private float pixelToHundredthIncheX(float value)
        {
            return (value / _DpiY) * 100;
        }
        private float pixelToHundredthIncheY(float value)
        {
            return (value / _DpiY) * 100;
        }

        private void Draw(Graphics formGraphics, float inputWidth, float inputHeight)
        {
            var backImg = File.OpenRead("full_check.png");
            //var backImg = File.OpenRead("empty check.png");
            var bitmap = Bitmap.FromStream(backImg);
            formGraphics.DrawImage(bitmap, 0, 0, (int)(inputWidth), (int)(inputHeight));

        }
        private List<CheckRecord> readFile(Stream file)
        {
            //System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var sheets = new List<DataTable>();
            //using (var stream = File.Open("file.xlsx", FileMode.Open, FileAccess.Read))
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
                        UseHeaderRow = false,

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
                sheets = result.Tables.OfType<DataTable>().ToList();
                var value = ChooseSheet.ShowPrompt(tables.Select(t => t.TableName).ToList());
                if (value.ChoiceType == PromptChoice.OK)
                {
                    var currentSheet = sheets.Where(s => s.TableName == value.Item).First();
                    var (headerColumns,rowsToSkip) = FindHeaderColumns(currentSheet);
                    var sheetColumnNames = currentSheet.Columns.Cast<DataColumn>().Select(c => c.ColumnName);
                    var missingColumns = ColumnNames.RequiredColumns.Where(n => !headerColumns.ContainsKey(n));
                    var optionColumnMissing = ColumnNames.OptionalColumns.Where(n => !headerColumns.ContainsKey(n));

                    if (missingColumns.Any())
                    {
                        MessageBox.Show(this,
                            $"One or more columns are missing : {string.Join(", ", missingColumns)}",
                            "Missing Columns",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return new List<CheckRecord>();
                    }
                    if (optionColumnMissing.Any())
                    {
                        MessageBox.Show(this,
                            $"This may affect the values in the backup.{Environment.NewLine}Some Optional columns are missing : {string.Join(", ", optionColumnMissing)}",
                            "Missing Columns",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }

                    var dateWarning = false;
                    var amountWarning = false;
                    var importedRecords = currentSheet.Rows.Cast<DataRow>().Skip(rowsToSkip).Select(r => new
                    {
                        Name = r.Field<object>(headerColumns[ColumnNames.Name]),
                        Amount = r.Field<object>(headerColumns[ColumnNames.Amount]),
                        ID = !optionColumnMissing.Contains(ColumnNames.ID) ? r.Field<object>(headerColumns[ColumnNames.ID]) : string.Empty,
                        Currency = !optionColumnMissing.Contains(ColumnNames.Currency) ? r.Field<object>(headerColumns[ColumnNames.Currency]) : string.Empty,
                        Area = !optionColumnMissing.Contains(ColumnNames.Area) ? r.Field<object>(headerColumns[ColumnNames.Area]) : string.Empty,
                    }).Where(r => r.Name != null && r.Amount != null && !r.Name.ToString().Trim().ToLower().Contains("total"))
                        .Select((r, i) =>
                        {
                            ///var isSuccess = DateTime.TryParse(r.Date.ToString(), out var dateResult);
                            var isNumber = double.TryParse(r.Amount.ToString(), out var number);
                            //dateWarning |= !isSuccess;
                            amountWarning |= !isNumber;

                            if(!long.TryParse(_startingSN, out var SN))
                            {
                                SN = 1;
                            }

                            return new CheckRecord
                            {
                                Number = i + 1,
                                Name = r.Name?.ToString() ?? string.Empty,
                                Amount = r.Amount?.ToString() ?? string.Empty,
                                CheckDate = dateTimePicker.Value.ToString("dd/MM/yyyy"),
                                Area = r.Area?.ToString() ?? string.Empty,
                                Currency = r.Currency?.ToString() ?? string.Empty,
                                IDNumber = r.ID?.ToString() ?? string.Empty,
                                AmountInWords = NumberToWordUtil.AmountInJDToWords(r.Amount?.ToString()),
                                SN = (SN + i).ToString(),
                            };
                        }
                        ).ToList();

                    var message = string.Empty;
                    if (dateWarning)
                        message += $"Some records have invalide Date format.{Environment.NewLine}";
                    if (amountWarning)
                        message += $"Some records have invalide Amount values.{Environment.NewLine}";
                    if (dateWarning || amountWarning)
                    {
                        MessageBox.Show(this,
                            message,
                            "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }

                    MessageBox.Show(this,
                        $"Successfuly imported {importedRecords.Count} records.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return importedRecords;
                }
            }
            return new List<CheckRecord>();
        }

        private (Dictionary<string,int>,int) FindHeaderColumns(DataTable currentSheet)
        {
            for (int i = 0; i < currentSheet.Rows.Count; i++)
            {
                var row = currentSheet.Rows[i];
                var isConatinNameCloumn = (row.ItemArray.Any(e => e.ToString().Trim().ToLower().Contains(ColumnNames.Name)));
                var isConatinAmountCloumn = (row.ItemArray.Any(e => e.ToString().Trim().ToLower().Contains(ColumnNames.Amount)));
                if (isConatinAmountCloumn || isConatinNameCloumn)
                {
                    var columnIndexList = row.ItemArray.Select((c, index) =>
                    {
                        var columnName = ColumnNames.All.FirstOrDefault(cn => c.ToString().Trim().ToLower().Contains(cn));
                        return new { columnName, index };
                    });
                    return (columnIndexList.Where(ci => ci.columnName != null).ToDictionary(ci => ci.columnName, ci => ci.index), i + 1);
                }


            }
            return (new Dictionary<string, int>(),0);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var printPreview = new PrintPreviewDialog();
            var printDialog = new PrintDialog();


            var printDocument = new PrintDocument();
            printDocument.PrintPage += printDocument_PrintPage;
            printDocument.BeginPrint += BeginPrint;
            printDocument.EndPrint += EndPrint;
            //printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            printDialog.Document = printDocument;
            printDialog.AllowSelection = true;
            printDialog.AllowSomePages = true;
            printDialog.AllowCurrentPage = true;
            printDialog.PrinterSettings.FromPage = 1;
            printDialog.PrinterSettings.ToPage = _records.Count;
            DialogResult = printDialog.ShowDialog();
            if (DialogResult == DialogResult.Cancel)
            {
                return;
            }
            var ps = printDocument.PrinterSettings;
            var paperSizes = ps.PaperSizes.Cast<PaperSize>().ToList();
            PaperSize sizeA4 = paperSizes.FirstOrDefault<PaperSize>(size => size.PaperName == "check"); // setting paper size to A4 size
            var newSize = new PaperSize("check", _pageWidth, _pageHeight);
            if(sizeA4 == null)
            {
                printDialog.PrinterSettings.DefaultPageSettings.PaperSize = newSize;
            }
            else
            {
                printDocument.DefaultPageSettings.PaperSize = sizeA4;

            }
            //PaperSize sizeA4 = paperSizes.First<PaperSize>(size => size.PaperName == "A4"); // setting paper size to A4 size

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
            count = 0;

            /*            if (DialogResult == DialogResult.OK)
                        {
                            //printDocument.Print();
                        }*/
        }

        private void EndPrint(object sender, PrintEventArgs e)
        {
            if (e.PrintAction == PrintAction.PrintToPrinter)
            {
                var backup = new Backup(_backupFielName);
                backup.Write(_printedRecords);
            }
        }

        private void BeginPrint(object sender, PrintEventArgs e)
        {
            _printAction = e.PrintAction;
            _printedRecords = new List<CheckRecord>();
        }
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {

            if (_currentRecord >= _firstRecord && _currentRecord <= _lastRecord)
            {
                var record = _records.ToList()[_currentRecord - 1];
                e.Graphics.RotateTransform(-90);
                e.Graphics.TranslateTransform(-(_pageHeight), 0);
                e.Graphics.TranslateTransform(0 + e.PageSettings.HardMarginY + 4, 0 - e.PageSettings.HardMarginX + 4);

                if (_printAction == PrintAction.PrintToPreview)
                {
                    e.Graphics.DrawImage(_image, 0, 0, _pageHeight, toIncheHundredth(7.2));
                }
                else if (_printAction == PrintAction.PrintToPrinter)
                {
                    record.PrintDate = DateTime.Now.ToString("dd/MM/yyyy");
                    _printedRecords.Add(record);
                }

                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                StringFormat stringFormat = new StringFormat(StringFormatFlags.LineLimit);
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                foreach (var item in _toDrawStrings)
                {
                    if (!notNegoCheckBox.Checked && item.Label.ToLower() == "not negotiable")
                        continue;

                    var font = new Font("Times New Roman", item.fontSize);
                    var text = record.GetType().GetProperty(item.field)?.GetValue(record)?.ToString() ?? item.Text;
                    if (item.field == nameof(_checkRecord.Amount))
                    {
                        text = $"**{text}**";
                        if (text.Length > 8)
                            font = new Font("Times New Roman", 8);
                    }
                    var sizeText = e.Graphics.MeasureString(text, font, (int)pixelToHundredthIncheX(item.MaxWidth));
                    var bound = new RectangleF(pixelToHundredthIncheX(item.Position.X), pixelToHundredthIncheY(item.Position.Y), sizeText.Width, sizeText.Height);
                    var bound1 = new Rectangle((int)pixelToHundredthIncheX(item.Position.X), (int)pixelToHundredthIncheY(item.Position.Y), (int)sizeText.Width, (int)sizeText.Height);
                    //e.Graphics.DrawRectangle(Pens.Black, bound1);
                    if (item.Angle == 0)
                    {
                        e.Graphics.DrawString(text, font, new SolidBrush(Color.Black), bound);
                    }
                    else
                    {
                        e.Graphics.TranslateTransform(bound.X, bound.Y);
                        e.Graphics.RotateTransform(item.Angle);
                        var rbound = new RectangleF(new PointF(0, 0), sizeText);
                        e.Graphics.DrawString(text, font, new SolidBrush(Color.Black), rbound);
                    }

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
            pictureBox.Invalidate();
        }

        private void textBoxHeight_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(textBoxWidth.Text, out float width);
            float.TryParse(textBoxHeight.Text, out float height);
            pictureBox.Invalidate();
            Update();
        }

        private void DrawText(Graphics formGraphics, stringDraw el, CheckRecord record)
        {

            if (!notNegoCheckBox.Checked && el.Label.ToLower() == "not negotiable")
                return;

            var lfont = new Font("Times New Roman", 8);
            var font = new Font("Times New Roman", el.fontSize);
            var fieldExist = record.GetType().GetProperties().Select(p => p.Name == el.field).FirstOrDefault();
            var text = string.Empty;
            text = record.GetType()?.GetProperty(el.field)?.GetValue(record)?.ToString() ?? el.Text;
            if (el.field == nameof(_checkRecord.Amount))
            {
                text = $"**{text}**";
                if (text.Length > 8)
                    font = new Font("Times New Roman", 8);
            }


            var sizeText = formGraphics.MeasureString(text, font, (el.MaxWidth));
            el.Bound = new Rectangle(el.Position, sizeText.ToSize());
            var sizeLabel = formGraphics.MeasureString(el.Label, lfont);
            var pointlabel = new Point(el.Position.X + (int)(sizeText.Width / 2) - (int)(sizeLabel.Width / 2), el.Position.Y - (int)(sizeLabel.Height));
            if ((_isInDrag && _currentDrawing == el) || (!_isInDrag && _overDrawing == el))
            {
                var newPointLable = new Point();
                newPointLable.X = pointlabel.X - el.Position.X;
                newPointLable.Y = pointlabel.Y - el.Position.Y;
                formGraphics.TranslateTransform(el.Position.X, el.Position.Y);
                formGraphics.RotateTransform(el.Angle);
                formGraphics.FillRectangle(Brushes.Bisque, new Rectangle(newPointLable, sizeLabel.ToSize()));
                formGraphics.DrawString(el.Label, lfont, new SolidBrush(Color.Black), newPointLable);
                formGraphics.ResetTransform();
            }
            //formGraphics.DrawRectangle(Pens.Black, el.Bound);
            var bound = new RectangleF(el.Position, sizeText);
            formGraphics.TranslateTransform(bound.X, bound.Y);
            formGraphics.RotateTransform(el.Angle);
            var rbound = new RectangleF(new PointF(0, 0), sizeText);
            formGraphics.DrawString(text, font, new SolidBrush(Color.Black), rbound);
            formGraphics.ResetTransform();

            //formGraphics.DrawString($"x : {el.Position.X} , y: {el.Position.Y}", new Font("Times New Roman", 10), new SolidBrush(Color.Black), el.Position.X + 100, el.Position.Y + 100);
        }
        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {

            _DpiX = e.Graphics.DpiX;
            _DpiY = e.Graphics.DpiY;
            float.TryParse(textBoxWidth.Text, out float width);
            float.TryParse(textBoxHeight.Text, out float height);
            //e.Graphics.TranslateTransform(250, 0);
            Draw(e.Graphics, cmToPixelX(width), cmToPixelY(height));
            foreach (var item in _toDrawStrings)
            {
                DrawText(e.Graphics, item, _records[_currentPreview - 1]);
            }
            DrawMeasureXLineDistance(e.Graphics);
        }
        private void DrawMeasureXLineDistance(Graphics graphics)
        {
            if (_measureState == MeasureState.End || _measureState == MeasureState.SecondPoint)
            {

                _secondMeasure = new Point(_secondMeasure.X, _firstMeasure.Y);
                var stringPoint = new Point(_firstMeasure.X + (_secondMeasure.X - _firstMeasure.X) / 2, _firstMeasure.Y + (_secondMeasure.Y - _firstMeasure.Y) / 2);
                graphics.DrawString($"{Math.Abs(_firstMeasure.X - _secondMeasure.X)}", new Font("Arial", 10), Brushes.Black, stringPoint);
                graphics.DrawLine(Pens.Black, _firstMeasure, _secondMeasure);
            }
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (_measureState == MeasureState.FirstPoint)
            {
                _firstMeasure = new Point(e.X, e.Y);
                _measureState = MeasureState.SecondPoint;
            }
            else if (_measureState == MeasureState.SecondPoint)
            {
                _secondMeasure = new Point(e.X, e.Y);
                _measureState = MeasureState.End;
            }
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
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
            return _toDrawStrings.Where(s =>
            {
                var region = new Region(s.Bound);
                var matrix = new Matrix();
                matrix.RotateAt(s.Angle, new Point(s.Bound.X, s.Bound.Y));
                region.Transform(matrix);
                return region.IsVisible(point);
                // return s.Bound.Contains(point);

            }).FirstOrDefault();
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isInDrag)
            {
                var deltPoint = new Point(e.X - _previousCursorPosition.X, e.Y - _previousCursorPosition.Y);
                _currentDrawing.Position = new Point((_currentDrawing.Position.X + deltPoint.X), (_currentDrawing.Position.Y + deltPoint.Y));
                _previousCursorPosition = new Point(e.X, e.Y);
                pictureBox.Invalidate();
            }
            else
            {
                if (_measureState == MeasureState.SecondPoint)
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
                pictureBox.Invalidate();
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _isInDrag = false;
            pictureBox.Invalidate();
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
            var result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    var importedRecords = new List<CheckRecord>();
                    using (var file = fileDialog.OpenFile())
                    {
                        importedRecords = readFile(file);
                    }

                    if (importedRecords.Count > 0)
                    {
                        var dateArgs = DatePrompt.ShowPrompt();
                        if (dateArgs.ChoiceType == PromptChoice.OK)
                        {
                            importedRecords.ForEach(r => r.CheckDate = DateTime.Parse(dateArgs.Item).ToString("dd/MM/yyyy"));
                            UpdateGridView(importedRecords);
                        }
                    }
                }
                catch (IOException eio)
                {

                    MessageBox.Show(this,
                        $"Make sure the file is not opened by Excel.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (Exception e)
                {
                    MessageBox.Show(this,
                        $"Erorr in importing file.{Environment.NewLine}{e.Message}",
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
                pictureBox.Invalidate();
            }
        }

        private void previousRecordButton_Click(object sender, EventArgs e)
        {

            if (_currentPreview > 1)
            {
                int.TryParse(this.recordNumberTextBox.Text, out var number);
                this.recordNumberTextBox.Text = (number - 1).ToString();
                _currentPreview = number - 1;
                pictureBox.Invalidate();
            }
        }

        private void recordNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(this.recordNumberTextBox.Text, out var number);
            if (number >= 1 && number <= _records.Count)
            {
                _currentPreview = number;
                pictureBox.Invalidate();
            }
        }

        private void ReadPositions()
        {
            try
            {
/*                if (File.Exists(_fileName))
                {
                    var json = File.ReadAllText(_fileName);
                    var list = JsonConvert.DeserializeObject<List<stringDraw>>(json);
                    _toDrawStrings = list;
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                    $"Couldn't Read Old Saved Positions.{Environment.NewLine}{ex.Message}",
                    "Eror",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            var json = JsonConvert.SerializeObject(_toDrawStrings);
            File.WriteAllText(_fileName, json);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            _toDrawStrings = _defaultValues;
            SaveButton_Click(sender, e);
        }

        private void SNButton_Click(object sender, EventArgs e)
        {
            var choice = InputSN.ShowPrompt();
            if (choice.ChoiceType == PromptChoice.OK)
            {
                var updated = _records.Select(r => UpdateSNNumber(r)).ToList();
                UpdateGridView(updated);
            }
        }

        private void UpdateGridView(List<CheckRecord> records)
        {
            _records = records;
            var bindingList = new BindingList<GridViewRecord>(records.Select(r => r.ToGridViewRecord()).ToList());
            _bindingSource = new BindingSource(bindingList, null);
            recordsGrid.DataSource = _bindingSource;
            pictureBox.Invalidate();
        }

        private CheckRecord UpdateSNNumber(CheckRecord record)
        {
            if (!long.TryParse(_startingSN, out var SN))
            {
                SN = 1;
            }

            return new CheckRecord
            {
                Number = record.Number,
                Name = record.Name,
                Amount = record.Amount,
                CheckDate = record.CheckDate,
                AmountInWords = record.AmountInWords,
                SN = (SN + record.Number - 1).ToString(),
            };

        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            _records.ForEach(r => r.CheckDate = dateTimePicker.Value.ToString("dd/MM/yyyy"));
            UpdateGridView(_records);
        }

        private void notNegoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
        }
    }
    static class ColumnNames
    {
        public static string Name => "Name".ToLower();
        public static string Amount => "Amount".ToLower();
        public static string Currency => "Currency".ToLower();
        public static string ID => "ID Number".ToLower();
        public static string Area => "Area".ToLower();

        public static IReadOnlyCollection<string> RequiredColumns = new List<string> { Name, Amount }.AsReadOnly();
        public static IReadOnlyCollection<string> OptionalColumns = new List<string> { ID, Currency, Area }.AsReadOnly();
        public static IReadOnlyCollection<string> All = new List<string>(RequiredColumns).Concat(OptionalColumns).ToList().AsReadOnly();
    }
}
