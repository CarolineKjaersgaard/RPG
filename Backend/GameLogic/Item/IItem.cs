using Backend.GameLogic.EffectImpl;
using Backend.GameLogic.EffectImpl.ActiveEffect;
using Backend.GameLogic.EffectImpl.PassiveEffect;

namespace Backend.GameLogic.ItemImpl
{
    public interface IItem
    {
        public string GetName();
        public List<IActiveEffect> GetActiveEffects();
        public bool HasActiveEffect();
        public List<IPassiveEffect> GetPassiveEffects();
        public bool HasPassiveEffect();
        public bool CanBeLooted();

        public string GetItemType();
        public Dictionary<string, object> GetDictionaryRepresentation();

    }
}
