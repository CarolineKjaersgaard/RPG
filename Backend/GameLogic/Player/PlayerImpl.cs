using Backend.GameLogic.Effect;
using Backend.GameLogic.Entity;
using Backend.GameLogic.Item;

namespace Backend.GameLogic.Player
{
    public class PlayerImpl:IPlayer
    {
        private int health = 10;
        private int defense = 15;
        private int baseAttackMod = 2;
        private int baseDamageMod = 2;
        private Dictionary<string, IEffect> effects = new Dictionary<string, IEffect>();
        private List<IItem> inventory = new List<IItem>();
        private (int, int) currentCoords = (0, 0);
        private string name;
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
            //ExecuteEffect(item.GetEffect(), this);
        }

        public bool EndEffect(string effect)
        {
            throw new NotImplementedException();
        }

        public bool ExecuteEffect(string effect, IEntity target)
        {
            if(effects.ContainsKey(effect))
            {
                Effects[effect].ApplyEffect(target);
                return true;
            }
            return false;
        }

        public (int, int) GetCoords()
        {
            return CurrentCoords;
        }

        public List<string> GetEffectNames()
        {
            return effects.Keys.ToList();
        }

        public int GetHealth()
        {
            return health;
        }

        public string GetName()
        {
            return name;
        }
    }
}
