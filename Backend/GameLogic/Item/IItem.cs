using Backend.GameLogic.Effect;
using Backend.GameLogic.Effect.ActiveEffect;
using Backend.GameLogic.Effect.PassiveEffect;

namespace Backend.GameLogic.Item
{
    public interface IItem
    {
        public string GetName();
        public List<IActiveEffect> GetActiveEffects();
        public bool HasActiveEffect();
        public List<IPassiveEffect> GetPassiveEffects();
        public bool HasPassiveEffect();
        public bool CanBeLooted();

        public string GetType();

    }
}
