using Backend.GameLogic.ItemImpl;

namespace Backend.GameLogic.Entity
{
    public interface IEntity
    {
        public bool ExecuteEffect(string effect, IEntity target);

        public bool EndEffect(string effect);
        public string GetName();

        public List<string> GetEffectNames();

        public int GetHealth();

        public void UpdateHealth(int amount);

        public int GetMaxHealth();
        public void UpdateMaxHealth(int amount);

        public void AddItem(IItem item);
        List<IItem> GetItems();

        public void SetLastAction(string action);

        public int GetAttackMod();

        public void UpdateAttackMod(int amount);

        public int GetDefense();
        public void UpdateDefense(int amount);

        public int GetDamageMod();
        public void UpdateDamageMod(int amount);
        public void SetName(string name);
        public Dictionary<string, object> GetDictionaryRepresentation();
    }
}
