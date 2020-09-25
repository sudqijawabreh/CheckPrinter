using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace checks
{
    public partial class Form1 : Form
    {
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


        private Point _firstMeasure;
        private Point _secondMeasure;
        private int toInche(double value)
        {
            return (int)(value * 0.393701 * 100);
        }
        public Form1()
        {
            _pageHeight = toInche(16);
            _pageWidth = toInche(7.2);
            _toDrawStrings.Add(new stringDraw { Label = "Name", Position = new Point(104, 109), Text = "Yusra A\\kAreem Saleh Abu Roos" , MaxWidth = _amountInWordsWidth});
            _toDrawStrings.Add(new stringDraw
            {
                Label = "Amount in Words",
                Position = new Point(105, 139),
                Text = "JD One Thousand Three Hundred Thirty Nine And  Two Hundred Forty ils Only",
                MaxWidth = _amountInWordsWidth,
            }); 
            _toDrawStrings.Add(new stringDraw { Label = "Amount", Position = new Point(508, 136), Text = "1,339.240" });
            _toDrawStrings.Add(new stringDraw { Label = "Date", Position = new Point(325, 189), Text = "09/09/2020" });
            _image =Bitmap.FromFile("empty check.png");
            _image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            /*            _pageHeight = toInche(7.2);
            _pageWidth = toInche(16);*/
            InitializeComponent();
        }
        private float cmToPixel(float value)
        {
            return (value * 0.393700787f) * 100.44117647058823529411764705882f;
        }
        private float pixelToInche(float value)
        {
            return value * 100 / 100.44117647058823529411764705882f;
        }

        private void Draw(Graphics formGraphics, float inputWidth, float inputHeight)
        {
            var backImg = File.OpenRead("empty check.png");
            var bitmap = Bitmap.FromStream(backImg);
            formGraphics.DrawImage(bitmap, 0, 0, (int)cmToPixel(inputWidth), (int)cmToPixel(inputHeight));

        }
        private void readFile()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var sheets = new List<DataTable>();
            using (var stream = File.Open("file.xlsx", FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Choose one of either 1 or 2:

                    // 1. Use the reader methods
                    do
                    {
                        while (reader.Read())
                        {
                             var value = reader.GetString(0);
                        }
                    } while (reader.NextResult());

                    // 2. Use the AsDataSet extension method
                    var result = reader.AsDataSet();
                    sheets = result.Tables.OfType<DataTable>().ToList();
                    // The result of each spreadsheet is in result.Tables
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {

            var printPreview = new PrintPreviewDialog();
            var printDialog = new PrintDialog();


            var printDocument = new PrintDocument();
            printDialog.Document = printDocument;
            DialogResult = printDialog.ShowDialog();
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            PrinterSettings ps = new PrinterSettings();
            var paperSizes = ps.PaperSizes.Cast<PaperSize>().ToList();
            PaperSize sizeA4 = paperSizes.First<PaperSize>(size => size.PaperName == "check"); // setting paper size to A4 size
            //PaperSize sizeA4 = paperSizes.First<PaperSize>(size => size.PaperName == "A4"); // setting paper size to A4 size
            printDocument.DefaultPageSettings.PaperSize = sizeA4;


            printPreview.PrintPreviewControl.Zoom = 1.0;
            printPreview.Document = printDocument;
            var viewResult = printPreview.ShowDialog();
            if (viewResult == DialogResult.Cancel)
            {
                //  printDocument.Print();
            }

/*            if (DialogResult == DialogResult.OK)
            {
                //printDocument.Print();
            }*/
        }


        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            //e.Graphics.DrawImage(_image, 0, 0, _pageHeight, toInche(7.2));
            e.Graphics.DrawImage(_image, 0, 0, toInche(7.2), _pageHeight);
            e.Graphics.RotateTransform(-90);
            e.Graphics.TranslateTransform(-(_pageHeight ), 0);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            StringFormat stringFormat = new StringFormat(StringFormatFlags.LineLimit);
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            var font = new Font("Times New Roman", 12);
            foreach (var item in _toDrawStrings)
            {
                var test = (int)Math.Ceiling((double)pixelToInche(item.MaxWidth));
                var sizeText = e.Graphics.MeasureString(item.Text, font, (int)Math.Ceiling((double)pixelToInche(item.MaxWidth)));
                var bound = new RectangleF(pixelToInche(item.Position.X), pixelToInche(item.Position.Y), sizeText.Width , sizeText.Height);
                //var bound1 = new Rectangle((int)pixelToInche(item.Position.X), (int)pixelToInche(item.Position.Y),(int) sizeText.Width ,(int) sizeText.Height);
                //e.Graphics.DrawRectangle(Pens.Black, bound1);
                e.Graphics.DrawString(item.Text, font, new SolidBrush(Color.Black), bound);

            }
            if (count < 2)
                e.HasMorePages = true;
            count++;
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

        private void DrawText(Graphics formGraphics, stringDraw el)
        {

            var lfont = new Font("Times New Roman", 8);
            var font = new Font("Times New Roman", 12);
            var sizeText = formGraphics.MeasureString(el.Text, font, el.MaxWidth);
            el.Bound = new Rectangle(el.Position, sizeText.ToSize());
            var sizeLabel = formGraphics.MeasureString(el.Label, lfont);
            var pointlabel = new Point(el.Position.X + (int)(sizeText.Width / 2) - (int)(sizeLabel.Width / 2), el.Position.Y - (int)(sizeLabel.Height));
            if ((_isInDrag && _currentDrawing == el) || (!_isInDrag && _overDrawing == el))
            {
                formGraphics.FillRectangle(Brushes.Bisque, new Rectangle(pointlabel, sizeLabel.ToSize()));
                formGraphics.DrawString(el.Label, lfont, new SolidBrush(Color.Black), pointlabel);
            }
            formGraphics.DrawRectangle(Pens.Black, el.Bound);
            var bound = new RectangleF(el.Position, sizeText);
            formGraphics.DrawString(el.Text, font, new SolidBrush(Color.Black), bound);
            //formGraphics.DrawString($"x : {x} , y: {y}", new Font("Times New Roman", 10), new SolidBrush(Color.Black), x + 100, y + 100);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            float.TryParse(textBoxWidth.Text, out float width);
            float.TryParse(textBoxHeight.Text, out float height);
            Draw(e.Graphics, width, height);
            foreach (var item in _toDrawStrings)
            {
                DrawText(e.Graphics, item);
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

        private void button3_Click(object sender, EventArgs e)
        {
            readFile();
        }
    }
}
