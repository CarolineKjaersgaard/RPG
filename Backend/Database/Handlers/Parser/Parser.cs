using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using Backend.Database.Tables;

namespace Backend.Database.Handlers
{
    public class Parser
    {
        public List<Table> Parse<Table>(string filePath) where Table : ITable
        {
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = "|",
                    HasHeaderRecord = true 
                };
                using var reader = new StreamReader(filePath);
                using var csv = new CsvReader(reader, config);
                return csv.GetRecords<Table>().ToList();
            }
            catch
            {
                return new List<Table>();
            }
        }
    }
}