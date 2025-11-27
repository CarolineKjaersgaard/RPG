using Backend.GameLogic.Effect;
using Backend.GameLogic.Effect.ActiveEffect;
using Backend.GameLogic.Effect.PassiveEffect;

namespace Backend.GameLogic.Item
{
    public class ItemImpl : IItem
    {
        string Title;
        string description;
        int rarity;
        string icon;
        string type;
        IEffect effect;
        bool isLootable;

        public bool CanBeLooted()
        {
            throw new NotImplementedException();
        }

        public List<IActiveEffect> GetActiveEffects()
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }

        public List<IPassiveEffect> GetPassiveEffects()
        {
            throw new NotImplementedException();
        }

        public bool HasActiveEffect()
        {
            throw new NotImplementedException();
        }

        public bool HasPassiveEffect()
        {
            throw new NotImplementedException();
        }

        string IItem.GetType()
        {
            throw new NotImplementedException();
        }
    }
}