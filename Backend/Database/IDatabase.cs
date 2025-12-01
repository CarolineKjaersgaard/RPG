using Backend.Database.Tables;

namespace Backend.Database
{
    public interface IDatabase
    {
        public Table GetItem<Table>(string id) where Table: class, ITable;

        public List<Table> GetItems<Table>(object value, string column) where Table: class, ITable;

        public List<Table> GetItems<Table>(int lowerValue, int upperValue, string column) where Table: class, ITable;
    }
}
