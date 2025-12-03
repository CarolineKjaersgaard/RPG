using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using Backend.Database.Tables;
using System;

namespace Backend.Database.Handlers
{
    public class Parser
    {
        public List<Table> Parse<Table>(string filePath) where Table : ITable
        {
            Console.WriteLine("*-*--------parser----------*-*");
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = "|",
                    HasHeaderRecord = true 
                };
                Console.WriteLine("*-*--------truing stream----------*-*");
                using var reader = new StreamReader(filePath);
                Console.WriteLine("*-*--------trying csv reader----------*-*");
                using var csv = new CsvReader(reader, config);
                Console.WriteLine("*-*--------parser made it----------*-*");
                return csv.GetRecords<Table>().ToList();
            }
            catch
            {
                Console.WriteLine("*-*--------parser failed----------*-*");
                return new List<Table>();
            }
        }
    }
}