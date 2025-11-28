using Backend.Database.Tables;

namespace Backend.GameLogic.ItemImpl
{
    public interface IItemFactory
    {
        public IItem Create(Item itemStats, IGame game);
    }
}