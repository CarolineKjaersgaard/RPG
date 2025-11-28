using ITable = Backend.Database.Tables.ITable;

namespace Backend.Database
{
    public interface IDatabase
    {
        public Table GetItem<Table>(string id) where Table: ITable;

        public List<Table> GetItems<Table>(string value, string collumn) where Table: ITable;

        public List<Table> GetItems<Table>(int value, string collumn) where Table: ITable;

        public List<Table> GetItems<Table>(int lowerValue, int upperValue, string collumn) where Table: ITable;
    }
}
