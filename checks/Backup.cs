using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checks
{
    public class Backup
    {
        private string _fileName { get; set; }

        public Backup(string fileName)
        {
            _fileName = fileName;
        }

        public void Write(List<CheckRecord> checkRecords)
        {
            using(var writer = new StreamWriter(_fileName))
            {
                using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords<CheckRecord>(checkRecords);
                }
            }
        }
    }
}
