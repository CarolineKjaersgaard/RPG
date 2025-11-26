using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndTesting.Gamelogic_test.Mocks
{
    public class TestDatabase : IDatabase
    {
        public ITable GetItem<ITable>(string id)
        {
            throw new NotImplementedException();
        }

        public List<ITable> GetItems<ITable>(string value, string collumn)
        {
            throw new NotImplementedException();
        }

        public List<ITable> GetItems<ITable>(int value, string collumn)
        {
            throw new NotImplementedException();
        }

        public List<ITable> GetItems<ITable>(int lowerValue, int upperValue, string collumn)
        {
            throw new NotImplementedException();
        }
    }
}
