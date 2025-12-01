using Backend.Database.Tables;
using Backend.GameLogic.EffectImpl;
using Backend.GameLogic.EffectImpl.ActiveEffect;
using Backend.GameLogic.EffectImpl.PassiveEffect;
using Backend.GameLogic.ItemImpl;

namespace Backend.GameLogic.Entity
{
    public class EntityFactory : IEntityFactory
    {
        public IEntity CreateEntity(Enemy enemyStats, IGame game)
        {
            List<IItem> items = new List<IItem>();
            IItemFactory itemFactory = new ItemFactory();
            items.Add(itemFactory.Create(enemyStats.Weapon, game));
            if(enemyStats.Loot != null)
            {
                foreach (LootOnEnemy item in enemyStats.Loot)
                {
                    items.Add(itemFactory.Create(item.Item, game));
                }
            }
            
            IEntity entity = new EntityImpl(enemyStats.Type.Title, 10, enemyStats.Title, 0, enemyStats.Title, enemyStats.Description, " ", 0, items, 10);
            return entity;
        }
    }

}