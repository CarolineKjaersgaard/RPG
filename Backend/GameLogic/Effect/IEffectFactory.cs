using Backend.Database.Tables;

namespace Backend.GameLogic.EffectImpl
{
    public interface IEffectFactory
    {
        public IEffect CreateEffect(Effect effectStats);
    }
}