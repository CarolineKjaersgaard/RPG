using Backend.GameLogic.Effect;
using Backend.GameLogic.Effect.ActiveEffect;
using Backend.GameLogic.Effect.PassiveEffect;
using Backend.GameLogic.Item;

namespace Backend.GameLogic.Entity
{
    public class EntityImpl : IEntity
    {
        string type;
        int health;
        string name;
        int damageMod;
        string title;
        string Desc;
        string icon;
        int damageReduction;
        List<IItem> buffs = new List<IItem>();
        List<IItem> loot = new List<IItem>();
        List<IItem> weapon = new List<IItem>();
        Dictionary<string, IEffect> effects = new Dictionary<string, IEffect>();

        public EntityImpl(string type, int health, string name, int damageMod, string title, string desc, string icon, int damageReduction, List<IItem> items)
        {
            this.type = type;
            this.health = health;
            this.name = name;
            this.damageMod = damageMod;
            this.title = title;
            Desc = desc;
            this.icon = icon;
            this.damageReduction = damageReduction;
            foreach(IItem item in items)
            {
                AddItem(item);
            }
        }

        public void AddItem(IItem item)
        {
            foreach(IActiveEffect activeEffect in item.GetActiveEffects())
            {
                effects.Add(activeEffect.GetName(), activeEffect);
            }
            foreach(IPassiveEffect passiveEffect in item.GetPassiveEffects())
            {
                effects.Add(passiveEffect.GetName(), passiveEffect);
                if(!buffs.Contains(item))
                {
                    buffs.Add(item);
                }
                passiveEffect.ApplyEffect(this);
            }
            if(item.GetType() == "weapon")
            {
                weapon.Add(item);     
            }
            if(item.CanBeLooted())
            {
                loot.Add(item);
            }
        }

        public bool EndEffect(string effect)
        {
            if(effects.ContainsKey(effect))
            {
                effects[effect].RemoveEffect();
                return true;
            }
            return false;
        }

        public bool ExecuteEffect(string effect, IEntity target)
        {
            if(effects.ContainsKey(effect))
            {
                return effects[effect].ApplyEffect(target);
            }
            return false;
        }

        public List<string> GetEffectNames()
        {
            return effects.Keys.ToList();
        }

        public int GetHealth()
        {
            return health;
        }

        public List<IItem> GetItems()
        {
            return loot;
        }

        public string GetName()
        {
            return title;
        }
    }
}