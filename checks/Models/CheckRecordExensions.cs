using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checks.Models
{
    public static class CheckRecordExensions
    {
        public static GridViewRecord ToGridViewRecord(this CheckRecord record)
        {
            return new GridViewRecord
            {
                Name = record.Name,
                Number = record.Number,
                Amount = record.Amount,
                CheckDate = record.CheckDate,
                AmountInWords = record.AmountInWords,
                SN = record.SN,
            };
        }
    }
}
