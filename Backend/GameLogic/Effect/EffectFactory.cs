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
            bool isActive = false;
            if(effectStats != null)
            {
                isActive = (bool)effectStats.isActive;
            }
            if(effectStats.Type.Title == "healing" && isActive)
            {
                effect = new Heal(effectStats.Type.Title, effectStats.Description, effectStats.Title, 0, effectStats.Amount, false);
            }
            else if(effectStats.Type.Title == "attack" && isActive)
            {
                effect = new Attack(effectStats.Type.Title, effectStats.Description, effectStats.Title, 0, effectStats.Amount, false);
            }
            else
            {
                effect = new PassiveEffectImpl(effectStats.Title, effectStats.Description, " ", " ", effectStats.Amount, " ");
            }
            return effect;
        }
    }

}