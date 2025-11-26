using Backend.GameLogic.Entity;
using Backend.GameLogic.Item;

namespace Backend.GameLogic.Room
{
    public interface IRoom
    {
        public List<IEntity> GetMonsters();
        public void SetEntryDoor((int, int) playerCoords);

        public List<IItem> GetItems();
    }
}
