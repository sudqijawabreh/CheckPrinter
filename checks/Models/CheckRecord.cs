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

namespace checks
{
    public class CheckRecord
    {
        public int Number { get; set; }
        public string SN { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public string CheckDate { get; set; }
        public string AmountInWords { get; set; }
        public string PrintDate { get; set; }
        public string Currency { get; set; }
        public string Area { get; set; }
        public string IDNumber { get; set; }
    }
}
