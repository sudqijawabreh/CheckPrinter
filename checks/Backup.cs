using CsvHelper;
using CsvHelper.Configuration;
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
            var append = false;
            var lastNumber = 1;
            var toWriteRecords = checkRecords.Select(r => r).ToList();
            if (File.Exists(_fileName))
            {
                using (var reader = new StreamReader(_fileName))
                {
                    using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csvReader.Configuration.RegisterClassMap<CheckRecordMap>();
                        var records = csvReader.GetRecords<CheckRecord>();
                        lastNumber = records.LastOrDefault()?.Number ?? 1;
                        append = true;
                    }
                }
            }
            using (var writer = new StreamWriter(_fileName, append))
            {
                using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    if (append)
                    {
                        csvWriter.Configuration.HasHeaderRecord = false;
                    }
                    csvWriter.Configuration.RegisterClassMap<CheckRecordMap>();
                    if (lastNumber != 1)
                    {
                        toWriteRecords = toWriteRecords.Select((r, i) =>
                        {
                            r.Number = lastNumber + i + 1;
                            return r;
                        }).ToList();
                    }

                    csvWriter.WriteRecords(toWriteRecords);
                }
            }
        }
        public List<CheckRecord> Read()
        {
            var recordsToReturn = new List<CheckRecord>();
            if (File.Exists(_fileName))
            {
                using (var reader = new StreamReader(_fileName))
                {
                    using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csvReader.Configuration.RegisterClassMap<CheckRecordMap>();
                        var records = csvReader.GetRecords<CheckRecord>();
                        return records.ToList();
                    }
                }
            }
            return recordsToReturn;
        }
    }

        class CheckRecordMap : ClassMap<CheckRecord>
    {
        public CheckRecordMap()
        {
            Map(r => r.Number);
            Map(r => r.SN).Name("Serial Number");
            Map(r => r.IDNumber).Name("ID Number");
            Map(r => r.Name);
            Map(r => r.Currency);
            Map(r => r.Amount);
            Map(r => r.CheckDate).Name("Check Date");
            Map(r => r.PrintDate).Name("Print Date");
            Map(r => r.Area);
        }
    }
}
