using Backend.Database.Tables;
using Backend.GameLogic.EffectImpl;

namespace Backend.GameLogic.ItemImpl
{
    public class ItemFactory : IItemFactory
    {
        public IItem Create(Item itemStats, IGame game)
        {
            List<Effect> effects = new List<Effect>();
            List<IEffect> effectImpls = new List<IEffect>();
            if (itemStats.Effect != null)
            {
                effects.Add(itemStats.Effect);
                EffectFactory effectFactory = new EffectFactory();
                foreach (Effect effect in effects)
                {
                    effectImpls.Add(effectFactory.CreateEffect(effect));
                }
            }
            
            IItem item = new ItemImpl(itemStats.Title, itemStats.Description, itemStats.Rarity, " ", itemStats.Type.Title, itemStats.isLootable, effectImpls);
            return item;
        }
    }

}