using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checks
{
    public static class ExcelExetnsions
    {
        public static IXLCell ApplyCell(this IXLCell cell, Action<IXLCell> action)
        {
            action(cell);
            return cell;
        }
        public static IEnumerable<IXLCell> GetRowCells(this IXLRow row, int columns)
        {
            return Enumerable.Range(1, columns).Select(i => row.Cell(i));
        }
    }
}
