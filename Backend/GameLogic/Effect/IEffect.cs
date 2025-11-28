using Backend.GameLogic.Entity;

namespace Backend.GameLogic.EffectImpl
{
    public interface IEffect
    {
        public bool ApplyEffect(IEntity target);

        public void RemoveEffect();

        public bool IsPassive();
        public string GetName();
    }
}
