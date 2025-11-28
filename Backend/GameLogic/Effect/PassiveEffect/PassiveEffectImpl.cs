using Backend.GameLogic.Entity;

namespace Backend.GameLogic.EffectImpl.PassiveEffect
{
    public class PassiveEffectImpl : IPassiveEffect
    {
        string title;
        string desc;
        string icon;
        string buffType;
        int amount;
        string stat;
        IEntity? activeTarget;
        int oldValue;

        public PassiveEffectImpl(string title, string desc, string icon, string buffType, int amount, string stat)
        {
            this.title = title;
            this.desc = desc;
            this.icon = icon;
            this.buffType = buffType;
            this.amount = amount;
            this.stat = stat;
        }

        public bool ApplyEffect(IEntity target)
        {
            activeTarget = target;
        
            switch(stat)
                {
                    case "maxHealth":
                        oldValue = target.GetMaxHealth();
                        target.UpdateMaxHealth(CalculateBuff(target, target.GetMaxHealth()));
                        return true;
                    default:
                        return false;
                }
        }

        private int CalculateBuff(IEntity target, int currentValue)
        {
            switch(buffType)
            {
                case "simple":
                    return amount;
                default:
                    return 0;
            }
        }

        public string GetName()
        {
            return title;
        }

        public bool IsPassive()
        {
            return true;
        }

        public void RemoveEffect()
        {
            if(activeTarget != null)
            {
                switch(stat)
                {
                    case "maxHealth":
                        activeTarget.UpdateMaxHealth(-CalculateBuff(activeTarget, oldValue));
                        break;
                }
            }
            
        }
    }
}