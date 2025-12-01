using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Database;
using Backend.Database.Tables;
using ITable = Backend.Database.Tables.ITable;
namespace DungeonsAndTesting.Gamelogic_test.Mocks
{
    public class TestDatabase : IDatabase
    {
        List<Room> rooms = new List<Room>();
        

        public List<Table> GetItems<Table>(string value, string collumn) where Table : ITable
        {
            return new List<Table>();
            
        }

        public List<Table> GetItems<Table>(int value, string collumn) where Table : ITable
        {
            return new List<Table>();
        }

        Table IDatabase.GetItem<Table>(string id)
        {
            throw new NotImplementedException();
        }

        List<Table> IDatabase.GetItems<Table>(object value, string column)
        {
            return new List<Table>();
        }

        List<Table> IDatabase.GetItems<Table>(int lowerValue, int upperValue, string column)
        {
            return new List<Table>();
        }
    }
}
