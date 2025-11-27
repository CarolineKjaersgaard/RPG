using Backend.GameLogic.Entity;

namespace Backend.GameLogic.Effect.ActiveEffect
{
    public class Attack : IActiveEffect
    {
        string type;
        string desc;
        string title;
        int AttackMod;
        int baseDamage;
        bool isAOE;
        IEntity? owner;

        public Attack(string type, string desc, string title, int attackMod, int baseDamage, bool isAOE)
        {
            this.type = type;
            this.desc = desc;
            this.title = title;
            AttackMod = attackMod;
            this.baseDamage = baseDamage;
            this.isAOE = isAOE;
        }

        public bool ApplyEffect(IEntity target)
        {
            int ownerAttackMod = 0;
            if(owner != null)
            {
                ownerAttackMod = owner.GetAttackMod();
            }
            Random rnd = new Random();
            int attack = rnd.Next(1, 21) + AttackMod + ownerAttackMod;
            if(attack >= target.GetDefense())
            {
                int ownerDamageMod = 0;
                if(owner != null)
                {
                    ownerDamageMod = owner.GetDamageMod();
                }
                int damage = baseDamage + ownerDamageMod;
                target.UpdateHealth(damage);
                if(owner != null)
                {
                    owner.SetLastAction($"{title} hit dealing {damage} damage");
                }
                return true;
            }
            if(owner != null)
            {
                owner.SetLastAction($"{title} missed");
            }
            return false;
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