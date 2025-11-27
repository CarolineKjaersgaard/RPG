using Backend.GameLogic.Entity;

namespace Backend.GameLogic.Effect.ActiveEffect
{
    public interface IActiveEffect: IEffect
    {
        public void SetOwner(IEntity owner);
    }
}
