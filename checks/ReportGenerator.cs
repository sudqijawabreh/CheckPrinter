using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checks
{
    partial class ReportGenerator
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
            ws.Cell(1, 9).Value = "Area";
            records.Select((r, i) => new { record = r, index = i + 1 }).ToList().ForEach(v =>
              {
                  ws.Cell(v.index + 1, 1).Value = v.index.ToString();
                  ws.Cell(v.index + 1, 2).Value = v.record.SN;
                  ws.Cell(v.index + 1, 3).Value = v.record.IDNumber;
                  ws.Cell(v.index + 1, 4).Value = v.record.Name;
                  ws.Cell(v.index + 1, 5).Value = v.record.Currency;
                  ws.Cell(v.index + 1, 6).Value = v.record.Amount;
                  ws.Cell(v.index + 1, 7).Value = v.record.CheckDate;
                  ws.Cell(v.index + 1, 8).Value = v.record.PrintDate;
                  ws.Cell(v.index + 1, 9).Value = v.record.Area;
              });
            Enumerable.Range(1, 9).ToList().ForEach(i =>
             {
                 ws.Column(i).AdjustToContents();
                 ws.Column(i).Width = 17;
             });

            ws.Row(1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Row(1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
            ws.Row(1).Style.Font.FontSize = 12;
            ws.Row(1).Style.Font.Bold = true;

            ws.Rows(1, records.Count + 1).ToList().ForEach(row =>
             {
                 row.GetRowCells(9).ToList().ForEach(c =>
                {
                       c.Style.Border.SetBottomBorder(XLBorderStyleValues.Thin);
                       c.Style.Border.SetLeftBorder(XLBorderStyleValues.Thin);
                       c.Style.Border.SetTopBorder(XLBorderStyleValues.Thin);
                       c.Style.Border.SetRightBorder(XLBorderStyleValues.Thin);

                       c.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                       c.Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                });
            });

            ws.Row(1).Height = 35;
            ws.Rows(2, records.Count() + 1).ToList().ForEach(row =>
             {
                 row.Height = 25;

             });
            ws.Column(4).Width = 41;

            workbook.SaveAs(exportFileName);
        }
    }
}
