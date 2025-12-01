using Backend.Database.Tables;

namespace Backend.GameLogic
{
    public interface IRoomFactory
    {
        public IRoom CreateRoom(Room roomStats, IGame game, (int, int) coords);
    }
}
