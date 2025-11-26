using Backend.GameLogic.Entity;

namespace Backend.GameLogic.Effect
{
    public interface IEffect
    {
        public bool ApplyEffect(IEntity target);

        public void RemoveEffect();
    }
}
