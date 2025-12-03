using Backend.GameLogic.EffectImpl;
using Backend.GameLogic.EffectImpl.ActiveEffect;
using Backend.GameLogic.EffectImpl.PassiveEffect;

namespace Backend.GameLogic.ItemImpl
{
    public class ItemImpl : IItem
    {
        string Title;
        string description;
        int rarity;
        string icon;
        string itemType;
        List<IActiveEffect> activeEffects = new List<IActiveEffect>();
        List<IPassiveEffect> passiveEffects = new List<IPassiveEffect>();
        bool isLootable;

        public ItemImpl(string title, string description, int rarity, string icon, string itemType, bool isLootable, List<IEffect> effects)
        {
            Title = title;
            this.description = description;
            this.rarity = rarity;
            this.icon = icon;
            this.itemType = itemType;
            this.isLootable = isLootable;
            foreach(IEffect effect in effects)
            {
                if(effect.GetType() == typeof(IActiveEffect))
                {
                    activeEffects.Add((IActiveEffect)effect);
                }
                else if(effect.GetType() == typeof(IPassiveEffect))
                {
                    passiveEffects.Add((IPassiveEffect)effect);
                }
            }
        }

        public bool CanBeLooted()
        {
            return isLootable;
        }

        public List<IActiveEffect> GetActiveEffects()
        {
            return activeEffects;
        }

        public string GetName()
        {
            return Title;
        }

        public List<IPassiveEffect> GetPassiveEffects()
        {
            return passiveEffects;
        }

        public bool HasActiveEffect()
        {
            return activeEffects.Count > 0;
        }

        public bool HasPassiveEffect()
        {
            return passiveEffects.Count > 0;
        }

        public string GetItemType()
        {
            return itemType;
        }

        public Dictionary<string, object> GetDictionaryRepresentation()
        {
            Dictionary<string, object> dictionaryRepresentation = new Dictionary<string, object>()
            {
                { "title", Title },
                {"description", description },
                {"rarity", rarity },
                {"item type", itemType },
                {"active effects", GetActiveEffectDictionaryRepresentation()  },
                {"passive effects", GetPassiveEffectDictionaryRepresentation() }
            };
            return dictionaryRepresentation;
        }

        private Dictionary<string, object> GetActiveEffectDictionaryRepresentation()
        {
            Dictionary<string, object> dictionaryRepresentation = new Dictionary<string, object>();
            foreach(IActiveEffect activeEffect in activeEffects)
            {
                dictionaryRepresentation.Add(activeEffect.GetName(), activeEffect.GetDictionaryReresentation());
            }
            return dictionaryRepresentation;
        }
        private Dictionary<string, object> GetPassiveEffectDictionaryRepresentation()
        {
            Dictionary<string, object> dictionaryRepresentation = new Dictionary<string, object>();
            foreach (IPassiveEffect passiveEffect in passiveEffects)
            {
                dictionaryRepresentation.Add(passiveEffect.GetName(), passiveEffect.GetDictionaryReresentation());
            }
            return dictionaryRepresentation;
        }
    }
}