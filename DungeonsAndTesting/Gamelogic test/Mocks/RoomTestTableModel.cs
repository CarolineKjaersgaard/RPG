
using Backend.Database.Tables;
namespace DungeonsAndTesting.Gamelogic_test.Mocks
{
    public class RoomTestTableModel : ITable
    {
        private string id = "1";
        public string Id { get => id; set => id = value; }
        private string title = "test";
        public string Title { get => title; set => title = value; }

        public List<string> GetCollumns()
        {
            throw new NotImplementedException();
        }

        public List<string> GetValues()
        {
            throw new NotImplementedException();
        }
    }
}
