using Backend.GameLogic.Effect;
using Backend.GameLogic.Effect.ActiveEffect;
using Backend.GameLogic.Effect.PassiveEffect;
using Backend.GameLogic.Entity;
using Backend.GameLogic.Item;

namespace Backend.GameLogic.Player
{
    public class PlayerImpl:IPlayer
    {
        private int health = 10;
        private int maxHealth = 10;
        private int defense = 15;
        private int baseAttackMod = 2;
        private int baseDamageMod = 2;
        string lastAction = "";
        private Dictionary<string, IEffect> effects = new Dictionary<string, IEffect>();
        private List<IItem> inventory = new List<IItem>();
        private (int, int) currentCoords = (0, 0);
        private string name = "player";
        public int Health { get => health; private set => health = value; }
        public int Defense { get => defense; private set => defense = value; }
        public int BaseAttackMod { get => baseAttackMod; private set => baseAttackMod = value; }
        public int BaseDamageMod { get => baseDamageMod; private set => baseDamageMod = value; }
        public Dictionary<string, IEffect> Effects { get => effects; private set => effects = value; }
        public List<IItem> Inventory { get => inventory; private set => inventory = value; }
        public (int, int) CurrentCoords { get => currentCoords; set => currentCoords = value; }

        public void AddItem(IItem item)
        {
            inventory.Add(item);
            foreach(IActiveEffect activeEffect in item.GetActiveEffects())
            {
                effects.Add(activeEffect.GetName(), activeEffect);
            }
            foreach(IPassiveEffect passiveEffect in item.GetPassiveEffects())
            {
                effects.Add(passiveEffect.GetName(), passiveEffect);
                passiveEffect.ApplyEffect(this);
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
                return Effects[effect].ApplyEffect(target);
            }
            return false;
        }

        public int GetAttackMod()
        {
            return baseAttackMod;
        }

        public (int, int) GetCoords()
        {
            return CurrentCoords;
        }

        public int GetDamageMod()
        {
            return baseDamageMod;
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
            return inventory;
        }

        public int GetMaxHealth()
        {
            return maxHealth;
        }

        public string GetName()
        {
            return name;
        }

        public void SetLastAction(string action)
        {
            lastAction = action;
        }

        public void UpdateAttackMod(int amount)
        {
            baseAttackMod += amount;
        }

        public void UpdateDamageMod(int amount)
        {
            baseDamageMod += amount;
        }

        public void UpdateDefense(int amount)
        {
            defense += amount;
        }

        public void UpdateHealth(int amount)
        {
            health -= amount;
            if(health > maxHealth)
            {
                health = maxHealth;
            }
        }

        public void UpdateMaxHealth(int amount)
        {
            maxHealth += amount;
        }
    }
}
