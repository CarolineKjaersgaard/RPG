using Backend.GameLogic.Entity;

namespace Backend.GameLogic.EffectImpl.ActiveEffect
{
    public interface IActiveEffect: IEffect
    {
        public void SetOwner(IEntity owner);
    }
}
