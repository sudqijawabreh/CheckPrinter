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
            ws.Cell(headerRow, 2).Value = "Check Number";
            SN.Select((n, i) => new { number = n, index = i }).ToList().ForEach(v =>
              {
                  ws.Cell(v.index + headerRow + 1, 2).Value = v.number;
              });
            insertedColumn.AdjustToContents();

            workbook.SaveAs(exportFileName);
        }
        public static void ExportHistory(string exportFileName, List<CheckRecord> records)
        {
            if ( string.IsNullOrEmpty(exportFileName))
                return;

            var workbook = new XLWorkbook();
            var ws = workbook.AddWorksheet();
            ws.Cell(1, 1).Value = "Number";
            ws.Cell(1, 2).Value = "Check Number";
            ws.Cell(1, 3).Value = "ID Number";
            ws.Cell(1, 4).Value = "Name";
            ws.Cell(1, 5).Value = "Currency";
            ws.Cell(1, 6).Value = "Amount";
            ws.Cell(1, 7).Value = "Check Date";
            ws.Cell(1, 8).Value = "Print Date";
            records.Select((r, i) => new { record = r, index = i }).ToList().ForEach(v =>
              {
                  ws.Cell(v.index + 2, 1).Value = (v.index + 1).ToString();
                  ws.Cell(v.index + 2, 2).Value = v.record.SN;
                  ws.Cell(v.index + 2, 3).Value = v.record.IDNumber;
                  ws.Cell(v.index + 2, 4).Value = v.record.Name;
                  ws.Cell(v.index + 2, 5).Value = v.record.Currency;
                  ws.Cell(v.index + 2, 6).Value = v.record.Amount;
                  ws.Cell(v.index + 2, 7).Value = v.record.CheckDate;
                  ws.Cell(v.index + 2, 8).Value = v.record.PrintDate;
              });
            Enumerable.Range(1, 8).ToList().ForEach(i =>
             {
                 ws.Column(i).AdjustToContents();
             });

            workbook.SaveAs(exportFileName);
        }
    }
}
