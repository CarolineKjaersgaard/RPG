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
                Console.WriteLine(filePath);
                Console.WriteLine(File.ReadAllText(filePath));
                
Console.WriteLine($"File exists: {File.Exists(filePath)}");
Console.WriteLine($"Full path: {Path.GetFullPath(filePath)}");

                using (var reader = new StreamReader(filePath))
                {
                                    Console.WriteLine("*-*--------trying csv reader----------*-*");
                using (var csv = new CsvReader(reader, config))
                    {
                                        Console.WriteLine("*-*--------parser made it----------*-*");
                
try
{
    return csv.GetRecords<Table>().ToList();
}
catch (Exception ex)
{
    Console.WriteLine($"CsvHelper error: {ex.Message}");
    throw;
}
                    }

                }


            }
            catch
            {
                Console.WriteLine("*-*--------parser failed----------*-*");
                return new List<Table>();
            }
        }
    }
}