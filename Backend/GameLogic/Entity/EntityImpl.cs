using Backend.GameLogic.Effect;
using Backend.GameLogic.Item;

namespace Backend.GameLogic.Entity
{
    public class EntityImpl : IEntity
    {
        string type;
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
        public void AddItem(IItem item)
        {
            if(item.GetType() == "weapon")
            {
                weapon.Add(item);
                effects.Add(item.GetName(), item.GetEffect());       
            }
            if(item.GetEffect().IsPassive())
            {
                buffs.Add(item);
                item.GetEffect().ApplyEffect(this);
                effects.Add(item.GetName(), item.GetEffect());
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
            throw new NotImplementedException();
        }

        public int GetHealth()
        {
            throw new NotImplementedException();
        }

        public List<IItem> GetItems()
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }
    }
}