using Backend.GameLogic.Entity;

namespace Backend.GameLogic.EffectImpl.ActiveEffect
{
    public class Heal : IActiveEffect
    {
        string type;
        string desc;
        string title;
        int healMod;
        int baseHeal;
        bool isAOE;
        IEntity? owner;

        public Heal(string type, string desc, string title, int attackMod, int baseDamage, bool isAOE)
        {
            this.type = type;
            this.desc = desc;
            this.title = title;
            healMod = attackMod;
            this.baseHeal = baseDamage;
            this.isAOE = isAOE;
        }
        public bool ApplyEffect(IEntity target)
        {
            
            int healing = baseHeal + healMod;
            target.UpdateHealth(-healing);
            if(owner != null)
            {
                owner.SetLastAction($"{title} restored {healing} hitpoints");
            }
            return true;
        }

        public Dictionary<string, object> GetDictionaryReresentation()
        {
            Dictionary<string, object> dictionaryRepresentation = new Dictionary<string, object>()
            {
                { "title", title },
                {"description", desc },
                {"healing", baseHeal + healMod},
                {"isAOE", isAOE }
            };
            return dictionaryRepresentation;
        }

        public string GetName()
        {
            return title;
        }

        public bool IsPassive()
        {
            return false;
        }

        public void RemoveEffect()
        {
        }

        public void SetOwner(IEntity owner)
        {
            this.owner = owner;
        }
    }
}