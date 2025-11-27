using Backend.GameLogic.Effect;

namespace Backend.GameLogic.Item
{
    public interface IItem
    {
        public IEffect GetEffect();
    }
}
