using CsvHelper;
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
                using var reader = new StreamReader(filePath);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                return csv.GetRecords<Table>().ToList();
            }
            catch
            {
                return new List<Table>();
            }
        }
    }
}