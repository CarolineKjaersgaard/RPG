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
        Dictionary<string, IEffect> activeEffects = new Dictionary<string, IEffect>();
        public void AddItem(IItem item)
        {
            if(item.GetType() == "weapon")
            {
                weapon.Add(item);       
            }
            if(item.GetEffect().IsPassive())
            {
                buffs.Add(item);
                item.GetEffect().ApplyEffect(this);
            }
            if(item.CanBeLooted())
            {
                loot.Add(item);
            }
        }

        public bool EndEffect(string effect)
        {
            if(activeEffects.ContainsKey(effect))
            {
                activeEffects[effect].RemoveEffect();
                return true;
            }
            return false;
        }

        public bool ExecuteEffect(string effect, IEntity target)
        {
            throw new NotImplementedException();
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