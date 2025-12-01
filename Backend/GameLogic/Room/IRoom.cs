using Backend.GameLogic.EffectImpl;
using Backend.GameLogic.Entity;
using Backend.GameLogic.ItemImpl;

namespace Backend.GameLogic
{
    public interface IRoom
    {
        public List<IEntity> GetMonsters();
        public void SetEntryDoor((int, int) playerCoords);
        public List<IItem> GetItems();
        public void SetEffect(IEffect effect);
        public IEffect GetEffect();

        public bool HasDoor((int, int) coords);
        public void SetDoors(Dictionary<(int, int), bool> doors);
    }
}
