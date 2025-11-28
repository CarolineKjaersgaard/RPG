using Backend.Database.Tables;

namespace Backend.GameLogic.Entity
{
    public interface IEntityFactory
    {
        public IEntity CreateEntity(Enemy enemyStats, IGame game);
    }
}