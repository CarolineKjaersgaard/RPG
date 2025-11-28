using Backend.Database.Tables;

namespace Backend.Database.DatabaseHandlers
{
    public class DatabaseHandler : IDatabase
    {
        public Table GetItem<Table>(string id) where Table : ITable, new()
        {
            throw new NotImplementedException();
        }

        public List<Table> GetItems<Table>(string value, string collumn) where Table : ITable, new()
        {
            throw new NotImplementedException();
        }

        public List<Table> GetItems<Table>(int value, string collumn) where Table : ITable, new()
        {
            throw new NotImplementedException();
        }

        public List<Table> GetItems<Table>(int lowerValue, int upperValue, string collumn) where Table : ITable, new()
        {
            throw new NotImplementedException();
        }
    }
}
