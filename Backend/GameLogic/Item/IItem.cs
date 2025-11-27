using Backend.GameLogic.Effect;

namespace Backend.GameLogic.Item
{
    public interface IItem
    {
        public string GetName();
        public IEffect GetEffect();

        public bool CanBeLooted();

        public string GetType();

    }
}
