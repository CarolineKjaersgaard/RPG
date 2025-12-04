using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using Backend.Database.Tables;
using System;

namespace Backend.Database.Handlers
{
    public class Parser
    {
        public IEnumerable<Table> Parse<Table>(string filePath) where Table : ITable
        {
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = "|",
                    HasHeaderRecord = true,
                    HeaderValidated = null,
                    MissingFieldFound = null
                };
                string fullPath = Path.GetFullPath(filePath);
                using var reader = new StreamReader(filePath);
                using var csv = new CsvReader(reader, config);

                var records = new List<Table>();
                while(csv.Read())
                {
                    records.Add(csv.GetRecord<Table>());
                }
                return records;
            }
            catch(Exception e)
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length > 0)
                {
                    // Get the first line and split by comma
                    string[] headers = lines[0].Split('|');
                }
                return new List<Table>();
            }
        }
    }
}