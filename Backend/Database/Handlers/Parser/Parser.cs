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
            Console.WriteLine("*-*--------parser----------*-*");
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = "|",
                    HasHeaderRecord = true,
                    HeaderValidated = null,
                    MissingFieldFound = null
                };
                Console.WriteLine("*-*--------truing stream----------*-*");
                string fullPath = Path.GetFullPath(filePath);
                using var reader = new StreamReader(filePath);
                Console.WriteLine("*-*--------trying csv reader----------*-*");
                using var csv = new CsvReader(reader, config);
                
                Console.WriteLine("*-*--------parser made it----------*-*");
                //Console.WriteLine(csv.GetRecords<Table>().Count());

                var records = new List<Table>();
                while(csv.Read())
                {
                    records.Add(csv.GetRecord<Table>());
                }
                Console.WriteLine(typeof(Table).ToString() + " " + records.Count);
                return records;
            }
            catch(Exception e)
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length > 0)
                {
                    // Get the first line and split by comma
                    string[] headers = lines[0].Split('|');

                    // Display headers
                    foreach (var header in headers)
                    {
                        Console.Write(header + " | ");
                    }
                }
                Console.WriteLine("*-*--------parser failed----------*-* " + e.Message + " " + filePath);
                return new List<Table>();
            }
        }
    }
}