using Backend.Database.Tables;
using Backend.GameLogic.EffectImpl.ActiveEffect;
using Backend.GameLogic.EffectImpl.PassiveEffect;

namespace Backend.GameLogic.EffectImpl
{
    public class EffectFactory : IEffectFactory
    {
        public IEffect CreateEffect(Effect effectStats)
        {
            IEffect effect;
            if(effectStats.isActive && effectStats.EffectType.Title == "healing")
            {
                effect = new Heal(effectStats.EffectType.Title, effectStats.Description, effectStats.Title, 0, effectStats.Amount, effectStats.isAoe);
            }
            else if(effectStats.isActive)
            {
                effect = new Attack(effectStats.EffectType.Title, effectStats.Description, effectStats.Title, 0, effectStats.Amount, effectStats.isAoe);
            }
            else
            {
                effect = new PassiveEffectImpl(effectStats.Title, effectStats.Description, " ", " ", effectStats.Amount, effectStats.TargetType.Title);
            }
            return effect;
        }
    }

}