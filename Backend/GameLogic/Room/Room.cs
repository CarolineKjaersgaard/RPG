using Backend.GameLogic.Entity;
using Backend.GameLogic.Item;

namespace Backend.GameLogic
{
    public class RoomImpl : IRoom
    {
        public List<IItem> GetItems()
        {
            throw new NotImplementedException();
        }

        public List<IEntity> GetMonsters()
        {
            return new List<IEntity>();
        }

        public void SetEntryDoor((int, int) playerCoords)
        {
            throw new NotImplementedException();
        }
    }
}