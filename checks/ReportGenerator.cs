using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checks
{
    class ReportGenerator
    {
        public static void Genereate(string importedFileName, string exportFileName, string sheetName, int headerRow, List<string> SN)
        {
            if (string.IsNullOrEmpty(importedFileName) || string.IsNullOrEmpty(exportFileName))
                return;

            var workbook = new XLWorkbook(importedFileName);
            var ws = workbook.Worksheet(sheetName);
            var c = ws.Column(2);
            var insertedColumn = c.InsertColumnsBefore(1);
            ws.Cell(headerRow, 2).Value = "Serial Number";
            SN.Select((n, i) => new { number = n, index = i }).ToList().ForEach(v =>
              {
                  ws.Cell(v.index + headerRow + 1, 2).Value = v.number;
              });
            insertedColumn.AdjustToContents();

            workbook.SaveAs(exportFileName);
        }
    }
}
