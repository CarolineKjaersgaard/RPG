using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Database.DatabaseHandlers;
using Backend.Database.Tables;
using ITable = Backend.Database.Tables.ITable;
namespace DungeonsAndTesting.Gamelogic_test.Mocks
{
    public class TestDatabase : IDatabase
    {
        public Table GetItem<Table>(string id) where Table : ITable, new()
        {
            throw new NotImplementedException();
        }

        public List<Table> GetItems<Table>(string value, string collumn) where Table : ITable, new()
        {
            Table table = new Table();
            return new List<Table>(){table};
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
