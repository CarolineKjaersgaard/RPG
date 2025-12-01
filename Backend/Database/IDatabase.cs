using Backend.Database.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Backend.Database
{
    public interface IDatabase
    {
        public Table GetItem<Table>(string id) where Table: class, ITable;

        public List<Table> GetItems<Table>() where Table: class, ITable;

        public List<Table> GetItems<Table>(object value, string column) where Table: class, ITable;

        public List<Table> GetItems<Table>(int lowerValue, int upperValue, string column) where Table: class, ITable;
    }
}
