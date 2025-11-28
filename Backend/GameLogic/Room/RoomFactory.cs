using Backend.Database.Tables;
using Backend.GameLogic;
using Backend.GameLogic.Entity;
using Backend.GameLogic.Item;

namespace Backend.GameLogic
{
    public class RoomFactory : IRoomFactory
    {
        public IRoom CreateRoom(Room roomStats)
        {
            IRoom room = new RoomImpl(" ", true, " ", " ", (0,0));
            return room;
        }
    }
}
