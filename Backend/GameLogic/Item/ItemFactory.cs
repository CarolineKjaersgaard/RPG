using Backend.Database.Tables;
using Backend.GameLogic.EffectImpl;

namespace Backend.GameLogic.ItemImpl
{
    public class ItemFactory : IItemFactory
    {
        public IItem Create(Item itemStats, IGame game)
        {
            List<Effect> effects = new List<Effect>(){itemStats.Effect};
            List<IEffect> effectImpls = new List<IEffect>();
            EffectFactory effectFactory = new EffectFactory();
            foreach(Effect effect in effects)
            {
                effectImpls.Add(effectFactory.CreateEffect(effect));
            }
            IItem item = new ItemImpl(itemStats.Title, itemStats.Description, itemStats.Rarity, " ", itemStats.ItemType.Title, itemStats.isLootable, effectImpls);
            return item;
        }
    }

}