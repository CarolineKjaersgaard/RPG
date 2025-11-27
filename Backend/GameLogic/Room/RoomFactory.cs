using Backend.Database.Tables;

namespace Backend.GameLogic
{
    public class RoomFactory : IRoomFactory
    {
        public IRoom CreateRoom(ITable roomStats)
        {
            return new RoomImpl();
        }
    }
}
