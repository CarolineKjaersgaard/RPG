using System.Reflection.Metadata.Ecma335;
using Backend.GameLogic.EffectImpl;
using Backend.GameLogic.EffectImpl.ActiveEffect;
using Backend.GameLogic.EffectImpl.PassiveEffect;
using Backend.GameLogic.ItemImpl;

namespace Backend.GameLogic.Entity
{
    public class EntityImpl : IEntity
    {
        string type;
        int health;
        string name;
        int damageMod;
        int attackMod;
        string title;
        int defense;
        string Desc;
        string icon;
        int damageReduction;
        string lastAction = "";
        int maxHealth;
        List<IItem> buffs = new List<IItem>();
        List<IItem> loot = new List<IItem>();
        List<IItem> weapon = new List<IItem>();
        Dictionary<string, IEffect> effects = new Dictionary<string, IEffect>();

        public EntityImpl(string type, int health, string name, int damageMod, string title, string desc, string icon, int damageReduction, List<IItem> items, int defense)
        {
            this.type = type;
            this.health = health;
            maxHealth = health;
            this.name = name;
            this.damageMod = damageMod;
            attackMod = damageMod;
            this.title = title;
            Desc = desc;
            this.icon = icon;
            this.damageReduction = damageReduction;
            foreach (IItem item in items)
            {
                AddItem(item);
                IList<IPassiveEffect> effects = item.GetPassiveEffects();
                foreach(IActiveEffect activeEffect in item.GetActiveEffects())
                {
                    activeEffect.SetOwner(this);
                }
            }

            this.defense = defense;
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
            if(item.GetItemType() == "weapon")
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

        public int GetAttackMod()
        {
            return attackMod;
        }

        public int GetDamageMod()
        {
            return damageMod;
        }

        public int GetDefense()
        {
            return defense;
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

        public int GetMaxHealth()
        {
            return maxHealth;
        }

        public string GetName()
        {
            return title;
        }

        public void SetLastAction(string action)
        {
            lastAction = action;
        }

        public void UpdateAttackMod(int amount)
        {
            attackMod += amount;
        }

        public void UpdateDamageMod(int amount)
        {
            damageMod += amount;
        }

        public void UpdateDefense(int amount)
        {
            defense += amount;
        }

        public void UpdateHealth(int amount)
        {
            health -= amount;
        }

        public void UpdateMaxHealth(int amount)
        {
            maxHealth += amount;
        }
    }
}