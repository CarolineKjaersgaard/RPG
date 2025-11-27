using Backend.GameLogic.Item;

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
    }
}
